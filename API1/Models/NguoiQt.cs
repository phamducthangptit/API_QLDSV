using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class NguoiQt
    {
        public NguoiQt()
        {
            SvHocLopTinChis = new HashSet<SvHocLopTinChi>();
        }

        public string MaNguoiQt { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        public string Email1 { get; set; } = null!;
        public string? Email2 { get; set; }
        public string Sdt1 { get; set; } = null!;
        public string? Sdt2 { get; set; }
        public string? QueQuan { get; set; }

        public virtual TaiKhoan MaNguoiQtNavigation { get; set; } = null!;
        public virtual ICollection<SvHocLopTinChi> SvHocLopTinChis { get; set; }
    }
}
