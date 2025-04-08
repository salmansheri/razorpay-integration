using System;

namespace Razorpay.Dto;

public class UpiPaymentLinkDto
{
     public bool Upi_Link { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; } = "INR";
    public bool Accept_Partial { get; set; }
    public int First_Min_Partial_Amount { get; set; }
    public long Expire_By { get; set; }
    public string Reference_Id { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CustomerDto Customer { get; set; } = new();
    public RazorpayNotify Notify { get; set; } = new();
    public bool Reminder_Enable { get; set; }
    public Dictionary<string, string> Notes { get; set; } = new();
    public string Callback_Url { get; set; } = string.Empty;
    public string Callback_Method { get; set; } = "get";

}
