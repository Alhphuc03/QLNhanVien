using QLNhanVien;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QlNhanVien
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Tạo một đối tượng nhân viên
            NhanVien nhanVien = new NhanVien();

            // Nhập thông tin nhân viên
            nhanVien.Input();

            // In thông tin nhân viên
            nhanVien.PrintInfo();

            // Tính lương của nhân viên
            double luong = nhanVien.TinhLuong();
            Console.WriteLine($"Lương tháng của nhân viên: {luong}");

            // Tính phép của nhân viên
            Console.Write("Nhập điều kiện làm việc (bình thường, đặc biệt, nặng nhọc): ");
            string dieuKien = Console.ReadLine();
            Console.Write("Nhập số ngày nghỉ: ");
            int ngayNghi = int.Parse(Console.ReadLine());

            // Tính tổng lương của nhân viên
            double tongLuong = nhanVien.TinhPhep(dieuKien, ngayNghi);
            Console.WriteLine($"Tổng lương sau khi tính phép: {tongLuong}");

            // Tính thời gian làm việc
            Console.Write("Nhập giờ bắt đầu làm việc: ");
            double startTime = double.Parse(Console.ReadLine());
            Console.Write("Nhập giờ kết thúc làm việc: ");
            double endTime = double.Parse(Console.ReadLine());

            double thoiGianLamViec = nhanVien.TimeWorking(startTime, endTime);
            Console.WriteLine($"Thời gian làm việc sau khi tính điểm làm thêm: {thoiGianLamViec} giờ");

            // Tính phụ cấp của nhân viên
            double phuCap = nhanVien.TinhPhuCap();
            Console.WriteLine($"Phụ cấp của nhân viên: {phuCap}");

            //Tính thuế của nhân viên
            double thue = nhanVien.TinhThue();
            Console.WriteLine($"Thuế là: {thue}");
            // Kết thúc chương trình
            Console.ReadLine();
        }
    }
}
