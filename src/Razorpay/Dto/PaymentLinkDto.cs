using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Razorpay.Dto
{
    public class PaymentLinkDto
    {

        // public PaymentLinkDto()
        // {
        //      // Auto-generate expire_by as current time + 24 hours (you can customize the duration)
        //     ExpireBy = DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds();

        //     // Auto-generate a random reference_id using a GUID (or any preferred format)
        //     ReferenceId = $"REF-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}";

        // }
        [JsonProperty("amount")]
        [JsonIgnore]
        public int Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("accept_partial")]
        public bool AcceptPartial { get; set; }

        [JsonProperty("first_min_partial_amount")]
        public int FirstMinPartialAmount { get; set; }



        [JsonProperty("expire_by")]
        [JsonIgnore]

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

        // [JsonProperty("notes")]
        // public JToken Notes { get; set; } = JValue.CreateNull();

        [JsonProperty("callback_url")]
        public string CallbackUrl { get; set; } = string.Empty;

        [JsonProperty("callback_method")]
        public string CallbackMethod { get; set; } = string.Empty;
        public RazorpayCustomerDto RazorpayCustomerDto { get; set; } = new();
        public OrderDto OrderDto { get; set; } = new(); 
        public ItemDto ItemDto { get; set; } = new();  
    }

    public class CustomerDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("contact")]
        public string Contact { get; set; } = string.Empty;

        [JsonProperty("email")]
        public string Email { get; set; } = string.Empty;
    }

    public class RazorpayNotify
    {
        [JsonProperty("sms")]
        public bool Sms { get; set; }

        [JsonProperty("email")]
        public bool Email { get; set; }
    }
}
