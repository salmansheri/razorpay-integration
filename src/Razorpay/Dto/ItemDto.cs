using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Razorpay.Dto;

public class ItemDto
{

    [JsonProperty("name")]
      public string Name { get; set; } = string.Empty;
      [JsonProperty("description")]
      public string Description { get; set; } = string.Empty;

      [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = "INR";

}
