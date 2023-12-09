using API1.Models;

namespace API1.Interface
{
    public interface ITaiKhoanRepository
    {
        IEnumerable<TaiKhoan> danhSachTaiKhoan();

        IEnumerable<TaiKhoan> danhSachTaiKhoanSinhVien();

        IEnumerable<TaiKhoan> danhSachTaiKhoanGiangVien();

        IEnumerable<TaiKhoan> danhSachTaiKhoanAdmin();

        TaiKhoan taiKhoanTheoTenDN(string tenDN);
        int capNhatTrangThaiTaiKhoan(string tenDN);
        int thayDoiMatKhau(string tenDN, string matKhauMoi);

        int xoaTaiKhoan(string tenDN);

        void Save();
    }
}
