using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class CtLopTinChi
    {
        public CtLopTinChi()
        {
            SvHocLopTinChis = new HashSet<SvHocLopTinChi>();
        }

        public byte Id { get; set; }
        public byte MaNhom { get; set; }
        public string MaHk { get; set; } = null!;
        public string MaLop { get; set; } = null!;
        public string MaMh { get; set; } = null!;
        public DateTime NgayBdhoc { get; set; }
        public DateTime NgayKthoc { get; set; }
        public int SltoiDa { get; set; }
        public int SlthucTeDk { get; set; }
        public byte? TrangThai { get; set; }
        public string? MaGv { get; set; }

        public virtual GiangVien? MaGvNavigation { get; set; }
        public virtual HocKi MaHkNavigation { get; set; } = null!;
        public virtual Lop MaLopNavigation { get; set; } = null!;
        public virtual MonHoc MaMhNavigation { get; set; } = null!;
        public virtual ICollection<SvHocLopTinChi> SvHocLopTinChis { get; set; }
    }
}
