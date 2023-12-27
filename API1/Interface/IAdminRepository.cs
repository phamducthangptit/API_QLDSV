using API1.DTO;
using API1.Models;

namespace API1.Interface
{
    public interface IAdminRepository
    {
        TaiKhoan TaiKhoanTheoTenDN(string tenDN);
        IEnumerable<SinhVien> DanhSachSinhVien();
        IEnumerable<SinhVien> DanhSachSinhVienTheoLop(string maLop);
        SinhVien SinhVienTheoMa(string maSV);
        int ThemMoiSinhVien(SinhVienDTO sinhVien);
        int XoaSinhVien(string maSV);

        IEnumerable<GiangVien> DanhSachGiangVien();
        GiangVien GiangVienTheoMa(string maGV);
        int ThemMoiGiangVien(GiangVienDTO giangVien);
        int XoaGiangVien(string maGV);

        IEnumerable<NguoiQt> DanhSachAdmin();
        NguoiQt AdminTheoMa(string maNQT);
        int ThemMoiAdmin(NguoiQTDTO Admin);
        int XoaAdmin(string maNQT);

        int TaoDonHang(ThanhToanVnPayDTO donHang);

        IEnumerable<ThanhToanVnPay> DanhSachDonHang();

        void Save();
    }
}
