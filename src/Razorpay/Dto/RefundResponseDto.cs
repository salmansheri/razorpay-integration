using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Razorpay.Dto;

public class RefundResponseDto
{

    [JsonProperty("acquirer_data")]
    public AcquirerDataRefundDto AcquirerData { get; set; } = new();

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("base_amount")]
    public int BaseAmount { get; set; }

    [JsonProperty("batch_id")]
    public string BatchId { get; set; } = string.Empty;

    [JsonProperty("created_at")]
    public long CreatedAt { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonProperty("entity")]
    public string Entity { get; set; } = string.Empty;

    [JsonProperty("id")]
    public string Id { get; set; } = string.Empty;

    [JsonProperty("notes")]
    public JToken Notes { get; set; } = JValue.CreateNull();

    [JsonProperty("payment_id")]
    public string PaymentId { get; set; } = string.Empty;

    [JsonProperty("receipt")]
    public string Receipt { get; set; } = string.Empty;

    [JsonProperty("speed_processed")]
    public string SpeedProcessed { get; set; } = string.Empty;

    [JsonProperty("speed_requested")]
    public string SpeedRequested { get; set; } = string.Empty;

    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty;

}

public class AcquirerDataRefundDto
{
    [JsonProperty("rrn")]
    public string Rrn { get; set; } = string.Empty;
}
