using System;
using Razorpay.Dto;

namespace Razorpay.Services.Interfaces;

public interface IRazorpayService
{
    Task<string?> CreatePaymentLinkAsync(PaymentLinkRequestDto paymentLinkDto);
    Task<string?> CreateUpiPaymentLinkAsync(UpiPaymentLinkDto upiPaymentLinkDto); 
    Task<string?> CreateNetbankingPaymentLinkAsync(PaymentLinkWithNetBankingRequest netbankingPaymentLinkDto);  
    Task<CreateOrderResponseDto?> CreateOrderAsync(OrderDto orderDto); 
     Task<CreateItemResponseDto?> CreateItemAsync(ItemDto itemDto); 
     Task<CreateInvoiceResponseDto?> CreateInvoiceAsync(InvoiceDto invoiceDto); 
     Task<CreateCustomerResponseDto?> CreateCustomerAsync(RazorpayCustomerDto customerDto); 


}
