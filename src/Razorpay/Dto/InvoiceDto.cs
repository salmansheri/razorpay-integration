using System;

namespace Razorpay.Dto;

public class InvoiceDto
{
     public string Type { get; set; } = "invoice";
    public long Date { get; set; }  // UNIX timestamp (e.g., 1760714528)
    public string Customer_Id { get; set; } = string.Empty;
    public List<LineItemDto> Line_Items { get; set; } = new();

}
