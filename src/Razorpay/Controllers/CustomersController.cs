using System.Text;
using System.Text.Json;
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
    public class CustomersController : ControllerBase
    {

          private readonly IRazorpayService _razorpayService; 
          private readonly HttpClient _client; 
           private readonly RazorpayConfig _razorpayConfig;

        public CustomersController(IRazorpayService razorpayService, HttpClient client, IOptions<RazorpayConfig> config)
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
        public async Task<ActionResult<List<Customer>>> GetCustomers()

        {
            var response = await _client.GetAsync("customers"); 

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            }

            var responseBody = await response.Content.ReadAsStringAsync(); 

             

            return  Ok(responseBody); 


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerById(string id)
        {
            var response = await _client.GetAsync($"customers/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            var customerJson = JsonConvert.DeserializeObject<Customer>(responseBody); 

            return Ok(customerJson);       

        }

          [HttpPost]
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
    }
}
