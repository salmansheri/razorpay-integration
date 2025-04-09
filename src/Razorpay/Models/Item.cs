using System;
using Newtonsoft.Json;

namespace Razorpay.Models;

public class Item
{
     [JsonProperty("id")]
        public string Id { get; set; } = string.Empty;

        [JsonProperty("active")]
        public bool Active { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string Description { get; set; } = string.Empty;

        [JsonProperty("amount")]
        public int Amount { get; set; }

        [JsonProperty("unit_amount")]
        public int UnitAmount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; } = string.Empty;

        [JsonProperty("type")]
        public string Type { get; set; } = string.Empty;

        [JsonProperty("unit")]
        public string? Unit { get; set; }

        [JsonProperty("tax_inclusive")]
        public bool TaxInclusive { get; set; }

        [JsonProperty("hsn_code")]
        public string? HsnCode { get; set; }

        [JsonProperty("sac_code")]
        public string? SacCode { get; set; }

        [JsonProperty("tax_rate")]
        public string? TaxRate { get; set; }

        [JsonProperty("tax_id")]
        public string? TaxId { get; set; }

        [JsonProperty("tax_group_id")]
        public string? TaxGroupId { get; set; }

        [JsonProperty("created_at")]
        public long CreatedAt { get; set; }

}
