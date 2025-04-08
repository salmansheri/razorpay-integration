using System;

namespace Razorpay.Dto;

public class CreateItemResponseDto
{
    public string Id { get; set; } = string.Empty;
    public bool Active { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int Unit_Amount { get; set; }
    public string Currency { get; set; } = string.Empty;
    public string Type { get; set; } = string.Empty;
    public string? Unit { get; set; }
    public bool Tax_Inclusive { get; set; }
    public string? Hsn_Code { get; set; }
    public string? Sac_Code { get; set; }
    public string? Tax_Rate { get; set; }
    public string? Tax_Id { get; set; }
    public string? Tax_Group_Id { get; set; }
    public long Created_At { get; set; }

}
