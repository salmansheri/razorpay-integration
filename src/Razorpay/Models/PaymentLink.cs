using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Razorpay.Dto;

namespace Razorpay.Models;

public class PaymentLink
{
     [JsonProperty("accept_partial")]
        public bool AcceptPartial { get; set; }

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("amount_paid")]
        public int AmountPaid { get; set; }

        [JsonProperty("cancelled_at")]
        public int CancelledAt { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("customer")]
        public CustomerDto Customer { get; set; } = new();

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("expire_by")]
        public int ExpireBy { get; set; }

        [JsonProperty("expired_at")]
        public int ExpiredAt { get; set; }

        [JsonProperty("first_min_partial_amount")]
        public int FirstMinPartialAmount { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("notes")]
        public JToken Notes { get; set; } = JValue.CreateNull(); // can handle both [] and {}

        [JsonProperty("notify")]
        public RazorpayNotify Notify { get; set; } = new();

        [JsonProperty("options")]
        public JArray Options { get; set; } = new();

        [JsonProperty("payments")]
        public object? Payments { get; set; }

        [JsonProperty("reference_id")]
        public string ReferenceId { get; set; } = string.Empty;

        [JsonProperty("reminder_enable")]
        public bool ReminderEnable { get; set; }

        [JsonProperty("reminders")]
        public JToken Reminders { get; set; } = JValue.CreateNull(); 

        [JsonProperty("short_url")]
        public string ShortUrl { get; set; } = string.Empty;

        [JsonProperty("status")]
        public string Status { get; set; } = string.Empty;

        [JsonProperty("updated_at")]
        public long UpdatedAt { get; set; }

        [JsonProperty("upi_link")]
        public bool UpiLink { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; } = string.Empty;

        [JsonProperty("whatsapp_link")]
        public bool WhatsappLink { get; set; }

}
