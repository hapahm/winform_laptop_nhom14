5 nhánh: 
- main (chứa sản phẩm hoàn thiện. Các thành viên không push code vào đây)
- dev (nơi push-pull-merge code chạy thử)
- ha (Hà đẩy code lên nhánh này)
- tan (Tấn đẩy code lên nhánh này)
- trang (Tấn đẩy code lên nhánh này)
- mon (Tấn đẩy code lên nhánh này)
- phuong (Tấn đẩy code lên nhánh này)

  CÂU LỆNH LÀM VIỆC VỚI GIT
  (merge code lên develop, main thì t sẽ làm
  quy trình là: clone code về => code bài của mình trên visual
  => đẩy lên nhánh của mình => Hà merge code cả nhóm lên nhánh develop
  => Các thành viên kéo code từ nhánh develop về để chạy thử
  => hoàn thiện hết tất cả thì đẩy lên main)
1. Clone code về
  git clone https://github.com/hapahm/winform_laptop_nhom14.git
2. Add + Commit + Push code của bạn
   (Với trường hợp đang làm sẵn ở project riêng của mình,
   copy các file .cs, .Designer.cs,... sang project tổng vừa clone về,
   code xong thì đẩy lên nhánh của mình trên git như bình thường)
   git add .
   git commit -m "Code thêm gì thì cmt vào đây"
   git push origin ten-nhanh-cua-ban
4. Cập nhật code mới từ nhánh develop
   git checkout ten-nhanh-cua-ban
   git pull origin develop

