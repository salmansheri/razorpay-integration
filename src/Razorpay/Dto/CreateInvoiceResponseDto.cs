using System;

namespace Razorpay.Dto;

public class CreateInvoiceResponseDto
{
     public string Id { get; set; } = string.Empty;
    public string Entity { get; set; } = string.Empty;
    public string? Receipt { get; set; }
    public string? Invoice_Number { get; set; }
    public string Customer_Id { get; set; } = string.Empty;
    public CustomerDetailsDto Customer_Details { get; set; } = new();
    public string Order_Id { get; set; } = string.Empty;
    public List<LineItemDto> Line_Items { get; set; } = new();
    public string? Payment_Id { get; set; }
    public string Status { get; set; } = string.Empty;
    public long? Expire_By { get; set; }
    public long Issued_At { get; set; }
    public long? Paid_At { get; set; }
    public long? Cancelled_At { get; set; }
    public long? Expired_At { get; set; }
    public string Sms_Status { get; set; } = string.Empty;
    public string Email_Status { get; set; } = string.Empty;
    public long Date { get; set; }
    public string? Terms { get; set; }
    public bool Partial_Payment { get; set; }
    public int Gross_Amount { get; set; }
    public int Tax_Amount { get; set; }
    public int Taxable_Amount { get; set; }
    public int Amount { get; set; }
    public int Amount_Paid { get; set; }
    public int Amount_Due { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Currency_Symbol { get; set; } = string.Empty;
    public string? Description { get; set; }
    public List<object> Notes { get; set; } = new();
    public string? Comment { get; set; }
    public string Short_Url { get; set; } = string.Empty;
    public bool View_Less { get; set; }
    public long? Billing_Start { get; set; }
    public long? Billing_End { get; set; }
    public string Type { get; set; } = string.Empty;
    public bool Group_Taxes_Discounts { get; set; }
    public long Created_At { get; set; }
    public string? Ref_Num { get; set; }

}

public class CustomerDetailsDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Contact { get; set; } = string.Empty;
    public string Gstin { get; set; } = string.Empty;
    public object? Billing_Address { get; set; }
    public object? Shipping_Address { get; set; }
    public string Customer_Name { get; set; } = string.Empty;
    public string Customer_Email { get; set; } = string.Empty;
    public string Customer_Contact { get; set; } = string.Empty;
}

