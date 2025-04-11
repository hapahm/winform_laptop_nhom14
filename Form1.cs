using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using LiveCharts;
using LiveCharts.Wpf; // LiveCharts.WinForms sử dụng một số thành phần từ WPF


namespace QuanLyLaptop
{
    public partial class Form1 : Form
    {
        private string connectionString = "Data Source=.;Initial Catalog=QuanLyLaptopDB;Integrated Security=True";
        private bool isAddingNew = false;

        public class Laptop
        {
            public int ID { get; set; }
            public string Ten { get; set; }
            public string Hang { get; set; }
            public decimal Gia { get; set; }
            public int SoLuong { get; set; }
            public string HinhAnh { get; set; }
        }

        private void txtTen_TextChanged(object sender, EventArgs e)
        {
            // Xử lý khi văn bản trong txtTen thay đổi
            // Ví dụ: Kiểm tra độ dài tên
            if (txtTen.Text.Length > 100)
            {
                MessageBox.Show("Tên laptop không được vượt quá 100 ký tự!");
                txtTen.Text = txtTen.Text.Substring(0, 100); // Cắt bớt nếu vượt quá
                txtTen.SelectionStart = txtTen.Text.Length; // Đặt con trỏ ở cuối
            }
        }

        private void btnSua_Click_1(object sender, EventArgs e)
        {
            if (dgvLaptop.SelectedRows.Count > 0)
            {
                isAddingNew = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!");
            }
        }

        public Form1()
        {
            InitializeComponent();
            txtGia.Leave += txtGia_Leave;
            txtSoLuong.Leave += txtSoLuong_Leave;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            LoadData();
            LoadHangFilter();
            DisplayStatistics();
            LoadCharts();

        }

        private void LoadData()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Sử dụng stored procedure để lấy dữ liệu
                    SqlCommand cmd = new SqlCommand("sp_GetAllLaptops", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLaptop.DataSource = dt;

                    if (dgvLaptop.Rows.Count > 0 && dgvLaptop.SelectedRows.Count > 0)
                    {
                        string hinhAnh = dgvLaptop.SelectedRows[0].Cells["HinhAnh"].Value?.ToString();
                        if (!string.IsNullOrEmpty(hinhAnh) && File.Exists(hinhAnh))
                            picHinhAnh.Image = System.Drawing.Image.FromFile(hinhAnh);
                        else
                            picHinhAnh.Image = null;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }
        // Tải danh sách hãng vào ComboBox lọc
        private void LoadHangFilter()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT DISTINCT Hang FROM Laptops";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    cmbHangFilter.Items.Clear();
                    cmbHangFilter.Items.Add("Tất cả"); // Thêm tùy chọn "Tất cả"
                    while (reader.Read())
                    {
                        cmbHangFilter.Items.Add(reader["Hang"].ToString());
                    }
                    cmbHangFilter.SelectedIndex = 0; // Mặc định chọn "Tất cả"
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải danh sách hãng: " + ex.Message);
                }
            }
        }

        // Hiển thị thống kê
        private void DisplayStatistics()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT COUNT(*) AS TotalLaptops, SUM(Gia * SoLuong) AS TotalValue FROM Laptops";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        lblStatistics.Text = $"Tổng số laptop: {reader["TotalLaptops"]} | Tổng giá trị: {Convert.ToDecimal(reader["TotalValue"]).ToString("N0")} VNĐ";
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tính thống kê: " + ex.Message);
                }
            }
        }

        private void txtGia_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtGia.Text) && !decimal.TryParse(txtGia.Text, out decimal gia))
            {
                MessageBox.Show(this, "Giá phải là một số hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGia.Focus();
            }
        }

        private void txtSoLuong_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtSoLuong.Text) && !int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show(this, "Số lượng phải là một số nguyên hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtSoLuong.Focus();
            }
        }



        private void LoadCharts()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Biểu đồ cột: Số lượng laptop theo hãng
                    var columnSeries = new ColumnSeries
                    {
                        Title = "Số Lượng Theo Hãng",
                        Values = new ChartValues<int>()
                    };

                    var labels = new List<string>(); // Nhãn cho trục X (các hãng)

                    string querySoLuong = "SELECT Hang, SUM(SoLuong) as TongSoLuong FROM Laptops GROUP BY Hang";
                    SqlCommand cmdSoLuong = new SqlCommand(querySoLuong, conn);
                    SqlDataReader readerSoLuong = cmdSoLuong.ExecuteReader();

                    while (readerSoLuong.Read())
                    {
                        string hang = readerSoLuong["Hang"].ToString();
                        int soLuong = Convert.ToInt32(readerSoLuong["TongSoLuong"]);
                        columnSeries.Values.Add(soLuong);
                        labels.Add(hang);
                    }
                    readerSoLuong.Close();

                    chartLaptop.Series = new SeriesCollection { columnSeries };
                    chartLaptop.AxisX.Clear();
                    chartLaptop.AxisX.Add(new Axis
                    {
                        Title = "Hãng",
                        Labels = labels
                    });
                    chartLaptop.AxisY.Clear();
                    chartLaptop.AxisY.Add(new Axis
                    {
                        Title = "Số Lượng",
                        LabelFormatter = value => value.ToString("N0")
                    });

                    // 2. Biểu đồ tròn: Tỷ lệ giá trị hàng tồn kho theo hãng
                    var pieChart = new LiveCharts.WinForms.PieChart
                    {
                        Location = new System.Drawing.Point(700, 500),
                        Size = new System.Drawing.Size(300, 300),
                        Anchor = AnchorStyles.Right | AnchorStyles.Bottom
                    };
                    this.Controls.Add(pieChart);

                    var pieSeries = new SeriesCollection();
                    string queryGiaTri = "SELECT Hang, SUM(Gia * SoLuong) as TongGiaTri FROM Laptops GROUP BY Hang";
                    SqlCommand cmdGiaTri = new SqlCommand(queryGiaTri, conn);
                    SqlDataReader readerGiaTri = cmdGiaTri.ExecuteReader();

                    while (readerGiaTri.Read())
                    {
                        string hang = readerGiaTri["Hang"].ToString();
                        decimal giaTri = Convert.ToDecimal(readerGiaTri["TongGiaTri"]);
                        pieSeries.Add(new PieSeries
                        {
                            Title = hang,
                            Values = new ChartValues<decimal> { giaTri },
                            DataLabels = true,
                            LabelPoint = chartPoint => $"{chartPoint.Y:N0} VNĐ ({chartPoint.Participation:P})"
                        });
                    }
                    readerGiaTri.Close();

                    pieChart.Series = pieSeries;
                    pieChart.LegendLocation = LegendLocation.Right;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải biểu đồ: " + ex.Message);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            isAddingNew = true;
            txtTen.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            cmbHang.SelectedIndex = -1;
            txtHinhAnh.Text = "";
            picHinhAnh.Image = null;
            txtTen.Focus();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvLaptop.SelectedRows.Count > 0)
            {
                isAddingNew = false;
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvLaptop.SelectedRows.Count > 0)
            {
                // Xác nhận trước khi xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(dgvLaptop.SelectedRows[0].Cells["ID"].Value);
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        try
                        {
                            conn.Open();
                            // Sử dụng stored procedure để xóa
                            SqlCommand cmd = new SqlCommand("sp_DeleteLaptop", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.ExecuteNonQuery();
                            LoadData();
                            DisplayStatistics(); // Cập nhật thống kê
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xóa: " + ex.Message);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một sản phẩm để xóa!");
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTen.Text) || cmbHang.SelectedIndex == -1 ||
                !decimal.TryParse(txtGia.Text, out decimal gia) || !int.TryParse(txtSoLuong.Text, out int soLuong))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và đúng định dạng thông tin!");
                return;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    if (isAddingNew)
                    {
                        // Sử dụng stored procedure để thêm
                        SqlCommand cmd = new SqlCommand("sp_InsertLaptop", conn);
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ten", txtTen.Text);
                        cmd.Parameters.AddWithValue("@Hang", cmbHang.Text);
                        cmd.Parameters.AddWithValue("@Gia", gia);
                        cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                        cmd.Parameters.AddWithValue("@HinhAnh", txtHinhAnh.Text ?? (object)DBNull.Value);
                        cmd.ExecuteNonQuery();
                    }
                    else
                    {
                        if (dgvLaptop.SelectedRows.Count > 0)
                        {
                            int id = Convert.ToInt32(dgvLaptop.SelectedRows[0].Cells["ID"].Value);
                            // Sử dụng stored procedure để sửa
                            SqlCommand cmd = new SqlCommand("sp_UpdateLaptop", conn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@ID", id);
                            cmd.Parameters.AddWithValue("@Ten", txtTen.Text);
                            cmd.Parameters.AddWithValue("@Hang", cmbHang.Text);
                            cmd.Parameters.AddWithValue("@Gia", gia);
                            cmd.Parameters.AddWithValue("@SoLuong", soLuong);
                            cmd.Parameters.AddWithValue("@HinhAnh", txtHinhAnh.Text ?? (object)DBNull.Value);
                            cmd.ExecuteNonQuery();
                        }
                        else
                        {
                            MessageBox.Show("Vui lòng chọn một sản phẩm để sửa!");
                            return;
                        }
                    }
                    LoadData();
                    LoadHangFilter(); // Cập nhật bộ lọc hãng
                    DisplayStatistics(); // Cập nhật thống kê
                    btnHuy_Click(null, null);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lưu: " + ex.Message);
                }
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTen.Text = "";
            txtGia.Text = "";
            txtSoLuong.Text = "";
            cmbHang.SelectedIndex = -1;
            txtHinhAnh.Text = "";
            picHinhAnh.Image = null;
            isAddingNew = false;
        }

        private void dgvLaptop_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvLaptop.Rows[e.RowIndex];
                txtTen.Text = row.Cells["Ten"].Value.ToString();
                txtGia.Text = row.Cells["Gia"].Value.ToString();
                txtSoLuong.Text = row.Cells["SoLuong"].Value.ToString();
                cmbHang.Text = row.Cells["Hang"].Value.ToString();
                string hinhAnh = row.Cells["HinhAnh"].Value?.ToString();
                txtHinhAnh.Text = hinhAnh;
                if (!string.IsNullOrEmpty(hinhAnh) && File.Exists(hinhAnh))
                    picHinhAnh.Image = System.Drawing.Image.FromFile(hinhAnh);
                else
                    picHinhAnh.Image = null;
            }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                picHinhAnh.Image = System.Drawing.Image.FromFile(openFile.FileName);
                txtHinhAnh.Text = openFile.FileName;
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Sử dụng stored procedure để tìm kiếm
                    SqlCommand cmd = new SqlCommand("sp_SearchLaptops", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Keyword", "%" + keyword + "%");
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLaptop.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message);
                }
            }
        }

        // Lọc nâng cao theo hãng và khoảng giá
        private void btnLoc_Click(object sender, EventArgs e)
        {
            string hang = cmbHangFilter.SelectedItem?.ToString();
            decimal giaMin = string.IsNullOrEmpty(txtGiaMin.Text) ? 0 : Convert.ToDecimal(txtGiaMin.Text);
            decimal giaMax = string.IsNullOrEmpty(txtGiaMax.Text) ? decimal.MaxValue : Convert.ToDecimal(txtGiaMax.Text);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("sp_FilterLaptops", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Hang", hang == "Tất cả" ? (object)DBNull.Value : hang);
                    cmd.Parameters.AddWithValue("@GiaMin", giaMin);
                    cmd.Parameters.AddWithValue("@GiaMax", giaMax);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLaptop.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lọc: " + ex.Message);
                }
            }
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Laptops";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    using (var workbook = new XLWorkbook())
                    {
                        var worksheet = workbook.Worksheets.Add("DanhSachLaptop");
                        worksheet.Cell(1, 1).InsertTable(dt);
                        worksheet.Columns().AdjustToContents();

                        SaveFileDialog saveFile = new SaveFileDialog();
                        saveFile.Filter = "Excel files (*.xlsx)|*.xlsx";
                        saveFile.FileName = "DanhSachLaptop.xlsx";
                        if (saveFile.ShowDialog() == DialogResult.OK)
                        {
                            workbook.SaveAs(saveFile.FileName);
                            MessageBox.Show("Xuất file Excel thành công!");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xuất Excel: " + ex.Message);
                }
            }
        }

        // In danh sách ra PDF
        private void btnInPDF_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM Laptops";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "PDF files (*.pdf)|*.pdf";
                    saveFile.FileName = "DanhSachLaptop.pdf";
                    if (saveFile.ShowDialog() == DialogResult.OK)
                    {
                        Document document = new Document();
                        iTextSharp.text.pdf.PdfWriter.GetInstance(document, new FileStream(saveFile.FileName, FileMode.Create));
                        document.Open();

                        PdfPTable table = new PdfPTable(dt.Columns.Count);
                        table.WidthPercentage = 100;

                        // Thêm tiêu đề cột
                        foreach (DataColumn column in dt.Columns)
                        {
                            PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                            table.AddCell(cell);
                        }

                        // Thêm dữ liệu
                        foreach (DataRow row in dt.Rows)
                        {
                            foreach (var item in row.ItemArray)
                            {
                                table.AddCell(item.ToString());
                            }
                        }

                        document.Add(new Paragraph("Danh Sách Laptop"));
                        document.Add(new Paragraph(" "));
                        document.Add(table);
                        document.Close();

                        MessageBox.Show("In PDF thành công!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi in PDF: " + ex.Message);
                }
            }
        }

        // Sắp xếp DataGridView khi nhấp vào tiêu đề cột
        private void dgvLaptop_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = dgvLaptop.Columns[e.ColumnIndex].Name;
            string sortDirection = "ASC";

            // Đảo chiều sắp xếp nếu cột đã được sắp xếp trước đó
            if (dgvLaptop.Tag?.ToString() == columnName)
            {
                sortDirection = "DESC";
                dgvLaptop.Tag = null;
            }
            else
            {
                dgvLaptop.Tag = columnName;
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = $"SELECT * FROM Laptops ORDER BY {columnName} {sortDirection}";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvLaptop.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi sắp xếp: " + ex.Message);
                }
            }
        }

        private void dgvLaptop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}