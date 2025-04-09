using System;
using Newtonsoft.Json;

namespace Razorpay.Models;

public class Orders
{

     [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("entity")]
    public string Entity { get; set; } = string.Empty;

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("amount_paid")]
    public int AmountPaid { get; set; }

    [JsonProperty("amount_due")]
    public int AmountDue { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonProperty("receipt")]
    public string Receipt { get; set; } = string.Empty;

    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

    [JsonProperty("attempts")]
    public int Attempts { get; set; }

    [JsonProperty("created_at")]
    public long CreatedAt { get; set; }

    [JsonProperty("offer_id")]
    public string? OfferId { get; set; }

    [JsonProperty("notes")]
    public Dictionary<string, string>? Notes { get; set; }


}
