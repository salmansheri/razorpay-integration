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
    public class RefundController : ControllerBase
    {
         private readonly RazorpayConfig _razorpayConfig;
    private readonly HttpClient _client; 
     

     public RefundController(IOptions<RazorpayConfig> razorpayConfig, HttpClient httpClient)
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
        public async Task<ActionResult<RefundResponseDto>> GetAllRefunds()
        {
             var response = await _client.GetAsync($"refunds");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            // var refundsJson = JsonConvert.DeserializeObject<PaymentResponseDto>(responseBody); 

            return Ok(responseBody);       

        }
        
        [HttpGet("{id}")]
         public async Task<ActionResult<RefundResponseDto>> GetRefundById(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Invalid Refund Id"); 
            }
             var response = await _client.GetAsync($"refunds/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            var refundsJson = JsonConvert.DeserializeObject<RefundResponseDto>(responseBody); 

            return Ok(refundsJson);       

        }

        [HttpPost("{paymentId}")]
        public async Task<ActionResult<RefundResponseDto>> CreateRefund(string paymentId, RefundRequestDto request)
        {
             if (string.IsNullOrEmpty(paymentId) || string.IsNullOrWhiteSpace(paymentId))
            {
                return BadRequest("Invalid Payment Id"); 
            }

            var json = JsonConvert.SerializeObject(request); 

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync($"payments/{paymentId}/refunds", content); 

            if (!response.IsSuccessStatusCode)
            {
                return StatusCode((int)response.StatusCode); 
            }

            var responseBody = await response.Content.ReadAsStringAsync();

            var refundJson = JsonConvert.DeserializeObject<RefundResponseDto>(responseBody);

            return Ok(refundJson); 
            

        }

    
    }
}
