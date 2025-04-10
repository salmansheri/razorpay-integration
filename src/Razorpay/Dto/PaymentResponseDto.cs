using System;
using Newtonsoft.Json;

namespace Razorpay.Dto;

public class PaymentResponseDto
{
     [JsonProperty("id")]
    public string Id { get; set; } = string.Empty; 

    [JsonProperty("entity")]
    public string Entity { get; set; } = string.Empty; 

    [JsonProperty("amount")]
    public int Amount { get; set; }

    [JsonProperty("currency")]
    public string Currency { get; set; } = string.Empty; 

    [JsonProperty("status")]
    public string Status { get; set; } = string.Empty; 

    [JsonProperty("order_id")]
    public string OrderId { get; set; } = string.Empty; 

    [JsonProperty("invoice_id")]
    public string InvoiceId { get; set; } = string.Empty; 

    [JsonProperty("international")]
    public bool International { get; set; }

    [JsonProperty("method")]
    public string Method { get; set; } = string.Empty; 

    [JsonProperty("amount_refunded")]
    public int AmountRefunded { get; set; }

    [JsonProperty("refund_status")]
    public string RefundStatus { get; set; } = string.Empty; 

    [JsonProperty("captured")]
    public bool Captured { get; set; }

    [JsonProperty("description")]
    public string Description { get; set; } = string.Empty; 

    [JsonProperty("card_id")]
    public string CardId { get; set; } = string.Empty; 

    [JsonProperty("bank")]
    public string Bank { get; set; } = string.Empty; 

    [JsonProperty("wallet")]
    public string Wallet { get; set; } = string.Empty; 

    [JsonProperty("vpa")]
    public string Vpa { get; set; } = string.Empty; 

    [JsonProperty("email")]
    public string Email { get; set; } = string.Empty; 

    [JsonProperty("contact")]
    public string Contact { get; set; } = string.Empty; 

    [JsonProperty("notes")]
    public NotesDto Notes { get; set; } = new(); 

    [JsonProperty("fee")]
    public int Fee { get; set; }

    [JsonProperty("tax")]
    public int Tax { get; set; }

    [JsonProperty("error_code")]
    public string ErrorCode { get; set; } = string.Empty; 

    [JsonProperty("error_description")]
    public string ErrorDescription { get; set; } = string.Empty; 

    [JsonProperty("error_source")]
    public string ErrorSource { get; set; } = string.Empty; 

    [JsonProperty("error_step")]
    public string ErrorStep { get; set; } = string.Empty; 

    [JsonProperty("error_reason")]
    public string ErrorReason { get; set; } = string.Empty; 

    [JsonProperty("acquirer_data")]
    public AcquirerDataDto AcquirerData { get; set; } = new(); 

    [JsonProperty("created_at")]
    public long CreatedAt { get; set; }

    [JsonProperty("upi")]
    public UpiDto Upi { get; set; } = new(); 

}

public class NotesDto
{
    [JsonProperty("policy_name")]
    public string PolicyName { get; set; } = string.Empty;
}

public class AcquirerDataDto
{
    [JsonProperty("rrn")]
    public string Rrn { get; set; } = string.Empty; 

    [JsonProperty("upi_transaction_id")]
    public string UpiTransactionId { get; set; } = string.Empty; 
}

public class UpiDto
{
    [JsonProperty("vpa")]
    public string Vpa { get; set; } = string.Empty; 
}
