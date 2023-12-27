using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class TaiKhoan
    {
        public string TenDn { get; set; } = null!;
        public string Password { get; set; } = null!;
        public byte TrangThai { get; set; }
        public byte MaRole { get; set; }

        public virtual Role MaRoleNavigation { get; set; } = null!;
        public virtual GiangVien? GiangVien { get; set; }
        public virtual NguoiQt? NguoiQt { get; set; }
        public virtual SinhVien? SinhVien { get; set; }
    }
}
