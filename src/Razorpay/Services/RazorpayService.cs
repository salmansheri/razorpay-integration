using System;
using System.Text;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Razorpay.Configurations;
using Razorpay.Dto;
using Razorpay.Services.Interfaces;

namespace Razorpay.Services;

public class RazorpayService : IRazorpayService

{

    private readonly RazorpayConfig _razorpayConfig;
    private readonly HttpClient _client; 

    public RazorpayService(IOptions<RazorpayConfig> razorpayConfig, HttpClient httpClient)
    {
        _razorpayConfig = razorpayConfig.Value ?? throw new ArgumentNullException(nameof(razorpayConfig));
        var key = _razorpayConfig.Key ?? throw new ArgumentNullException(nameof(_razorpayConfig.Key)); 
        var secret = _razorpayConfig.Secret ?? throw new ArgumentNullException(nameof(_razorpayConfig.Secret));

        var byteArray = Encoding.ASCII.GetBytes($"{key}:{secret}"); 

        _client = httpClient; 
        _client.BaseAddress = new Uri("https://api.razorpay.com/v1/"); 
        _client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray)); 





    }
    public async Task<string?> CreateNetbankingPaymentLinkAsync(PaymentLinkWithNetBankingRequest netbankingPaymentLinkDto)
    {
          if (netbankingPaymentLinkDto == null)
        {
            return null; 
        }

         var paymentLinkObj = new PaymentLinkWithNetBankingRequest
{
    Amount = netbankingPaymentLinkDto.Amount,
    Currency = netbankingPaymentLinkDto.Currency,
    AcceptPartial = netbankingPaymentLinkDto.AcceptPartial,
    FirstMinPartialAmount = netbankingPaymentLinkDto.FirstMinPartialAmount,

    ReferenceId = $"REF-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
    Description = netbankingPaymentLinkDto.Description,

    Customer = new CustomerDto
    {
        Name = netbankingPaymentLinkDto.Customer?.Name?.Trim() ?? string.Empty,
        Contact = netbankingPaymentLinkDto.Customer?.Contact?.Trim() ?? string.Empty,
        Email = netbankingPaymentLinkDto.Customer?.Email?.Trim() ?? string.Empty
    },

    Notify = new RazorpayNotify
    {
        Sms = netbankingPaymentLinkDto.Notify.Sms,
        Email = netbankingPaymentLinkDto.Notify.Email
    },

    ReminderEnable = netbankingPaymentLinkDto.ReminderEnable,

    Options = new OptionsDtoWithNetbanking
    {
        Order = new OrderDtoWithNetBanking
        {
            Method = netbankingPaymentLinkDto.Options.Order.Method,
            BankAccount = new BankAccountDto
            {
                AccountNumber = netbankingPaymentLinkDto.Options.Order.BankAccount.AccountNumber?.Trim() ?? string.Empty,
                Name = netbankingPaymentLinkDto.Options.Order.BankAccount.Name?.Trim() ?? string.Empty,
                Ifsc = netbankingPaymentLinkDto.Options.Order.BankAccount.Ifsc?.Trim() ?? string.Empty
            }
        }
    }
};

  var content = new StringContent(JsonConvert.SerializeObject(paymentLinkObj), Encoding.UTF8, "application/json"); 

        var response = await _client.PostAsync("payment_links/", content); 

        var responseBody = await response.Content.ReadAsStringAsync(); 

        var paymentLinkResponse = JsonConvert.DeserializeObject<CreatePaymentLinkDto>(responseBody); 

        if (paymentLinkResponse is null)
        {
            return null; 
        }

        return paymentLinkResponse.Short_Url; 



    }

    public async Task<string?> CreatePaymentLinkAsync(PaymentLinkRequestDto paymentLinkDto)
    {
        if (paymentLinkDto == null)
        {
            return null; 
        }

       
        





paymentLinkDto.ExpireBy = DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds(); 
paymentLinkDto.ReferenceId = $"REF-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}"; 

Console.WriteLine("Payment Link Request: " + JsonConvert.SerializeObject(paymentLinkDto)); 


        // var json = JsonConvert.SerializeObject(paymentLinkDto);



        var content = new StringContent(JsonConvert.SerializeObject(paymentLinkDto), Encoding.UTF8, "application/json"); 

        var response = await _client.PostAsync("payment_links", content); 

        if (!response.IsSuccessStatusCode)
        {
            var errorContent = await response.Content.ReadAsStringAsync();
            Console.WriteLine("Razorpay Payment Link Creation Error: " + errorContent);    
        }

        var responseBody = await response.Content.ReadAsStringAsync(); 

        var paymentLinkResponse = JsonConvert.DeserializeObject<CreatePaymentLinkDto>(responseBody); 
       



        if (paymentLinkResponse is null)
        {
            return null; 
        }

        return paymentLinkResponse.Short_Url; 


    }

    public Task<string?> CreateUpiPaymentLinkAsync(UpiPaymentLinkDto upiPaymentLinkDto)
    {
        throw new NotImplementedException();
    }

    public  async Task<CreateCustomerResponseDto?> CreateCustomerAsync(RazorpayCustomerDto customerDto)
    {

        Console.WriteLine("Customer: " + customerDto.Name); 
        if (customerDto == null)
        {
            Console.WriteLine("Customer data is Empty");
            return null; 
            
        }

        var customerObj = new RazorpayCustomerDto
        {
            Name = customerDto.Name,
            Email = customerDto.Email,
            Contact = customerDto.Contact,
            Fail_existing = customerDto.Fail_existing,
            Gstin = customerDto.Gstin,
            
        }; 

        var json = JsonConvert.SerializeObject(customerObj);
        Console.WriteLine("Customer JSON: " + json); 

        

        

        var content = new StringContent(json, Encoding.UTF8, "application/json");
        var contentBody = await content.ReadAsStringAsync();  
        Console.WriteLine("Customer Content: " + contentBody);

        

        var response = await _client.PostAsync("customers", content); 

        Console.WriteLine(response); 
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Failed to create customer: {response.ReasonPhrase}");
        }



        

        var responseBody = await response.Content.ReadAsStringAsync(); 

        var customerResponse = JsonConvert.DeserializeObject<CreateCustomerResponseDto>(responseBody); 

        return customerResponse; 

    }

    public async Task<CreateOrderResponseDto?> CreateOrderAsync(OrderDto orderDto)
    {
        if (orderDto == null)
        {
            return null; 
        }

        var content = new StringContent(JsonConvert.SerializeObject(orderDto), Encoding.UTF8, "application/json"); 

        var response = await _client.PostAsync("orders", content); 

        if (!response.IsSuccessStatusCode)
        {
            return null; 
        }

        var responseBody = await response.Content.ReadAsStringAsync(); 

        var orderResponse = JsonConvert.DeserializeObject<CreateOrderResponseDto>(responseBody); 

        return orderResponse; 
    



    }

    public async Task<CreateItemResponseDto?> CreateItemAsync(ItemDto itemDto)
    {
        if (itemDto == null)
        {
            throw new ArgumentNullException(); 
        }

        var content = new StringContent(JsonConvert.SerializeObject(itemDto), Encoding.UTF8, "application/json"); 

        var response = await _client.PostAsync("items", content); 

        if (!response.IsSuccessStatusCode)
        {
               var errorContent = await response.Content.ReadAsStringAsync();
    Console.WriteLine("Razorpay Item Creation Error: " + errorContent); 
    throw new Exception($"Failed to create item: {response.ReasonPhrase} - {errorContent}");
        }

        var responseBody = await response.Content.ReadAsStringAsync(); 

        var itemResponse = JsonConvert.DeserializeObject<CreateItemResponseDto>(responseBody); 

        return itemResponse; 


    }

    public async Task<CreateInvoiceResponseDto?> CreateInvoiceAsync(InvoiceDto invoiceDto)
    {
        if (invoiceDto == null)
        {
            return null; 
        }

        // var invoiceDto = new InvoiceDto 
        // {
        //     Customer_Id  = customerId,
        //     Line_Items = new List<LineItemDto>
        //     {
        //         new LineItemDto
        //         {
        //             Item_Id = itemId, 
        //         }
        //     },
            


        // }; 

        var content = new StringContent(JsonConvert.SerializeObject(invoiceDto), Encoding.UTF8, "application/json"); 

        var response = await _client.PostAsync("invoices", content); 

        if (!response.IsSuccessStatusCode)
        {
            return null; 
        }

        var responseBody = await response.Content.ReadAsStringAsync(); 

        var invoiceResponse = JsonConvert.DeserializeObject<CreateInvoiceResponseDto>(responseBody);

        return invoiceResponse;  


    }
}
