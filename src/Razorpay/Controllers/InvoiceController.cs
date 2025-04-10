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
    public class InvoiceController : ControllerBase
    {
           private readonly IRazorpayService _razorpayService; 
          private readonly HttpClient _client; 
           private readonly RazorpayConfig _razorpayConfig;

        public InvoiceController(IRazorpayService razorpayService, HttpClient client, IOptions<RazorpayConfig> config)
        {
              _razorpayService = razorpayService; 
            _client = client; 
            _razorpayConfig = config.Value;

              var key = _razorpayConfig.Key ?? throw new ArgumentNullException(nameof(_razorpayConfig.Key)); 
        var secret = _razorpayConfig.Secret ?? throw new ArgumentNullException(nameof(_razorpayConfig.Secret));

        var byteArray = Encoding.ASCII.GetBytes($"{key}:{secret}"); 

        _client = client; 
        _client.BaseAddress = new Uri("https://api.razorpay.com/v1/"); 
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray)); 
        }

          [HttpGet]
        public async Task<ActionResult<List<Invoice>>> GetInvoices()

        {
            var response = await _client.GetAsync("invoices"); 

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            }

            var responseBody = await response.Content.ReadAsStringAsync(); 

             

            return  Ok(responseBody); 


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(string id)
        {
            var response = await _client.GetAsync($"invoices/{id}");

            if (!response.IsSuccessStatusCode)
            
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            var InvoiceJson = JsonConvert.DeserializeObject<Invoice>(responseBody); 

            return Ok(InvoiceJson);       

        }

         [HttpPost]
        public async Task<ActionResult<CreateInvoiceResponseDto>> CreateInvoice(InvoiceDto invoiceDto)
        {
             if (invoiceDto == null) return BadRequest(); 

            var response = await _razorpayService.CreateInvoiceAsync(invoiceDto); 

            if (response == null)
            {
                return BadRequest("Cannot Create invoice"); 
            }

            return Ok(response); 
            
        }
    }
}
