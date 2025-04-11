namespace QuanLyLaptop
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dgvLaptop = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HinhAnh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hangDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soLuongDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.laptopsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLyLaptopDBDataSet = new QuanLyLaptop.QuanLyLaptopDBDataSet();
            this.txtTen = new System.Windows.Forms.TextBox();
            this.txtGia = new System.Windows.Forms.TextBox();
            this.txtSoLuong = new System.Windows.Forms.TextBox();
            this.cmbHang = new System.Windows.Forms.ComboBox();
            this.btnThem = new System.Windows.Forms.Button();
            this.btnSua = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnHuy = new System.Windows.Forms.Button();
            this.laptopsTableAdapter = new QuanLyLaptop.QuanLyLaptopDBDataSetTableAdapters.LaptopsTableAdapter();
            this.picHinhAnh = new System.Windows.Forms.PictureBox();
            this.btnChonAnh = new System.Windows.Forms.Button();
            this.txtHinhAnh = new System.Windows.Forms.TextBox();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.btnXuatExcel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbHangFilter = new System.Windows.Forms.ComboBox();
            this.txtGiaMin = new System.Windows.Forms.TextBox();
            this.txtGiaMax = new System.Windows.Forms.TextBox();
            this.btnLoc = new System.Windows.Forms.Button();
            this.lblStatistics = new System.Windows.Forms.Label();
            this.btnInPDF = new System.Windows.Forms.Button();
            this.chartLaptop = new LiveCharts.WinForms.CartesianChart();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.laptopsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptop)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laptopsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyLaptopDBDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.laptopsBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLaptop
            // 
            this.dgvLaptop.AllowUserToOrderColumns = true;
            this.dgvLaptop.AutoGenerateColumns = false;
            this.dgvLaptop.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLaptop.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.HinhAnh,
            this.tenDataGridViewTextBoxColumn,
            this.hangDataGridViewTextBoxColumn,
            this.giaDataGridViewTextBoxColumn,
            this.soLuongDataGridViewTextBoxColumn});
            this.dgvLaptop.DataSource = this.laptopsBindingSource;
            this.dgvLaptop.Location = new System.Drawing.Point(33, 146);
            this.dgvLaptop.Name = "dgvLaptop";
            this.dgvLaptop.RowHeadersWidth = 51;
            this.dgvLaptop.RowTemplate.Height = 24;
            this.dgvLaptop.Size = new System.Drawing.Size(669, 246);
            this.dgvLaptop.TabIndex = 0;
            this.dgvLaptop.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvLaptop_CellContentClick);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.ReadOnly = true;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // HinhAnh
            // 
            this.HinhAnh.HeaderText = "HinhAnh";
            this.HinhAnh.MinimumWidth = 6;
            this.HinhAnh.Name = "HinhAnh";
            this.HinhAnh.Width = 125;
            // 
            // tenDataGridViewTextBoxColumn
            // 
            this.tenDataGridViewTextBoxColumn.DataPropertyName = "Ten";
            this.tenDataGridViewTextBoxColumn.HeaderText = "Ten";
            this.tenDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.tenDataGridViewTextBoxColumn.Name = "tenDataGridViewTextBoxColumn";
            this.tenDataGridViewTextBoxColumn.Width = 125;
            // 
            // hangDataGridViewTextBoxColumn
            // 
            this.hangDataGridViewTextBoxColumn.DataPropertyName = "Hang";
            this.hangDataGridViewTextBoxColumn.HeaderText = "Hang";
            this.hangDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.hangDataGridViewTextBoxColumn.Name = "hangDataGridViewTextBoxColumn";
            this.hangDataGridViewTextBoxColumn.Width = 125;
            // 
            // giaDataGridViewTextBoxColumn
            // 
            this.giaDataGridViewTextBoxColumn.DataPropertyName = "Gia";
            this.giaDataGridViewTextBoxColumn.HeaderText = "Gia";
            this.giaDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.giaDataGridViewTextBoxColumn.Name = "giaDataGridViewTextBoxColumn";
            this.giaDataGridViewTextBoxColumn.Width = 125;
            // 
            // soLuongDataGridViewTextBoxColumn
            // 
            this.soLuongDataGridViewTextBoxColumn.DataPropertyName = "SoLuong";
            this.soLuongDataGridViewTextBoxColumn.HeaderText = "SoLuong";
            this.soLuongDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.soLuongDataGridViewTextBoxColumn.Name = "soLuongDataGridViewTextBoxColumn";
            this.soLuongDataGridViewTextBoxColumn.Width = 125;
            // 
            // laptopsBindingSource
            // 
            this.laptopsBindingSource.DataMember = "Laptops";
            this.laptopsBindingSource.DataSource = this.quanLyLaptopDBDataSet;
            // 
            // quanLyLaptopDBDataSet
            // 
            this.quanLyLaptopDBDataSet.DataSetName = "QuanLyLaptopDBDataSet";
            this.quanLyLaptopDBDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // txtTen
            // 
            this.txtTen.Location = new System.Drawing.Point(81, 26);
            this.txtTen.Name = "txtTen";
            this.txtTen.Size = new System.Drawing.Size(100, 22);
            this.txtTen.TabIndex = 1;
            this.txtTen.TextChanged += new System.EventHandler(this.txtTen_TextChanged);
            // 
            // txtGia
            // 
            this.txtGia.Location = new System.Drawing.Point(278, 25);
            this.txtGia.Name = "txtGia";
            this.txtGia.Size = new System.Drawing.Size(100, 22);
            this.txtGia.TabIndex = 2;
            // 
            // txtSoLuong
            // 
            this.txtSoLuong.Location = new System.Drawing.Point(464, 23);
            this.txtSoLuong.Name = "txtSoLuong";
            this.txtSoLuong.Size = new System.Drawing.Size(100, 22);
            this.txtSoLuong.TabIndex = 3;
            // 
            // cmbHang
            // 
            this.cmbHang.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.laptopsBindingSource, "Hang", true));
            this.cmbHang.DataSource = this.laptopsBindingSource;
            this.cmbHang.FormattingEnabled = true;
            this.cmbHang.Location = new System.Drawing.Point(81, 66);
            this.cmbHang.Name = "cmbHang";
            this.cmbHang.Size = new System.Drawing.Size(121, 24);
            this.cmbHang.TabIndex = 4;
            // 
            // btnThem
            // 
            this.btnThem.Location = new System.Drawing.Point(12, 415);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(75, 23);
            this.btnThem.TabIndex = 5;
            this.btnThem.Text = "Them";
            this.btnThem.UseVisualStyleBackColor = true;
            this.btnThem.Click += new System.EventHandler(this.btnThem_Click);
            // 
            // btnSua
            // 
            this.btnSua.Location = new System.Drawing.Point(105, 415);
            this.btnSua.Name = "btnSua";
            this.btnSua.Size = new System.Drawing.Size(75, 23);
            this.btnSua.TabIndex = 6;
            this.btnSua.Text = "Sua";
            this.btnSua.UseVisualStyleBackColor = true;
            this.btnSua.Click += new System.EventHandler(this.btnSua_Click_1);
            // 
            // btnXoa
            // 
            this.btnXoa.Location = new System.Drawing.Point(186, 415);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(75, 23);
            this.btnXoa.TabIndex = 7;
            this.btnXoa.Text = "Xoa";
            this.btnXoa.UseVisualStyleBackColor = true;
            this.btnXoa.Click += new System.EventHandler(this.btnXoa_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(267, 415);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(75, 23);
            this.btnLuu.TabIndex = 8;
            this.btnLuu.Text = "Luu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(359, 415);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(75, 23);
            this.btnHuy.TabIndex = 9;
            this.btnHuy.Text = "Huy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // laptopsTableAdapter
            // 
            this.laptopsTableAdapter.ClearBeforeFill = true;
            // 
            // picHinhAnh
            // 
            this.picHinhAnh.Image = ((System.Drawing.Image)(resources.GetObject("picHinhAnh.Image")));
            this.picHinhAnh.Location = new System.Drawing.Point(670, 23);
            this.picHinhAnh.Name = "picHinhAnh";
            this.picHinhAnh.Size = new System.Drawing.Size(100, 50);
            this.picHinhAnh.TabIndex = 10;
            this.picHinhAnh.TabStop = false;
            this.picHinhAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // btnChonAnh
            // 
            this.btnChonAnh.Location = new System.Drawing.Point(452, 415);
            this.btnChonAnh.Name = "btnChonAnh";
            this.btnChonAnh.Size = new System.Drawing.Size(75, 23);
            this.btnChonAnh.TabIndex = 11;
            this.btnChonAnh.Text = "Chon Anh";
            this.btnChonAnh.UseVisualStyleBackColor = true;
            this.btnChonAnh.Click += new System.EventHandler(this.btnChonAnh_Click);
            // 
            // txtHinhAnh
            // 
            this.txtHinhAnh.Location = new System.Drawing.Point(296, 62);
            this.txtHinhAnh.Name = "txtHinhAnh";
            this.txtHinhAnh.Size = new System.Drawing.Size(100, 22);
            this.txtHinhAnh.TabIndex = 12;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Location = new System.Drawing.Point(482, 62);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(100, 22);
            this.txtTimKiem.TabIndex = 13;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.Location = new System.Drawing.Point(549, 415);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 23);
            this.btnTimKiem.TabIndex = 14;
            this.btnTimKiem.Text = "Tim Kiem";
            this.btnTimKiem.UseVisualStyleBackColor = true;
            this.btnTimKiem.Click += new System.EventHandler(this.btnTimKiem_Click);
            // 
            // btnXuatExcel
            // 
            this.btnXuatExcel.Location = new System.Drawing.Point(640, 415);
            this.btnXuatExcel.Name = "btnXuatExcel";
            this.btnXuatExcel.Size = new System.Drawing.Size(102, 23);
            this.btnXuatExcel.TabIndex = 15;
            this.btnXuatExcel.Text = "XuatExcel";
            this.btnXuatExcel.UseVisualStyleBackColor = true;
            this.btnXuatExcel.Click += new System.EventHandler(this.btnXuatExcel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 16);
            this.label1.TabIndex = 16;
            this.label1.Text = "Ten:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(218, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Gia:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(394, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 18;
            this.label3.Text = "SoLuong:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(580, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 16);
            this.label4.TabIndex = 19;
            this.label4.Text = "Chon Anh:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 16);
            this.label5.TabIndex = 20;
            this.label5.Text = "Hang:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(221, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 16);
            this.label6.TabIndex = 21;
            this.label6.Text = "Link Anh:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(412, 62);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Tim Kiem:";
            // 
            // cmbHangFilter
            // 
            this.cmbHangFilter.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.laptopsBindingSource, "Hang", true));
            this.cmbHangFilter.FormattingEnabled = true;
            this.cmbHangFilter.Location = new System.Drawing.Point(115, 106);
            this.cmbHangFilter.Name = "cmbHangFilter";
            this.cmbHangFilter.Size = new System.Drawing.Size(121, 24);
            this.cmbHangFilter.TabIndex = 23;
            // 
            // txtGiaMin
            // 
            this.txtGiaMin.Location = new System.Drawing.Point(323, 109);
            this.txtGiaMin.Name = "txtGiaMin";
            this.txtGiaMin.Size = new System.Drawing.Size(100, 22);
            this.txtGiaMin.TabIndex = 24;
            // 
            // txtGiaMax
            // 
            this.txtGiaMax.Location = new System.Drawing.Point(524, 109);
            this.txtGiaMax.Name = "txtGiaMax";
            this.txtGiaMax.Size = new System.Drawing.Size(100, 22);
            this.txtGiaMax.TabIndex = 25;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.Teal;
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(654, 106);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(75, 23);
            this.btnLoc.TabIndex = 26;
            this.btnLoc.Text = "Loc";
            this.btnLoc.UseVisualStyleBackColor = false;
            this.btnLoc.Click += new System.EventHandler(this.btnLoc_Click);
            // 
            // lblStatistics
            // 
            this.lblStatistics.AutoSize = true;
            this.lblStatistics.ForeColor = System.Drawing.Color.LightSlateGray;
            this.lblStatistics.Location = new System.Drawing.Point(43, 396);
            this.lblStatistics.Name = "lblStatistics";
            this.lblStatistics.Size = new System.Drawing.Size(44, 16);
            this.lblStatistics.TabIndex = 27;
            this.lblStatistics.Text = "label8";
            // 
            // btnInPDF
            // 
            this.btnInPDF.Location = new System.Drawing.Point(763, 415);
            this.btnInPDF.Name = "btnInPDF";
            this.btnInPDF.Size = new System.Drawing.Size(75, 23);
            this.btnInPDF.TabIndex = 28;
            this.btnInPDF.Text = "In PDF";
            this.btnInPDF.UseVisualStyleBackColor = true;
            this.btnInPDF.Click += new System.EventHandler(this.btnInPDF_Click);
            // 
            // chartLaptop
            // 
            this.chartLaptop.Location = new System.Drawing.Point(708, 146);
            this.chartLaptop.Name = "chartLaptop";
            this.chartLaptop.Size = new System.Drawing.Size(200, 100);
            this.chartLaptop.TabIndex = 29;
            this.chartLaptop.Text = "cartesianChart1";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 109);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(97, 16);
            this.label8.TabIndex = 30;
            this.label8.Text = "Loc theo Hang:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(255, 113);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 31;
            this.label9.Text = "Gia Min:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(449, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 16);
            this.label10.TabIndex = 32;
            this.label10.Text = "Gia Max:";
            // 
            // laptopsBindingSource1
            // 
            this.laptopsBindingSource1.DataMember = "Laptops";
            this.laptopsBindingSource1.DataSource = this.quanLyLaptopDBDataSet;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 450);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.chartLaptop);
            this.Controls.Add(this.btnInPDF);
            this.Controls.Add(this.lblStatistics);
            this.Controls.Add(this.btnLoc);
            this.Controls.Add(this.txtGiaMax);
            this.Controls.Add(this.txtGiaMin);
            this.Controls.Add(this.cmbHangFilter);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnXuatExcel);
            this.Controls.Add(this.btnTimKiem);
            this.Controls.Add(this.txtTimKiem);
            this.Controls.Add(this.txtHinhAnh);
            this.Controls.Add(this.btnChonAnh);
            this.Controls.Add(this.picHinhAnh);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnXoa);
            this.Controls.Add(this.btnSua);
            this.Controls.Add(this.btnThem);
            this.Controls.Add(this.cmbHang);
            this.Controls.Add(this.txtSoLuong);
            this.Controls.Add(this.txtGia);
            this.Controls.Add(this.txtTen);
            this.Controls.Add(this.dgvLaptop);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLaptop)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laptopsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLyLaptopDBDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picHinhAnh)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.laptopsBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLaptop;
        private System.Windows.Forms.TextBox txtTen;
        private System.Windows.Forms.TextBox txtGia;
        private System.Windows.Forms.TextBox txtSoLuong;
        private System.Windows.Forms.ComboBox cmbHang;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.Button btnSua;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnHuy;
        private QuanLyLaptopDBDataSet quanLyLaptopDBDataSet;
        private System.Windows.Forms.BindingSource laptopsBindingSource;
        private QuanLyLaptopDBDataSetTableAdapters.LaptopsTableAdapter laptopsTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn HinhAnh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hangDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soLuongDataGridViewTextBoxColumn;
        private System.Windows.Forms.PictureBox picHinhAnh;
        private System.Windows.Forms.Button btnChonAnh;
        private System.Windows.Forms.TextBox txtHinhAnh;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.Button btnXuatExcel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbHangFilter;
        private System.Windows.Forms.TextBox txtGiaMin;
        private System.Windows.Forms.TextBox txtGiaMax;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Label lblStatistics;
        private System.Windows.Forms.Button btnInPDF;
        private LiveCharts.WinForms.CartesianChart chartLaptop;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.BindingSource laptopsBindingSource1;
    }
}

