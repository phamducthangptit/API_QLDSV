using API1.DTO;
using API1.Models;

namespace API1.Interface
{
    public interface ISinhVienRepository
    {  
        int ThayDoiThongTinSinhVien(string maSV, string email2, string sdt2);
        SinhVien SinhVienTheoMa(string maSV);
        void Save();
    }
}
