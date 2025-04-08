using System;
using Razorpay.Dto;

namespace Razorpay.Services.Interfaces;

public interface IRazorpayService
{
    Task<string?> CreatePaymentLinkAsync(PaymentLinkDto paymentLinkDto);
    Task<string?> CreateUpiPaymentLinkAsync(UpiPaymentLinkDto upiPaymentLinkDto); 
    Task<string?> CreateNetbankingPaymentLinkAsync(NetbankingPaymentLinkDto netbankingPaymentLinkDto);  
    Task<CreateOrderResponseDto?> CreateOrderAsync(OrderDto orderDto); 
     Task<CreateItemResponseDto?> CreateItemAsync(ItemDto itemDto); 
     Task<CreateInvoiceResponseDto?> CreateInvoiceAsync(string customerId,  string itemId); 
     Task<CreateCustomerResponseDto?> CreateCustomerAsync(RazorpayCustomerDto customerDto); 


}
