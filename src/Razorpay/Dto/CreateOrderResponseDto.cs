using System;

namespace Razorpay.Dto;

public class CreateOrderResponseDto
{
     public string Id { get; set; } = string.Empty;
    public string Entity { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int Amount_Due { get; set; }
    public int Amount_Paid { get; set; }
    public int Attempts { get; set; }
    public long Created_At { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string? Offer_Id { get; set; }
    public string Receipt { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    

}
