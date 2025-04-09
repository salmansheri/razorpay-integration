using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Razorpay.Services.Interfaces;

namespace Razorpay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
            private readonly IRazorpayService _razorpayService; 

        public InvoiceController(IRazorpayService razorpayService)
        {
            _razorpayService = razorpayService; 
        }
    }
}
