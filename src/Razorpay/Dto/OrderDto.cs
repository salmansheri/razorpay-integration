using System;
using Newtonsoft.Json;

namespace Razorpay.Dto;

public class OrderDto
{
    [JsonProperty("amount")]
    public int Amount { get; set; }
    [JsonProperty("currency")]
    public string Currency { get; set; } = "INR";

    [JsonProperty("receipt")]
    public string Receipt { get; set; } = string.Empty;
    

}
