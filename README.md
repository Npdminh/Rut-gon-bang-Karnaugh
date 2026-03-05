# Logic Function Simplifier

## Karnaugh Map & Quine--McCluskey (C# Windows Forms)

------------------------------------------------------------------------

# 1. Giới thiệu

Trong thiết kế mạch số (Digital Logic Design), việc rút gọn hàm Boolean
giúp giảm số lượng cổng logic và tối ưu hóa mạch. Chương trình này được
xây dựng bằng **C# Windows Forms** nhằm hỗ trợ tự động rút gọn hàm logic
bằng hai phương pháp phổ biến:

-   Karnaugh Map
-   Quine--McCluskey

Ứng dụng cho phép người dùng nhập **minterm**, tạo **bảng chân trị**, và
hiển thị **biểu thức Boolean tối giản**.

------------------------------------------------------------------------

# 2. Mục tiêu chương trình

-   Xây dựng công cụ rút gọn hàm logic tự động
-   Áp dụng thuật toán Karnaugh và Quine--McCluskey
-   Thiết kế giao diện GUI thân thiện
-   Hỗ trợ sinh viên học môn Logic số

------------------------------------------------------------------------

# 3. Công nghệ sử dụng

  Công nghệ               Mô tả
  ----------------------- ----------------------------
  C#                      Ngôn ngữ lập trình
  .NET / .NET Framework   Nền tảng chạy chương trình
  Windows Forms           Thiết kế giao diện
  Visual Studio           Môi trường phát triển
  DataGridView            Hiển thị bảng chân trị

------------------------------------------------------------------------

# 4. Chức năng chính

## Chọn số biến

Hỗ trợ các hàm logic: - 2 biến - 3 biến - 4 biến

Bảng chân trị được tạo tự động theo công thức:

2\^n (n là số biến)

## Chọn phương pháp rút gọn

-   Karnaugh Map
-   Quine--McCluskey

## Nhập Minterm

Ví dụ: 0,2,4,6

Các giá trị cách nhau bằng dấu phẩy.

## Tạo bảng chân trị

Chương trình tự động sinh bảng chân trị dựa trên số biến.

## Rút gọn biểu thức

Sau khi nhấn **Rút gọn**, chương trình sẽ tính toán và hiển thị biểu
thức tối giản.

------------------------------------------------------------------------

# 5. Giao diện chương trình

Các thành phần chính:

-   Chọn số biến
-   Chọn phương pháp
-   Ô nhập minterm
-   Nút **Rút gọn**
-   Bảng chân trị
-   Kết quả rút gọn



------------------------------------------------------------------------

# 6. Quy trình hoạt động

Chọn số biến ↓ Chọn phương pháp ↓ Nhập minterm ↓ Nhấn "Rút gọn" ↓ Tạo
bảng chân trị ↓ Áp dụng thuật toán ↓ Hiển thị kết quả

------------------------------------------------------------------------

# 7. Thuật toán

## Karnaugh Map

Các bước: 1. Tạo bản đồ Karnaugh 2. Đánh dấu các ô có giá trị 1 3. Gom
nhóm các ô (1,2,4,8,...) 4. Tạo biểu thức tối giản

## Quine--McCluskey

Các bước: 1. Nhóm minterm theo số bit 1 2. Ghép các minterm khác nhau 1
bit 3. Tìm Prime Implicants 4. Lập Prime Implicant Chart 5. Tạo biểu
thức tối giản

------------------------------------------------------------------------

# 8. Cấu trúc project

Karnaugh │ ├── Form1.cs ├── Form1.Designer.cs ├── Program.cs │
├── Algorithms │ ├── Karnaugh.cs │ └── QuineMcCluskey.cs │ └── README.md

------------------------------------------------------------------------

# 9. Hướng dẫn chạy chương trình

## Chạy file EXE

Mở file: Karnaugh.exe

## Chạy bằng Visual Studio

1.  Mở project
2.  Nhấn **F5** để chạy

------------------------------------------------------------------------

# 10. Kết luận

Chương trình đã xây dựng thành công một công cụ rút gọn hàm logic với
giao diện GUI trực quan. Ứng dụng hỗ trợ học tập và nghiên cứu môn
**Thiết kế logic khả trình**.

Hướng phát triển: - Hỗ trợ nhiều biến hơn - Hiển thị bản đồ Karnaugh
trực quan - Xuất kết quả ra file
