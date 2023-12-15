namespace API1.DTO
{
    public class GiangVienDTO
    {
        public string MaGv { get; set; } = null!;
        public string HoTen { get; set; } = null!;
        public DateTime? NgaySinh { get; set; }
        public string? GioiTinh { get; set; }
        public string HocHam { get; set; } = null!;
        //public string Email1 { get; set; } = null!;
        public string? Email2 { get; set; }
        public string Sdt1 { get; set; } = null!;
        public string? Sdt2 { get; set; }
        public string? QueQuan { get; set; }
    }
}
