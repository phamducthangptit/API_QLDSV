using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class SvHocLopTinChi
    {
        public byte Idct { get; set; }
        public byte Id { get; set; }
        public string MaSv { get; set; } = null!;
        public double? DiemCc { get; set; }
        public double? DiemKt { get; set; }
        public double? DiemTh { get; set; }
        public double? DiemSe { get; set; }
        public double? DiemThi { get; set; }
        public double? TongKet { get; set; }
        public int? TrangThai { get; set; }
        public string? MaNguoiQt { get; set; }

        public virtual CtLopTinChi IdNavigation { get; set; } = null!;
        public virtual NguoiQt? MaNguoiQtNavigation { get; set; }
        public virtual SinhVien MaSvNavigation { get; set; } = null!;
    }
}
