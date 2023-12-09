using API1.Data;
using API1.DTO;
using API1.Interface;
using API1.Models;

namespace API1.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly QLDSVContext _context;

        public SinhVienRepository( QLDSVContext context)
        {
            _context = context;
        }
        public IEnumerable<SinhVien> danhSachSinhVien()
        {
            var danhSachSinhVien = _context.SinhViens.ToList();
            return danhSachSinhVien;

        }

        public IEnumerable<SinhVien> danhSachSinhVienTheoLop(string maLop)
        {
            var danhSachSinhVienTheoLop = _context.SinhViens.Where(sv => sv.MaLop.Equals(maLop)).ToList();
            return danhSachSinhVienTheoLop;
        }

        public SinhVien sinhVienTheoMa(string maSV)
        {
            var danhSachSinhVienTheoMa = _context.SinhViens.FirstOrDefault(sv => sv.MaSv.Equals(maSV));
            return danhSachSinhVienTheoMa;
        }

        public int thayDoiThongTinSinhVien(string maSV, SinhVienDTO s)
        {
            SinhVien sinhVien = sinhVienTheoMa(maSV);
            if (sinhVien != null)
            {
                sinhVien.Email2 = s.email2;
                sinhVien.Sdt2 = s.sdt2;
                Save();
                return 1;
            }
            else
                return 0;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
