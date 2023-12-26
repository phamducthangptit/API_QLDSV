using API1.Data;
using API1.Interface;
using API1.Models;

namespace API1.Repository
{
    public class TaiKhoanRepository : ITaiKhoanRepository
    {
        private readonly QLDSVContext _context;
        public TaiKhoanRepository(QLDSVContext context)
        {
            _context = context;
        }

        public int CapNhatTrangThaiTaiKhoan(string tenDN)
        {
            TaiKhoan taiKhoan = TaiKhoanTheoTenDN(tenDN);
            if(taiKhoan != null)
            {
                if (taiKhoan.TrangThai == 1)
                {
                    taiKhoan.TrangThai = 0;
                    Save();
                }
                else
                {
                    taiKhoan.TrangThai = 1;
                    Save();
                }
                return 1;
            }
            return 0;
            
        }

        public IEnumerable<TaiKhoan> DanhSachTaiKhoan()
        {
            var danhSachTaiKhoan = _context.TaiKhoans.ToList();
            return danhSachTaiKhoan;
        }

        public IEnumerable<TaiKhoan> DanhSachTaiKhoanAdmin()
        {
            var danhSachTaiKhoanAdmin = _context.TaiKhoans.Where(tk => tk.MaRole == 1).ToList();
            return danhSachTaiKhoanAdmin;
        }

        public IEnumerable<TaiKhoan> DanhSachTaiKhoanGiangVien()
        {
            var danhSachTaiKhoanGiangVien = _context.TaiKhoans.Where(tk => tk.MaRole == 2).ToList();
            return danhSachTaiKhoanGiangVien;
        }

        public IEnumerable<TaiKhoan> DanhSachTaiKhoanSinhVien()
        {
            var danhSachTaiKhoanSinhVien = _context.TaiKhoans.Where(tk => tk.MaRole == 3).ToList();
            return danhSachTaiKhoanSinhVien;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public TaiKhoan TaiKhoanTheoTenDN(string tenDN)
        {
            var taiKhoan = _context.TaiKhoans.FirstOrDefault(tk => tk.TenDn.Equals(tenDN));
            return taiKhoan;
        }

        public int ThayDoiMatKhau(string tenDN, string matKhauMoi)
        {
            TaiKhoan taiKhoan = TaiKhoanTheoTenDN(tenDN);
            if(taiKhoan == null)
            {
                return 0;
            }
            else
            {
                taiKhoan.Password = matKhauMoi;
                Save();
                return 1;
            }
        }
    }
}
