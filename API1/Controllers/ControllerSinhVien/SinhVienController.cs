using API1.DTO;
using API1.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers.ControllerSinhVien
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        private readonly ISinhVienRepository _sinhVienRepository;
        public SinhVienController(ISinhVienRepository sinhVienRepository)
        {
            _sinhVienRepository = sinhVienRepository;
        }

        [HttpGet("sinh-vien-theo-ma/{maSV}")]
        public IActionResult SinhVienTheoMa(string maSV)
        {
            var sinhVien = _sinhVienRepository.SinhVienTheoMa(maSV);
            if(sinhVien != null)
                return Ok(sinhVien);
            return BadRequest();
        }

        [HttpPut("thay-doi-thong-tin-sinh-vien/{maSV}")]
        public IActionResult ThayDoiThongTinSV(string maSV, string email2, string sdt2)
        {
            if(_sinhVienRepository.ThayDoiThongTinSinhVien(maSV, email2, sdt2) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
