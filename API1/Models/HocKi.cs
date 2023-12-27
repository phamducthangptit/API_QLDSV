using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class HocKi
    {
        public HocKi()
        {
            CtLopTinChis = new HashSet<CtLopTinChi>();
        }

        public string MaHk { get; set; } = null!;
        public DateTime NgayBd { get; set; }
        public DateTime NgayKt { get; set; }

        public virtual ICollection<CtLopTinChi> CtLopTinChis { get; set; }
    }
}
