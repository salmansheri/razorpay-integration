using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Razorpay.Configurations;
using Razorpay.Dto;

namespace Razorpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
         private readonly RazorpayConfig _razorpayConfig;
    private readonly HttpClient _client; 
     

     public PaymentController(IOptions<RazorpayConfig> razorpayConfig, HttpClient httpClient)
        {
               _razorpayConfig = razorpayConfig.Value ?? throw new ArgumentNullException(nameof(razorpayConfig));
        var key = _razorpayConfig.Key ?? throw new ArgumentNullException(nameof(_razorpayConfig.Key)); 
        var secret = _razorpayConfig.Secret ?? throw new ArgumentNullException(nameof(_razorpayConfig.Secret));

        var byteArray = Encoding.ASCII.GetBytes($"{key}:{secret}");
         

        _client = httpClient; 
        _client.BaseAddress = new Uri("https://api.razorpay.com/v1/"); 
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray)); 
        }

         [HttpGet]
        public async Task<ActionResult<List<PaymentResponseDto>>> GetPayments()

        {
            var response = await _client.GetAsync("payments"); 

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            }

            var responseBody = await response.Content.ReadAsStringAsync(); 

             

            return  Ok(responseBody); 


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentResponseDto>> GetPaymentById(string id)
        {
            var response = await _client.GetAsync($"payments/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            var itemJson = JsonConvert.DeserializeObject<PaymentResponseDto>(responseBody); 

            return Ok(itemJson);       

        }

         [HttpGet("based-on-orders/{orderId}")]
        public async Task<ActionResult<PaymentResponseDto>> GetPaymentBasedOnOrderByOrderId(string orderId)
        {
            var response = await _client.GetAsync($"orders/{orderId}/payments");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            var itemJson = JsonConvert.DeserializeObject<PaymentResponseDto>(responseBody); 

            return Ok(itemJson);       

        }

    
    }

    
}
