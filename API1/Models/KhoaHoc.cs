using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class KhoaHoc
    {
        public KhoaHoc()
        {
            Lops = new HashSet<Lop>();
        }

        public string MaKh { get; set; } = null!;
        public int NamBd { get; set; }
        public int NamKt { get; set; }

        public virtual ICollection<Lop> Lops { get; set; }
    }
}
