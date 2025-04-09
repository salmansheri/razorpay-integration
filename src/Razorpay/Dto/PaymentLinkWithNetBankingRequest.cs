using System;
using Newtonsoft.Json;

namespace Razorpay.Dto;

public class PaymentLinkWithNetBankingRequest
{
     [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = "INR"; 

    [JsonProperty("accept_partial")]
    public bool AcceptPartial { get; set; }

    [JsonProperty("first_min_partial_amount")]
    public int FirstMinPartialAmount { get; set; }

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

    [JsonProperty("options")]
    public OptionsDtoWithNetbanking Options { get; set; } = new(); 

}

public class OptionsDtoWithNetbanking
{
    [JsonProperty("order")]
    public OrderDtoWithNetBanking Order { get; set; } = new(); 
}

public class OrderDtoWithNetBanking
{
    [JsonProperty("method")]
    public string Method { get; set; } = string.Empty; 

    [JsonProperty("bank_account")]
    public BankAccountDto BankAccount { get; set; } = new(); 
}

public class BankAccountDto
{
    [JsonProperty("account_number")]
    public string AccountNumber { get; set; } = string.Empty; 

    [JsonProperty("name")]
    public string Name { get; set; }  = string.Empty; 

    [JsonProperty("ifsc")]
    public string Ifsc { get; set; } = string.Empty; 
}
