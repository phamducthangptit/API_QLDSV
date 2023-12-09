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
            var danhSachTaiKhoan = _taiKhoanRepository.danhSachTaiKhoan();
            return Ok(danhSachTaiKhoan);
        }

        [HttpGet("danh-sach-tai-khoan-sinh-vien")]
        public IActionResult danhSachTaiKhoanSinhVien()
        {
            var danhSachTaiKhoanSinhVien = _taiKhoanRepository.danhSachTaiKhoanSinhVien();
            return Ok(danhSachTaiKhoanSinhVien);
        }

        [HttpGet("danh-sach-tai-khoan-giang-vien")]
        public IActionResult danhSachTaiKhoanGiangVien()
        {
            var danhSachTaiKhoanGiangVien = _taiKhoanRepository.danhSachTaiKhoanGiangVien();
            return Ok(danhSachTaiKhoanGiangVien);
        }

        [HttpGet("danh-sach-tai-khoan-admin")]
        public IActionResult danhSachTaiKhoanAdmin()
        {
            var danhSachTaiKhoanAdmin = _taiKhoanRepository.danhSachTaiKhoanAdmin();
            return Ok(danhSachTaiKhoanAdmin);
        }

        [HttpGet("tai-khoan/{tenDN}")]
        public IActionResult taiKhoanTheoTenDN(string tenDN)
        {
            var taiKhoan = _taiKhoanRepository.taiKhoanTheoTenDN(tenDN);
            if(taiKhoan != null)
                return Ok(taiKhoan);
            return BadRequest();
        }

        [HttpPut("doi-mat-khau/{tenDN}/{matKhauMoi}")]
        public IActionResult doiMatKhau(string tenDN, string matKhauMoi)
        {
            if (_taiKhoanRepository.thayDoiMatKhau(tenDN, matKhauMoi) == 1)
                return Ok();
            return BadRequest();
        }

        [HttpPut("thay-doi-trang-thai/{tenDN}")]
        public IActionResult thayDoiTrangThai(string tenDN)
        {
            if(_taiKhoanRepository.capNhatTrangThaiTaiKhoan(tenDN) == 1)
                return Ok();
            return BadRequest();
        }

        [HttpDelete("xoa-tai-khoan/{tenDN}")]
        public IActionResult xoaTaiKhoan(string tenDN)
        {
            if(_taiKhoanRepository.xoaTaiKhoan(tenDN) == 1)
                return Ok();
            return BadRequest();
        }
    }
}
