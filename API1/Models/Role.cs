using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class Role
    {
        public Role()
        {
            TaiKhoans = new HashSet<TaiKhoan>();
        }

        public byte MaRole { get; set; }
        public string TenRole { get; set; } = null!;

        public virtual ICollection<TaiKhoan> TaiKhoans { get; set; }
    }
}
