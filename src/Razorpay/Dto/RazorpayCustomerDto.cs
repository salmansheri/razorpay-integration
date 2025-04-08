using System;
using Newtonsoft.Json;

namespace Razorpay.Dto;

public class RazorpayCustomerDto
{
  [JsonProperty("name")]
    public string Name { get; set; } = string.Empty;

    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty;

    [JsonProperty("contact")]
    public string Contact { get; set; } = string.Empty;

    [JsonProperty("fail_existing")]
    public int Fail_existing { get; set; } 

    [JsonProperty("gstin")]
    public string Gstin { get; set; } = string.Empty; 
    


}
