using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Razorpay.Configurations;
using Razorpay.Dto;
using Razorpay.Models;
using Razorpay.Services.Interfaces;

namespace Razorpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentLinkController : ControllerBase
    {
        private readonly RazorpayConfig _razorpayConfig;
    private readonly HttpClient _client; 
    private readonly IRazorpayService _razorpayService; 

        public PaymentLinkController(IOptions<RazorpayConfig> razorpayConfig, HttpClient httpClient, IRazorpayService razorpayService)
        {
               _razorpayConfig = razorpayConfig.Value ?? throw new ArgumentNullException(nameof(razorpayConfig));
        var key = _razorpayConfig.Key ?? throw new ArgumentNullException(nameof(_razorpayConfig.Key)); 
        var secret = _razorpayConfig.Secret ?? throw new ArgumentNullException(nameof(_razorpayConfig.Secret));

        var byteArray = Encoding.ASCII.GetBytes($"{key}:{secret}");
        _razorpayService = razorpayService;  

        _client = httpClient; 
        _client.BaseAddress = new Uri("https://api.razorpay.com/v1/"); 
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray)); 
        }


        [HttpGet]
        public async Task<ActionResult<List<PaymentLink>>> GetPaymentLinks()

        {
            var response = await _client.GetAsync("payment_links"); 

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            }

            var responseBody = await response.Content.ReadAsStringAsync(); 

             

            return  Ok(responseBody); 


        }

         [HttpGet("{id}")]
        public async Task<ActionResult<PaymentLink>> GetPaymentLink(string id)

        {
            var response = await _client.GetAsync($"payment_links/{id}"); 

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            }

            var responseBody = await response.Content.ReadAsStringAsync(); 
            var paymentLinkJson = JsonConvert.DeserializeObject<PaymentLink>(responseBody); 

             

            return  Ok(paymentLinkJson); 


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

        [HttpPost("netbanking")]
         public async Task<ActionResult<PaymentLinkWithNetbankingResponseDto>> CreatePaymentLinkWithNetbanking([FromBody] PaymentLinkWithNetBankingRequest paymentLinkDto)
        {
            if (paymentLinkDto is null)
            {
                return BadRequest(); 
            }

            var shortUrl = await _razorpayService.CreateNetbankingPaymentLinkAsync(paymentLinkDto); 

            if (string.IsNullOrEmpty(shortUrl))
            {
                return NotFound(); 
            }

            var response = new { shortUrl}; 
            return Ok(response); 


        }

        [HttpPost("{id}/cancel")]
        public async Task<ActionResult<PaymentLink>> CancelPaymentLink(string id)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return BadRequest();
            }

            var response = await _client.PostAsync($"payment_links/{id}/cancel", new StringContent(""));

            if (!response.IsSuccessStatusCode)
            {
                return  StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());
            } 

            var responseBody = await response.Content.ReadAsStringAsync();
            var paymentLink = JsonConvert.DeserializeObject<PaymentLink>(responseBody);

            return Ok(paymentLink); 

         
        }

        // TODO: Have a look at this after completing everything
        [HttpPatch("{id}")]
        public async Task<ActionResult<PaymentLink>> UpdatePaymentLink(string id, PaymentLinkDto paymentLinkDto)
        {

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Enter Valid Id"); 
            }

            if (paymentLinkDto == null)
            {
                return BadRequest("Invalid Json data"); 
            }
            // var paymentLink = await GetPaymentLink(id); 

            // if (paymentLink == null)
            // {
            //     return NotFound("Payment Link Not found"); 
            // }

            var updatedPaymentLink = new PaymentLinkDto
{
    Amount = paymentLinkDto.Amount,
    Currency = paymentLinkDto.Currency?.Trim() ?? "INR",
    AcceptPartial = paymentLinkDto.AcceptPartial,
    FirstMinPartialAmount = paymentLinkDto.FirstMinPartialAmount,
    ReferenceId = paymentLinkDto.ReferenceId?.Trim() ?? $"REF-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
    Description = paymentLinkDto.Description?.Trim() ?? string.Empty,

    Customer = new CustomerDto
    {
        Name = paymentLinkDto.Customer.Name?.Trim() ?? string.Empty,
        Contact = paymentLinkDto.Customer.Contact?.Trim() ?? string.Empty,
        Email = paymentLinkDto.Customer.Email?.Trim() ?? string.Empty
    },

    Notify = new RazorpayNotify
    {
        Email = paymentLinkDto.Notify.Email,
        Sms = paymentLinkDto.Notify.Sms
    },

    ReminderEnable = paymentLinkDto.ReminderEnable,
    Notes = paymentLinkDto.Notes ,
    CallbackUrl = paymentLinkDto.CallbackUrl?.Trim() ?? string.Empty,
    CallbackMethod = paymentLinkDto.CallbackMethod?.Trim() ?? string.Empty
};

    var json = JsonConvert.SerializeObject(updatedPaymentLink); 
    var content = new StringContent(json, Encoding.UTF8, "application/json"); 

    var response = await _client.PatchAsync($"payment_links/{id}", content); 


    if (!response.IsSuccessStatusCode)
    {
         return  StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());


    }

    var responseBody = await response.Content.ReadAsStringAsync(); 
    var updatedPaymentLinkJson = JsonConvert.DeserializeObject<PaymentLink>(responseBody); 

    return Ok(updatedPaymentLink);             

            
        }

    
     [HttpPost("send/{id}")]
        public async Task<IActionResult> SendPaymentLink(string id)
        {

            if (string.IsNullOrEmpty(id) || string.IsNullOrWhiteSpace(id))
            {
                return BadRequest("Enter Valid PaymentLink Id "); 
            }

            var response = await _client.PostAsync($"payment_links/{id}/notify_by/sms", new StringContent("")); 

            if (!response.IsSuccessStatusCode)
            {
                 return  StatusCode((int)response.StatusCode, await response.Content.ReadAsStringAsync());

            }

            return Ok(); 
            


        }
        


      


       

    }
}
