using API1.Models;

namespace API1.Interface
{
    public interface ITaiKhoanRepository
    {
        IEnumerable<TaiKhoan> DanhSachTaiKhoan();

        IEnumerable<TaiKhoan> DanhSachTaiKhoanSinhVien();

        IEnumerable<TaiKhoan> DanhSachTaiKhoanGiangVien();

        IEnumerable<TaiKhoan> DanhSachTaiKhoanAdmin();

        TaiKhoan TaiKhoanTheoTenDN(string tenDN);
        int CapNhatTrangThaiTaiKhoan(string tenDN);
        int ThayDoiMatKhau(string tenDN, string matKhauMoi);

        void Save();
    }
}
