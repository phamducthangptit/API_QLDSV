using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class MonHoc
    {
        public MonHoc()
        {
            CtLopTinChis = new HashSet<CtLopTinChi>();
        }

        public string MaMh { get; set; } = null!;
        public string TenMh { get; set; } = null!;
        public byte Stc { get; set; }
        public byte? Stchp { get; set; }
        public byte? PhanTramDiemCc { get; set; }
        public byte? PhanTramDiemKt { get; set; }
        public byte? PhanTramDiemTh { get; set; }
        public byte? PhanTramDiemSe { get; set; }
        public byte? PhanTramDiemThi { get; set; }

        public virtual ICollection<CtLopTinChi> CtLopTinChis { get; set; }
    }
}
