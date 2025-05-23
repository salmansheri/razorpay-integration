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
    public class OrdersController : ControllerBase
    {
             private readonly RazorpayConfig _razorpayConfig;
    private readonly HttpClient _client; 
    private readonly IRazorpayService _razorpayService; 

        public OrdersController(IOptions<RazorpayConfig> razorpayConfig, HttpClient httpClient, IRazorpayService razorpayService)
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
        public async Task<ActionResult<List<Orders>>> GetItems()

        {
            var response = await _client.GetAsync("orders"); 

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            }

            var responseBody = await response.Content.ReadAsStringAsync(); 

             

            return  Ok(responseBody); 


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Orders>> GetItemById(string id)
        {
            var response = await _client.GetAsync($"orders/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            var itemJson = JsonConvert.DeserializeObject<Orders>(responseBody); 

            return Ok(itemJson);       

        }

         [HttpPost]
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
    }
}
