

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace QLNhanVien
{
    public class NhanVien
    {
        public int maNv;
        public string tenNv;
        public DateTime ngaySinh;
        public string gioiTinh;
        public string diaChi;
        public DateTime ngayVaoLam;
        public string bangCap;
        public string hinhThucNV;
        private string phongBan;
        private string chucDanh;
        private int luongCoBan;
        private float heSo;

        public NhanVien() { }
        public NhanVien(int maNv, string tenNv, DateTime ngaySinh, string gioiTinh, string diaChi, DateTime ngayVaoLam, string bangCap, string hinhThucNV, string phongBan, string chucDanh, int luongCoBan, float heSo)
        {
            this.maNv = maNv;
            this.tenNv = tenNv;
            this.ngaySinh = ngaySinh;
            this.gioiTinh = gioiTinh;
            this.diaChi = diaChi;
            this.ngayVaoLam = ngayVaoLam;
            this.bangCap = bangCap;
            this.hinhThucNV = hinhThucNV;
            this.phongBan = phongBan;
            this.chucDanh = chucDanh;
            this.luongCoBan = luongCoBan;
            this.heSo = heSo;
        }

        public int MaNv
        {
            get { return maNv; }
            set { maNv = value; }
        }

        public string TenNv
        {
            get { return tenNv; }
            set { tenNv = value; }

        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set
            {
                DateTime eighteenYearsAgo = DateTime.Now.AddYears(-18);

                if (value > eighteenYearsAgo)
                {
                    throw new ArgumentException("Năm sinh phải đảm bảo nhân viên > 18 tuổi.");
                }

                ngaySinh = value;
            }
        }


        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public DateTime NgayVaoLam
        {
            get { return ngayVaoLam; }
            set { ngayVaoLam = value; }
        }
        public string BangCap
        {
            get { return bangCap; }
            set { bangCap = value; }
        }

        public string HinhThucNV
        {
            get { return hinhThucNV; }
            set
            {
                hinhThucNV = value;
            }
        }

        public string PhongBan
        {
            get { return phongBan; }
            set { phongBan = value; }
        }

        public float HeSo
        {
            get { return heSo; }
            set
            {
                if (value <= 0 || value >= 5)
                {
                    throw new ArgumentException("Hệ số lương phải nằm trong khoảng 0 và 5.");
                }
                heSo = value;
            }
        }

        public string ChucDanh
        {
            get { return chucDanh; }
            set { chucDanh = value; }
        }

        public int LuongCoBan
        {
            get { return luongCoBan; }
            set { luongCoBan = value; }
        }

        public void Input()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Nhập thông tin nhân viên");

            Console.Write("Mã nhân viên: ");
            maNv = int.Parse(Console.ReadLine());

            Console.Write("Họ tên nhân viên : ");
            tenNv = Console.ReadLine();

            do
            {
                Console.Write("Nhập ngày sinh (yyyy-MM-dd): ");
                ngaySinh = DateTime.Parse(Console.ReadLine());

                if (DateTime.Now.Subtract(ngaySinh).TotalDays < 18 * 365)
                {
                    Console.WriteLine("Ngày sinh phải đảm bảo nhân viên > 18 tuổi. Vui lòng nhập lại.");
                }

            } while (DateTime.Now.Subtract(ngaySinh).TotalDays < 18 * 365);


            Console.Write(" Nhập địa chỉ: ");
            diaChi = Console.ReadLine();

            do
            {
                Console.Write("Nhập ngày vào làm (yyyy-MM-dd): ");
                ngayVaoLam = DateTime.Parse(Console.ReadLine());

                if (ngayVaoLam > DateTime.Now)
                {
                    Console.WriteLine("Ngày vào làm không thể lớn hơn ngày hiện tại. Vui lòng nhập lại.");
                }

            } while (ngayVaoLam > DateTime.Now);


            string[] validBangCaps = { "thpt", "trung cấp", "cao đẳng", "đại học", "thạc sĩ", "tiến sĩ" };
            Console.WriteLine("Chọn bằng cấp:");
            for (int i = 0; i < validBangCaps.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {validBangCaps[i]}");
            }
            int selectedBangCapIndex;
            while (true)
            {
                Console.Write("Chọn số tương ứng: ");

                if (int.TryParse(Console.ReadLine(), out selectedBangCapIndex) && selectedBangCapIndex >= 1 && selectedBangCapIndex <= validBangCaps.Length)
                {
                    break;
                }

                Console.WriteLine("Số không hợp lệ. Vui lòng chọn lại.");
            }
            bangCap = validBangCaps[selectedBangCapIndex - 1];
            

            Console.Write("Nhập hình thức nhân viên (F - Full-time, P - Part-time): ");
            string inputHinhThucNV;
            while (true)
            {
                inputHinhThucNV = Console.ReadLine();

                if (string.Equals(inputHinhThucNV, "F", StringComparison.OrdinalIgnoreCase))
                {
                    hinhThucNV = "Full-time";
                    break;
                }
                else if (string.Equals(inputHinhThucNV, "P", StringComparison.OrdinalIgnoreCase))
                {
                    hinhThucNV = "Part-time";
                    break;
                }

                Console.WriteLine("Giá trị không hợp lệ. Vui lòng nhập 'F' hoặc 'P'.");
                Console.Write("Nhập hình thức nhân viên: ");
            }

            string[] validPhongBans = { "bảo vệ", "kế toán ", "hành chính ", "kinh doanh", "ban giám đốc"};
            Console.WriteLine("Chọn phòng ban:");
            for (int i = 0; i < validPhongBans.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {validPhongBans[i]}");
            }
            int selectedBPhongBanIndex;
            while (true)
            {
                Console.Write("Chọn số tương ứng: ");

                if (int.TryParse(Console.ReadLine(), out selectedBPhongBanIndex) && selectedBPhongBanIndex >= 1 && selectedBPhongBanIndex <= validBangCaps.Length)
                {
                    break;
                }

                Console.WriteLine("Số không hợp lệ. Vui lòng chọn lại.");
            }
            phongBan = validPhongBans[selectedBPhongBanIndex - 1];

            string[] validChucDanhs = { "nhân viên", "phó trưởng phòng", "trưởng phòng"};
            Console.WriteLine("Chọn chức danh:");
            for (int i = 0; i < validChucDanhs.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {validChucDanhs[i]}");
            }
            int selectedChucDanhIndex;
            while (true)
            {
                Console.Write("Chọn số tương ứng: ");

                if (int.TryParse(Console.ReadLine(), out selectedChucDanhIndex) && selectedChucDanhIndex >= 1 && selectedChucDanhIndex <= validBangCaps.Length)
                {
                    break;
                }

                Console.WriteLine("Số không hợp lệ. Vui lòng chọn lại.");
            }
            chucDanh = validChucDanhs[selectedChucDanhIndex - 1];


            Console.Write("Lương cơ bản: ");
            while (!int.TryParse(Console.ReadLine(), out luongCoBan) || luongCoBan < 0)
            {
                Console.WriteLine("Vui lòng nhập lương cơ bản hợp lệ.");
                Console.Write("Lương cơ bản: ");
            }

            Console.Write("Hệ số lương: ");
            while (!float.TryParse(Console.ReadLine(), out heSo) || heSo <= 0 || heSo >= 5)
            {
                Console.WriteLine("Vui lòng nhập hệ số lương hợp lệ (0 < hệ số < 5).");
                Console.Write("Hệ số lương: ");
            }
        }
        public void PrintInfo()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Thông tin nhân viên:");
            Console.WriteLine($"Mã nhân viên: {maNv}");
            Console.WriteLine($"Họ tên nhân viên: {tenNv}");
            Console.WriteLine($"Ngày sinh: {ngaySinh.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Địa chỉ: {diaChi}");
            Console.WriteLine($"Ngày vào làm: {ngayVaoLam.ToString("yyyy-MM-dd")}");
            Console.WriteLine($"Bằng cấp: {bangCap}");
            Console.WriteLine($"Hình thức nhân viên: {hinhThucNV}");
            Console.WriteLine($"Phòng ban: {phongBan}");
            Console.WriteLine($"Chức danh: {chucDanh}");
            Console.WriteLine($"Lương cơ bản: {luongCoBan}");
            Console.WriteLine($"Hệ số lương: {heSo}");
        }

        public  double TimeWorking(double start, double end)
        {
            // Vòng lặp để yêu cầu nhập lại nếu thời gian không hợp lệ
            while (start < 1 || start > 24 || end < 1 || end > 24)
            {
                Console.WriteLine("Thời gian không hợp lệ. Phải nằm trong khoảng từ 0 đến 24.");

                // Yêu cầu người dùng nhập lại
                Console.Write("Nhập lại thời gian bắt đầu: ");
                start = double.Parse(Console.ReadLine());

                Console.Write("Nhập lại thời gian kết thúc: ");
                end = double.Parse(Console.ReadLine());
            }

            double timeWorked = end - start;

            if (timeWorked < 8)
            {
                // Nếu trễ < 1.5 tiếng
                if (timeWorked >= 6.5)
                {
                    return 1;
                }
                // Nếu trễ 1.5-2h 
                else if (timeWorked >= 6 && timeWorked <= 6.5)
                {
                    return 0.5;
                }
                // > 2h tùy nghi lựa chọn
                else
                {
                    return 0;
                }
            }
            else
            {
                // Nếu thời gian làm việc từ 8-12 tiếng: mỗi giờ thêm được tính bằng 2 giờ làm bình thường
                double overtime = timeWorked - 8;
                // Tổng thời gian làm việc
                timeWorked += overtime * 2;

                return timeWorked;
            }
        }


        public double TinhPhep(string dieuKien, int ngayNghi)
        {

            int thamNien = DateTime.Now.Year - ngayVaoLam.Year;
            double ngayPhep = 0;
            double tienPhat = 0;
            double luongThem = 0;

            if (thamNien >= 12)
            {
                switch (dieuKien)
                {
                    case "bình thường":
                        ngayPhep = 12;
                        break;
                    case "đặc biệt":
                        ngayPhep = 14;
                        break;
                    case "nặng nhọc":
                        ngayPhep = 16;
                        break;
                    default:
                        Console.WriteLine("Điều kiện không hợp lệ");
                        break;
                }
            }

            else
            {
                ngayPhep = thamNien;
            }

            if (ngayNghi > ngayPhep)
            {
                // Tính tiền phạt khi nghỉ quá số ngày phép
                tienPhat = 0.2 * TinhLuong();
            }
            else if (ngayNghi < 0)
            {
                // Tính lương thêm khi đi làm thêm ca
                luongThem = -ngayNghi * 2 * TinhLuong();
            }

            // Tổng kết kết quả
            double tongLuong = TinhLuong() + luongThem - tienPhat;

            return tongLuong;
            // Nếu thâm niên >= 12 thì 
            // 1. Điều kiện bình thương có ngayphep là 12
            // 2. điều kiện đặc biệt có ngayphep là 14
            //3. điều kiện nặng nhọc có ngày phép là 16
            // Ngược lại thâm niên <12 thì ngayphep = thamNien
        }


        public double TinhPhuCap()
        {
            double phuCapHocVi = 0;
            double phuCapChucDanh = 0;
            double phuCapPhongBan = 0;

            double phuCap = 0;

            // Phụ cấp theo Học vị
            switch (bangCap.ToLower())
            {
                case "thpt":
                    phuCapHocVi = 0;
                    break;
                case "trung cấp":
                    phuCapHocVi = 2000;
                    break;
                case "cao đẳng":
                    phuCapHocVi = 4000;
                    break;
                case "đại học":
                    phuCapHocVi = 6000;
                    break;
                case "thạc sĩ":
                    phuCapHocVi = 8000;
                    break;
                case "tiến sĩ":
                    phuCapHocVi = 10000;
                    break;
                default:
                    Console.WriteLine("băng cấp không hợp lệ");
                    break;
            }

            // Phụ cấp theo Chức danh
            switch (chucDanh.ToLower())
            {
                case "nhân viên":
                    phuCapChucDanh = 2000;
                    break;
                case "phó trưởng phòng":
                    phuCapChucDanh = 5000;
                    break;
                case "trưởng phòng":
                    phuCapChucDanh = 10000;
                    break;
                default:
                    Console.WriteLine("Chức danh không hợp lệ");
                    break;
            }

            // Phụ cấp theo Phòng ban
            switch (phongBan.ToLower())
            {
                case "bảo vệ":
                    phuCapPhongBan = 1000;
                    break;
                case "kinh doanh":
                    phuCapPhongBan = 5000;
                    break;
                case "kế toán":
                    phuCapPhongBan = 5000;
                    break;
                case "hành chính":
                    phuCapPhongBan = 10000;
                    break;
                case "ban giám đốc":
                    phuCapPhongBan = 20000;
                    break;
                default:
                    Console.WriteLine("Phòng ban không hợp lệ");
                    break;
            }
            return phuCap = phuCapChucDanh + phuCapHocVi + phuCapPhongBan;
        }

        public double TinhLuongPartTime(string phongBan)
        {
            double luongPartTime = 0;
            switch (phongBan.ToLower())
            {
                case "bảo vệ":
                    luongPartTime = 1500;
                    break;
                case "kinh doanh":
                    luongPartTime = 2500;
                    break;
                case "kế toán":
                    luongPartTime = 2500;
                    break;
            }

            return luongPartTime;
        }

        public double TinhLuongThamNien()
        {
            int thamNien = DateTime.Now.Year - ngayVaoLam.Year;
            double luongThamNien = 0;

            if (thamNien >= 5 && thamNien <= 7)
            {
                luongThamNien = 1000;
            }
            else if (thamNien > 7 && thamNien <= 12)
            {
                luongThamNien = 1500;

            }
            else if (thamNien > 12)
            {
                luongThamNien = 2000;
            }

            return luongThamNien;
        }
        public double TinhLuong()
        {
            // nếu nghỉ quá ngày phép thì tiền phạt = bằng 20% lương tháng
            // nếu ngày nghỉ <0 (tức là đi làm thêm ca) thì những ngày làm thêm lương = 200% lương thông thường
            double phuCap = TinhPhuCap();
            double luongThamNien = TinhLuongThamNien();
            double luongThang = luongCoBan * heSo + phuCap + luongThamNien;

            return luongThang;
        }
        public double TinhThue()
        {
            double luongThang = TinhLuong();
            double BHXH = luongThang * 8 / 100;
            double BHYT = luongThang * 1.5 / 100;
            double BHTN = luongThang * 1 / 100;
            double TNCN = luongThang * 10 / 100;
            double thue = BHXH + BHYT + BHTN + TNCN;

            return thue;
        }
    }
}
