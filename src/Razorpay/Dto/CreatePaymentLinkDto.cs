using System;

namespace Razorpay.Dto;

public class CreatePaymentLinkDto
{
    public bool Accept_Partial { get; set; }
    public int Amount { get; set; }
    public int Amount_Paid { get; set; }
    public string Callback_Method { get; set; } = string.Empty;
    public string Callback_Url { get; set; } = string.Empty;
    public long Cancelled_At { get; set; }
    public long Created_At { get; set; }
    public string Currency { get; set; } = string.Empty;
    public CustomerDto Customer { get; set; } = new();
    public string Description { get; set; } = string.Empty;
    public long Expire_By { get; set; }
    public long Expired_At { get; set; }
    public int First_Min_Partial_Amount { get; set; }
    public string Id { get; set; } = string.Empty;
    public Dictionary<string, string> Notes { get; set; } = new();
    public RazorpayNotify Notify { get; set; } = new();
    public object? Payments { get; set; }
    public string Reference_Id { get; set; } = string.Empty;
    public bool Reminder_Enable { get; set; }
    public List<object> Reminders { get; set; } = new();
    public string Short_Url { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public long Updated_At { get; set; }
    public bool Upi_Link { get; set; }
    public string User_Id { get; set; } = string.Empty;
    public bool Whatsapp_Link { get; set; }

}
