using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class Lop
    {
        public Lop()
        {
            CtLopTinChis = new HashSet<CtLopTinChi>();
            SinhViens = new HashSet<SinhVien>();
        }

        public string MaLop { get; set; } = null!;
        public string TenLop { get; set; } = null!;
        public string MaKh { get; set; } = null!;

        public virtual KhoaHoc MaKhNavigation { get; set; } = null!;
        public virtual ICollection<CtLopTinChi> CtLopTinChis { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
