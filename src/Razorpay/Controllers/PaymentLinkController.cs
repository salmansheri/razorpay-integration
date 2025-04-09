using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Dto;
using Razorpay.Services.Interfaces;

namespace Razorpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentLinkController : ControllerBase
    {
        private readonly IRazorpayService _razorpayService; 

        public PaymentLinkController(IRazorpayService razorpayService)
        {
            _razorpayService = razorpayService; 
        }

        [HttpPost("standard")]
        public async Task<ActionResult<CreatePaymentLinkDto>> CreatePaymentLinkStandard([FromBody] PaymentLinkDto paymentLinkDto)
        {
            if (paymentLinkDto is null)
            {
                return BadRequest(); 
            }

            var shortUrl = await _razorpayService.CreatePaymentLinkAsync(paymentLinkDto); 

            if (string.IsNullOrEmpty(shortUrl))
            {
                return NotFound(); 
            }

            var response = new { shortUrl}; 
            return Ok(response); 


        }

      


       

    }
}
