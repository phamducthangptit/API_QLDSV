using API1.DTO;
using API1.Models;

namespace API1.Interface
{
    public interface IAdminRepository
    {
        IEnumerable<SinhVien> DanhSachSinhVien();
        IEnumerable<SinhVien> DanhSachSinhVienTheoLop(string maLop);
        SinhVien SinhVienTheoMa(string maSV);
        int ThemMoiSinhVien(SinhVienDTO sinhVien);

        IEnumerable<GiangVien> DanhSachGiangVien();
        GiangVien GiangVienTheoMa(string maGV);
        int ThemMoiGiangVien(GiangVienDTO giangVien);

        IEnumerable<NguoiQt> DanhSachAdmin();
        NguoiQt AdminTheoMa(string maNQT);
        int ThemMoiAdmin(NguoiQTDTO Admin);

        void Save();
    }
}
