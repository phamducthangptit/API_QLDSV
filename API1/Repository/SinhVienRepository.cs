using API1.Data;
using API1.DTO;
using API1.Interface;
using API1.Models;

namespace API1.Repository
{
    public class SinhVienRepository : ISinhVienRepository
    {
        private readonly QLDSVContext _context;
        public SinhVienRepository(QLDSVContext context)
        {
            _context = context;
        }

        public SinhVien SinhVienTheoMa(string maSV)
        {
            var danhSachSinhVienTheoMa = _context.SinhViens.FirstOrDefault(sv => sv.MaSv.Equals(maSV));
            return danhSachSinhVienTheoMa;
        }

        public int ThayDoiThongTinSinhVien(string maSV, string email2, string sdt2)
        {
            SinhVien sinhVien = SinhVienTheoMa(maSV);
            if (sinhVien != null)
            {
                sinhVien.Email2 = email2;
                sinhVien.Sdt2 = sdt2;
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
