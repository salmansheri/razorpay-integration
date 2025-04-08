using System;

namespace Razorpay.Dto;

public class PaymentLinkDto
{
     public int Amount { get; set; }
        public string Currency { get; set; } = string.Empty;
        public bool AcceptPartial { get; set; }
        public int FirstMinPartialAmount { get; set; }
        public long ExpireBy { get; set; }
        public string ReferenceId { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public CustomerDto Customer { get; set; } = new();
        public RazorpayNotify Notify { get; set; } = new();
        public bool ReminderEnable { get; set; }
        public Dictionary<string, string> Notes { get; set; } = new();
        public string CallbackUrl { get; set; } = string.Empty;
        public string CallbackMethod { get; set; } = string.Empty;

}

public class CustomerDto
{
    public string Name { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}

public class RazorpayNotify
{
    public bool Sms { get; set; }
    public bool Email { get; set; }
}
