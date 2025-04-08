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

        [HttpPost("customers")]
        public async Task<ActionResult<CreateCustomerResponseDto>> CreateCustomer([FromBody] RazorpayCustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest(); 
            }

            var response = await _razorpayService.CreateCustomerAsync(customerDto); 

            if (response == null)
            {
                return BadRequest("Cannot Create Customer"); 
            }

            return Ok(response); 
        }

        [HttpPost("orders")]
        public async Task<ActionResult<CreateOrderResponseDto>> CreateOrder(OrderDto orderDto)
        {
            if (orderDto == null) return BadRequest(); 

            var response = await _razorpayService.CreateOrderAsync(orderDto); 

            if (response == null)
            {
                return BadRequest("Cannot Create Order"); 
            }

            return Ok(response); 
        }

        [HttpPost("items")]
        public async Task<ActionResult<CreateItemResponseDto>> CreateItem(ItemDto itemDto)
        {
             if (itemDto == null) return BadRequest(); 

            var response = await _razorpayService.CreateItemAsync(itemDto); 

            if (response == null)
            {
                return BadRequest("Cannot Create Item"); 
            }

            return Ok(response); 
            
        }

    }
}
