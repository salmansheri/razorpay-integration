using System;

namespace Razorpay.Dto;

public class CreateCustomerResponseDto
{
    public string Id { get; set; } = string.Empty;
    public string Entity { get; set; } = "customer";
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string Gstin { get; set; } = string.Empty;
    // public Dictionary<string, string> Notes { get; set; } = new();
    public List<object> Shipping_Address { get; set; } = new();
    public long Created_At { get; set; }


}
