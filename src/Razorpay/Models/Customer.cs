using System;
using Newtonsoft.Json;

namespace Razorpay.Models;

public class Customer
{
     [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("entity")]
        public string Entity { get; set; } = string.Empty;

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("email")]
        public string? Email { get; set; }

        [JsonProperty("contact")]
        public string? Contact { get; set; }

        [JsonProperty("gstin")]
        public string? Gstin { get; set; }

        [JsonProperty("notes")]
        public List<object>? Notes { get; set; }

        [JsonProperty("shipping_address")]
        public List<object>? ShippingAddress { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

}
