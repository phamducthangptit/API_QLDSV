﻿namespace API1.DTO
{
    public class SinhVienDTO
    {
        public string MaSv { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public string? GioiTinh { get; set; }
        public DateTime? NgaySinh { get; set; }
        //public string Email1 { get; set; } = null!;
        public string? Email2 { get; set; }
        public string Sdt1 { get; set; } = null!;
        public string? Sdt2 { get; set; }
        public string? QueQuan { get; set; }
        public string MaLop { get; set; } = null!;
    }
}
