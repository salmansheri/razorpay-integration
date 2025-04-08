using System;

namespace Razorpay.Dto;

public class NetbankingPaymentLinkDto
{
    public int Amount { get; set; }
    public string Currency { get; set; } = "INR";
    public bool Accept_Partial { get; set; }
    public int First_Min_Partial_Amount { get; set; }
    public string Reference_Id { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public CustomerDto Customer { get; set; } = new();
    public RazorpayNotify Notify { get; set; } = new();
    public bool Reminder_Enable { get; set; }
    public RazorpayOptions Options { get; set; } = new();


}

public class RazorpayOptions
{
    public RazorpayOrder Order { get; set; } = new();
}

public class RazorpayOrder
{
    public string Method { get; set; } = "netbanking";
    public RazorpayBankAccount Bank_Account { get; set; } = new();
}

public class RazorpayBankAccount
{
    public string Account_Number { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string IFSC { get; set; } = string.Empty;
}
