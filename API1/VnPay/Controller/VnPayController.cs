using API1.Data;
using API1.VnPay.Services;
using API1.VnPay.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace API1.VnPay.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class VnPayController : ControllerBase
    {
        private readonly QLDSVContext _context;
        private readonly IVnPayServices _vnPayService;

        public VnPayController(QLDSVContext context, IVnPayServices vnPayServices) 
        {
            _context = context;
            _vnPayService = vnPayServices;
        }

        [HttpPost("thanh-toan-don-hang/{id}")]
        public IActionResult ThanhToanDonHang(int id)
        {
            var donHang = _context.ThanhToanVnPays.FirstOrDefault(dh => dh.Id == id);
            if(donHang != null && donHang.TrangThai == false) // khác null và chưa thanh toán
            {
                var vnPayModel = new VnPaymentRequestModel
                {
                    Amount = donHang.Amount,
                    CreatedDate = DateTime.Now,
                    Description = $"Thanh toán đơn hàng {id}",
                    FullName = "Phạm Đức Thắng",
                    OrderId = id,
                };
                return Ok(_vnPayService.CreatePaymentUrl(HttpContext, vnPayModel));
            } else return BadRequest();
        }

        [HttpGet("PaymentCallBack")]
        public IActionResult PaymentBack()
        {
            var response = _vnPayService.PaymentExcute(Request.Query);
            // thanh toán không thành công
            if (response == null || response.VnPayResponseCode != "00")
            {
                return BadRequest(response.VnPayResponseCode);
            }

            //thanh toán thành công
            string s = response.OrderDescription;
            string[] s1 = s.Split(":");
            int id = int.Parse(s1[1]);
            var donHang = _context.ThanhToanVnPays.FirstOrDefault(dh => dh.Id == id);
            donHang.TrangThai = true;
            _context.ThanhToanVnPays.Update(donHang);
            _context.SaveChanges();
            return Ok();
        }
    }
}
