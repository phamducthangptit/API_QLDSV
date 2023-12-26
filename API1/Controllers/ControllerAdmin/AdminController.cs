using API1.DTO;
using API1.Interface;
using API1.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API1.Controllers.ControllerAdmin
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminRepository _adminRepository;
        public AdminController(IAdminRepository adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [HttpGet("danh-sach-sinh-vien")]
        public IActionResult DanhSachSinhVien()
        {
            var danhSachSinhVien = _adminRepository.DanhSachSinhVien();
            return Ok(danhSachSinhVien);
        }

        [HttpGet("danh-sach-sinh-vien-theo-lop/{maLop}")]
        public IActionResult DanhSachSinhVienTheoLop(string maLop)
        {
            var danhSachSinhVienTheoLop = _adminRepository.DanhSachSinhVienTheoLop(maLop);
            return Ok(danhSachSinhVienTheoLop);
        }

        [HttpPost("them-sinh-vien")]
        public IActionResult ThemSinhVien([FromBody] SinhVienDTO sinhVien)
        {
            if (_adminRepository.ThemMoiSinhVien(sinhVien) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("danh-sach-giang-vien")]
        public IActionResult DanhSachGiangVien()
        {
            var danhSachGiangVien = _adminRepository.DanhSachGiangVien();
            return Ok(danhSachGiangVien);
        }

        [HttpPost("them-giang-vien")]
        public IActionResult ThemGiangVien([FromBody] GiangVienDTO giangVienDTO)
        {
            if(_adminRepository.ThemMoiGiangVien(giangVienDTO) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("danh-sach-admin")]
        public IActionResult DanhSachAdmin()
        {
            var danhSachAdmin = _adminRepository.DanhSachAdmin();
            return Ok(danhSachAdmin);
        }

        [HttpPost("them-admin")]
        public IActionResult ThemAdmin(NguoiQTDTO nguoiQTDTO)
        {
            if(_adminRepository.ThemMoiAdmin(nguoiQTDTO) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("xoa-sinh-vien/{maSv}")]
        public IActionResult XoaSinhVien(string maSv)
        {
            if(_adminRepository.XoaSinhVien(maSv) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("xoa-giang-vien/{maGv}")]
        public IActionResult XoaGiangVien(string maGv)
        {
            if(_adminRepository.XoaGiangVien(maGv) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("xoa-nguoi-quan-tri/{maNQT}")]
        public IActionResult XoaAdmin(string maNQT)
        {
            if(_adminRepository.XoaAdmin(maNQT) == 1)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
