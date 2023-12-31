﻿using API1.Data;
using API1.DTO;
using API1.Interface;
using API1.Models;

namespace API1.Repository
{
    public class AdminRepository : IAdminRepository
    {
        private readonly QLDSVContext _context;

        public AdminRepository(QLDSVContext context)
        {
            _context = context;
        }
        public IEnumerable<SinhVien> DanhSachSinhVien()
        {
            var danhSachSinhVien = _context.SinhViens.ToList();
            return danhSachSinhVien;

        }

        public IEnumerable<SinhVien> DanhSachSinhVienTheoLop(string maLop)
        {
            var danhSachSinhVienTheoLop = _context.SinhViens.Where(sv => sv.MaLop.Equals(maLop)).ToList();
            return danhSachSinhVienTheoLop;
        }
        public SinhVien SinhVienTheoMa(string maSV)
        {
            var danhSachSinhVienTheoMa = _context.SinhViens.FirstOrDefault(sv => sv.MaSv.Equals(maSV));
            return danhSachSinhVienTheoMa;
        }

        public int ThemMoiSinhVien(SinhVienDTO sinhVien)
        {
            SinhVien s = SinhVienTheoMa(sinhVien.MaSv);
            if (s == null) // nếu chưa tồn tại sinh viên đó thì mới thêm
            {
                string email1 = sinhVien.MaSv.ToLower() + "@student.ptithcm.edu.vn";
                SinhVien sinhVienNew = new SinhVien();
                sinhVienNew.MaSv = sinhVien.MaSv;
                sinhVienNew.HoTen = sinhVien.HoTen;
                sinhVienNew.GioiTinh = sinhVien.GioiTinh;
                sinhVienNew.NgaySinh = sinhVien.NgaySinh;
                sinhVienNew.Email1 = email1;
                sinhVienNew.Email2 = sinhVien.Email2;
                sinhVienNew.Sdt1 = sinhVien.Sdt1;
                sinhVienNew.Sdt2 = sinhVien.Sdt2;
                sinhVienNew.QueQuan = sinhVien.QueQuan;
                sinhVienNew.MaLop = sinhVien.MaLop;

                //thêm tài khoản cho sinh viên đó
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TenDn = sinhVien.MaSv;
                taiKhoan.Password = sinhVien.MaSv;
                taiKhoan.MaRole = 3;
                taiKhoan.TrangThai = 1;

                //thêm tài khoản vào db trước
                _context.Add(taiKhoan);

                _context.Add(sinhVienNew);
                Save();
                return 1;
            }
            else // nếu tồn tại rồi thì trả về lỗi không thêm được
            {
                return 0;
            }

        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<GiangVien> DanhSachGiangVien()
        {
            var danhSachGiangVien = _context.GiangViens.ToList();
            return danhSachGiangVien;
        }

        public GiangVien GiangVienTheoMa(string maGV)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(gv => gv.MaGv.Equals(maGV));
            return giangVien;
        }

        public int ThemMoiGiangVien(GiangVienDTO giangVien)
        {
            GiangVien gv = GiangVienTheoMa(giangVien.MaGv);
            if(gv == null) //thêm được
            {
                string email1 = giangVien.MaGv.ToLower() + "@ptithcm.edu.vn";
                GiangVien giangVienNew = new GiangVien();
                giangVienNew.MaGv = giangVien.MaGv;
                giangVienNew.HoTen = giangVien.HoTen;
                giangVienNew.NgaySinh = giangVien.NgaySinh;
                giangVienNew.GioiTinh = giangVien.GioiTinh;
                giangVienNew.HocHam = giangVien.HocHam;
                giangVienNew.Email1 = email1;
                giangVienNew.Email2 = giangVien.Email2;
                giangVienNew.Sdt1 = giangVien.Sdt1;
                giangVienNew.Sdt2 = giangVien.Sdt2;
                giangVienNew.QueQuan = giangVien.QueQuan;

                //thêm tài khoản cho giảng viên
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TenDn = giangVienNew.MaGv;
                taiKhoan.Password = giangVienNew.MaGv;
                taiKhoan.MaRole = 2;
                taiKhoan.TrangThai = 1;

                _context.Add(taiKhoan);
                _context.Add(giangVienNew);

                Save();
                return 1;
            }
            else  // trùng mã không thêm được
            {
                return 0; 
            }

        }

        public IEnumerable<NguoiQt> DanhSachAdmin()
        {
            var danhSachAdmin = _context.NguoiQts.ToList();
            return danhSachAdmin;
        }

        public NguoiQt AdminTheoMa(string maNQT)
        {
            var Admin = _context.NguoiQts.FirstOrDefault(ad => ad.MaNguoiQt.Equals(maNQT));
            return Admin;
        }

        public int ThemMoiAdmin(NguoiQTDTO Admin)
        {
            NguoiQt admin = AdminTheoMa(Admin.MaNguoiQt);   
            if(admin == null)
            {
                string email1 = Admin.MaNguoiQt.ToLower() + "@ptithcm.edu.vn";
                NguoiQt adminNew = new NguoiQt();
                adminNew.MaNguoiQt = Admin.MaNguoiQt;
                adminNew.HoTen = Admin.HoTen;
                adminNew.GioiTinh = Admin.GioiTinh;
                adminNew.NgaySinh = Admin.NgaySinh;
                adminNew.Email1 = email1;
                adminNew.Email2 = Admin.Email2;
                adminNew.Sdt1 = Admin.Sdt1;
                adminNew.Sdt2 = Admin.Sdt2;
                adminNew.QueQuan = Admin.QueQuan;

                //theem tai khoan
                TaiKhoan taiKhoan = new TaiKhoan();
                taiKhoan.TenDn = adminNew.MaNguoiQt;
                taiKhoan.Password = adminNew.MaNguoiQt;
                taiKhoan.MaRole = 1;

                _context.Add(taiKhoan);
                _context.Add(adminNew);
                Save();
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public int XoaSinhVien(string maSV)
        {
            var svHocLTC = _context.SvHocLopTinChis.FirstOrDefault(sv => sv.MaSv.Equals(maSV));
            if(svHocLTC  == null) // Sinh viên chưa đki học lần nào thì có thể xóa được
            {
                SinhVien sinhVien = SinhVienTheoMa(maSV);
                if(sinhVien != null)
                {
                    _context.SinhViens.Remove(sinhVien); // xóa sinh viên trước
                    _context.TaiKhoans.Remove(TaiKhoanTheoTenDN(maSV)); // sau đó xóa tài khoản của sinh viên đó
                    Save();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public int XoaGiangVien(string maGV)
        {
            var ctLTC = _context.CtLopTinChis.FirstOrDefault(ct => ct.MaGv.Equals(maGV));
            if(ctLTC == null) // giảng viên chưa dạy lần nào thì có thể xóa
            {
                GiangVien giangVien = GiangVienTheoMa(maGV);
                if(giangVien != null)
                {
                    _context.GiangViens.Remove(giangVien); // xóa giảng viên trước
                    _context.TaiKhoans.Remove(TaiKhoanTheoTenDN(maGV)); // xóa tài khoản của gv đó
                    Save();
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        public int XoaAdmin(string maNQT)
        {
            var svHocLTC = _context.SvHocLopTinChis.FirstOrDefault(svhltc => svhltc.MaNguoiQt.Equals(maNQT));
            if(svHocLTC == null) // người quản trị chưa tạo lớp học nào thì có thể xóa
            {
                NguoiQt nguoiQt = AdminTheoMa(maNQT);
                if(nguoiQt != null)
                {
                    _context.NguoiQts.Remove(nguoiQt); // xóa admin trước
                    _context.TaiKhoans.Remove(TaiKhoanTheoTenDN(maNQT)); // xóa tài khoản
                    Save();
                    return 1;
                }
                return 0;
                
            }
            return 0;
        }

        public TaiKhoan TaiKhoanTheoTenDN(string tenDN)
        {
            var taiKhoan = _context.TaiKhoans.SingleOrDefault(tk => tk.TenDn.Equals(tenDN));
            return taiKhoan;
        }

        public int TaoDonHang(ThanhToanVnPayDTO donHang)
        {
            ThanhToanVnPay thanhToanVnPay = new ThanhToanVnPay();
            thanhToanVnPay.Amount = donHang.Amount;
            thanhToanVnPay.TrangThai = false;
            _context.Add(thanhToanVnPay);
            Save();
            return 1;
        }

        public IEnumerable<ThanhToanVnPay> DanhSachDonHang()
        {
            var danhSachDonHang = _context.ThanhToanVnPays.ToList();
            return danhSachDonHang;
        }
    }
}
