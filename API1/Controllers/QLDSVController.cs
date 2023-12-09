using API1.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QLDSVController : ControllerBase
    {
        private readonly QLDSVContext _context;

        public QLDSVController(QLDSVContext context)
        {
            _context = context;
        }
        [HttpGet("danh-sach-sinh-vien")]
        public IActionResult GetAllStudent()
        {
            var dsSinhVien = _context.SinhViens.ToList();
            return Ok(dsSinhVien);
        }
    }
}
