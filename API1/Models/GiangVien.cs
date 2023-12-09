using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class GiangVien
    {
        public GiangVien()
        {
            CtLopTinChis = new HashSet<CtLopTinChi>();
        }

        public string MaGv { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string HocHam { get; set; } = null!;
        public string Email1 { get; set; } = null!;
        public string? Email2 { get; set; }
        public string Sdt1 { get; set; } = null!;
        public string? Sdt2 { get; set; }
        public string? QueQuan { get; set; }

        public virtual TaiKhoan MaGvNavigation { get; set; } = null!;
        public virtual ICollection<CtLopTinChi> CtLopTinChis { get; set; }
    }
}
