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
    public class ItemsController : ControllerBase
    {
             private readonly IRazorpayService _razorpayService; 
          private readonly HttpClient _client; 
           private readonly RazorpayConfig _razorpayConfig;

        public ItemsController(IRazorpayService razorpayService, HttpClient client, IOptions<RazorpayConfig> config)
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
        public async Task<ActionResult<List<Item>>> GetItems()

        {
            var response = await _client.GetAsync("items"); 

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            }

            var responseBody = await response.Content.ReadAsStringAsync(); 

             

            return  Ok(responseBody); 


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Item>> GetItemById(string id)
        {
            var response = await _client.GetAsync($"items/{id}");

            if (!response.IsSuccessStatusCode)
            {
                return BadRequest(); 
            } 

            var responseBody = await response.Content.ReadAsStringAsync(); 

            var itemJson = JsonConvert.DeserializeObject<Customer>(responseBody); 

            return Ok(itemJson);       

        }

         [HttpPost]
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
