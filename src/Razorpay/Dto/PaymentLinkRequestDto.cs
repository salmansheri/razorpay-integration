using System;
using System.ComponentModel.Design;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Razorpay.Dto;

public class PaymentLinkRequestDto
{
      [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty; 

    [JsonProperty("accept_partial")]
    public bool AcceptPartial { get; set; }

    [JsonProperty("first_min_partial_amount")]
    public int FirstMinPartialAmount { get; set; }

    [JsonProperty("expire_by")]
    public long ExpireBy { get; set; }

    [JsonProperty("reference_id")]
    public string ReferenceId { get; set; } = string.Empty; 
    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty; 
    [JsonProperty("customer")]
    public CustomerDto Customer { get; set; } = new(); 

    [JsonProperty("notify")]
    public RazorpayNotify Notify { get; set; } = new(); 

    [JsonProperty("reminder_enable")]
    public bool ReminderEnable { get; set; }

    [JsonProperty("notes")]
    public Dictionary<string, string> Notes { get; set; } = []; 

    [JsonProperty("callback_url")]
    public string CallbackUrl { get; set; } = string.Empty; 

    [JsonProperty("callback_method")]
    public string CallbackMethod { get; set; } = string.Empty; 

    [JsonProperty("options")]
    public Options options { get; set; } = new(); 

}

public class Options 
{
  [JsonProperty("checkout")]
  public Checkout Checkout { get; set; } = new(); 
}

public class Checkout
{
  public bool Netbanking { get; set; }
  public bool Card { get; set; }
  public bool Upi { get; set; }
  public bool Wallet { get; set;}
}


