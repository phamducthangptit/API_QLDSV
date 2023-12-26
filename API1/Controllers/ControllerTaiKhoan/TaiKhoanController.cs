using API1.Data;
using API1.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers.ControllerTaiKhoan
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaiKhoanController : ControllerBase
    {
        private readonly ITaiKhoanRepository _taiKhoanRepository;
        public TaiKhoanController(ITaiKhoanRepository taiKhoanRepository)
        {
            _taiKhoanRepository = taiKhoanRepository;
        }

        [HttpGet("danh-sach-tai-khoan")]
        public IActionResult danhSachTaiKhoan()
        {
            var danhSachTaiKhoan = _taiKhoanRepository.DanhSachTaiKhoan();
            return Ok(danhSachTaiKhoan);
        }

        [HttpGet("danh-sach-tai-khoan-sinh-vien")]
        public IActionResult danhSachTaiKhoanSinhVien()
        {
            var danhSachTaiKhoanSinhVien = _taiKhoanRepository.DanhSachTaiKhoanSinhVien();
            return Ok(danhSachTaiKhoanSinhVien);
        }

        [HttpGet("danh-sach-tai-khoan-giang-vien")]
        public IActionResult danhSachTaiKhoanGiangVien()
        {
            var danhSachTaiKhoanGiangVien = _taiKhoanRepository.DanhSachTaiKhoanGiangVien();
            return Ok(danhSachTaiKhoanGiangVien);
        }

        [HttpGet("danh-sach-tai-khoan-admin")]
        public IActionResult danhSachTaiKhoanAdmin()
        {
            var danhSachTaiKhoanAdmin = _taiKhoanRepository.DanhSachTaiKhoanAdmin();
            return Ok(danhSachTaiKhoanAdmin);
        }

        [HttpGet("tai-khoan/{tenDN}")]
        public IActionResult taiKhoanTheoTenDN(string tenDN)
        {
            var taiKhoan = _taiKhoanRepository.TaiKhoanTheoTenDN(tenDN);
            if(taiKhoan != null)
                return Ok(taiKhoan);
            return BadRequest();
        }

        [HttpPut("doi-mat-khau/{tenDN}")]
        public IActionResult doiMatKhau(string tenDN, string matKhauMoi)
        {
            if (_taiKhoanRepository.ThayDoiMatKhau(tenDN, matKhauMoi) == 1)
                return Ok();
            return BadRequest();
        }

        [HttpPut("thay-doi-trang-thai/{tenDN}")]
        public IActionResult thayDoiTrangThai(string tenDN)
        {
            if(_taiKhoanRepository.CapNhatTrangThaiTaiKhoan(tenDN) == 1)
                return Ok();
            return BadRequest();
        }
    }
}
