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

        [HttpGet("danh-sach-sinh-vien")]
        public IActionResult danhSachSinhVien()
        {
            var danhSachSinhVien = _sinhVienRepository.danhSachSinhVien();
            return Ok(danhSachSinhVien);
        }

        [HttpGet("danh-sach-sinh-vien-theo-lop/{maLop}")]
        public IActionResult danhSachSinhVienTheoLop(string maLop)
        {
            var danhSachSinhVienTheoLop = _sinhVienRepository.danhSachSinhVienTheoLop(maLop);
            return Ok(danhSachSinhVienTheoLop);
        }

        [HttpGet("sinh-vien-theo-ma/{maSV}")]
        public IActionResult sinhVienTheoMa(string maSV)
        {
            var sinhVien = _sinhVienRepository.sinhVienTheoMa(maSV);
            if(sinhVien != null)
                return Ok(sinhVien);
            return BadRequest();
        }

        [HttpPut("thay-doi-thong-tin-sinh-vien/{maSV}")]
        public IActionResult thayDoiThongTinSV(string maSV, SinhVienDTO s)
        {
            if(_sinhVienRepository.thayDoiThongTinSinhVien(maSV, s) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

    }
}
