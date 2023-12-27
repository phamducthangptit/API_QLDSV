using System;
using System.Collections.Generic;

namespace API1.Models
{
    public partial class ThanhToanVnPay
    {
        public int Id { get; set; }
        public double Amount { get; set; }

        public bool TrangThai { get; set; }
    }
}
