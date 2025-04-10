using System;
using Newtonsoft.Json;

namespace Razorpay.Models;

public class Invoice
{
     [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("entity")]
        public string Entity { get; set; } = string.Empty;

        [JsonProperty("receipt")]
        public string? Receipt { get; set; }

        [JsonProperty("invoice_number")]
        public string? InvoiceNumber { get; set; }

        [JsonProperty("customer_id")]
        public string CustomerId { get; set; } = string.Empty;

        [JsonProperty("customer_details")]
        public CustomerDetails CustomerDetails { get; set; } = new();

        [JsonProperty("order_id")]
        public string OrderId { get; set; } = string.Empty;

        [JsonProperty("line_items")]
        public List<LineItem> LineItems { get; set; } = new();

        [JsonProperty("payment_id")]
        public string? PaymentId { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("expire_by")]
        public long? ExpireBy { get; set; }

        [JsonProperty("issued_at")]
        public long IssuedAt { get; set; }

        [JsonProperty("paid_at")]
        public long? PaidAt { get; set; }

        [JsonProperty("cancelled_at")]
        public long? CancelledAt { get; set; }

        [JsonProperty("expired_at")]
        public long? ExpiredAt { get; set; }

        [JsonProperty("sms_status")]
        public string SmsStatus { get; set; } = string.Empty;

        [JsonProperty("email_status")]
        public string EmailStatus { get; set; } = string.Empty;

        [JsonProperty("date")]
        public long Date { get; set; }

        [JsonProperty("terms")]
        public string? Terms { get; set; }

        [JsonProperty("partial_payment")]
        public bool PartialPayment { get; set; }

        [JsonProperty("gross_amount")]
        public int GrossAmount { get; set; }

        [JsonProperty("tax_amount")]
        public int TaxAmount { get; set; }

        [JsonProperty("taxable_amount")]
        public int TaxableAmount { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("amount_paid")]
        public int AmountPaid { get; set; }

        [JsonProperty("amount_due")]
        public int AmountDue { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("currency_symbol")]
        public string CurrencySymbol { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("notes")]
        public List<object> Notes { get; set; } = new();

        [JsonProperty("comment")]
        public string? Comment { get; set; }

        [JsonProperty("short_url")]
        public string ShortUrl { get; set; } = string.Empty;

        [JsonProperty("view_less")]
        public bool ViewLess { get; set; }

        [JsonProperty("billing_start")]
        public long? BillingStart { get; set; }

        [JsonProperty("billing_end")]
        public long? BillingEnd { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("group_taxes_discounts")]
        public bool GroupTaxesDiscounts { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("idempotency_key")]
        public string? IdempotencyKey { get; set; }

        [JsonProperty("ref_num")]
        public string? RefNum { get; set; }
    }

public class CustomerDetails
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;

        [JsonProperty("contact")]
        public string Contact { get; set; } = string.Empty;

        [JsonProperty("gstin")]
        public string? Gstin { get; set; }

        [JsonProperty("billing_address")]
        public string? BillingAddress { get; set; }

        [JsonProperty("shipping_address")]
        public string? ShippingAddress { get; set; }

        [JsonProperty("customer_name")]
        public string CustomerName { get; set; } = string.Empty;

        [JsonProperty("customer_email")]
        public string CustomerEmail { get; set; } = string.Empty;

        [JsonProperty("customer_contact")]
        public string CustomerContact { get; set; } = string.Empty;
    }
public class LineItem
    {
        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("item_id")]
        public string ItemId { get; set; } = string.Empty;

        [JsonProperty("ref_id")]
        public string? RefId { get; set; }

        [JsonProperty("ref_type")]
        public string? RefType { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("unit_amount")]
        public int UnitAmount { get; set; }

        [JsonProperty("gross_amount")]
        public int GrossAmount { get; set; }

        [JsonProperty("tax_amount")]
        public int TaxAmount { get; set; }

        [JsonProperty("taxable_amount")]
        public int TaxableAmount { get; set; }

        [JsonProperty("net_amount")]
        public int NetAmount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("tax_inclusive")]
        public bool TaxInclusive { get; set; }

        [JsonProperty("hsn_code")]
        public string? HsnCode { get; set; }

        [JsonProperty("sac_code")]
        public string? SacCode { get; set; }

        [JsonProperty("tax_rate")]
        public string? TaxRate { get; set; }

        [JsonProperty("unit")]
        public string? Unit { get; set; }

        [JsonProperty("quantity")]
        public int Quantity { get; set; }

        [JsonProperty("taxes")]
        public List<object> Taxes { get; set; } = new();

    

}
