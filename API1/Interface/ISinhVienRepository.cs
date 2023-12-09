using API1.DTO;
using API1.Models;

namespace API1.Interface
{
    public interface ISinhVienRepository
    {
        IEnumerable<SinhVien> danhSachSinhVien();
        IEnumerable<SinhVien> danhSachSinhVienTheoLop(string maLop);
        SinhVien sinhVienTheoMa(string maSV);

        int thayDoiThongTinSinhVien(string maSV, SinhVienDTO s);

        void Save();
    }
}
