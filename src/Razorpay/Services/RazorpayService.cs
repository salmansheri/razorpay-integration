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
    public Task<string?> CreateNetbankingPaymentLinkAsync(NetbankingPaymentLinkDto netbankingPaymentLinkDto)
    {
        throw new NotImplementedException();
    }

    public async Task<string?> CreatePaymentLinkAsync(PaymentLinkDto paymentLinkDto)
    {
        if (paymentLinkDto == null)
        {
            return null; 
        }

        // var customerObj = new RazorpayCustomerDto 
        // {
        //     Name = paymentLinkDto.RazorpayCustomer.Name,
        //     Email = paymentLinkDto.RazorpayCustomer.Email,
        //     Contact = paymentLinkDto.RazorpayCustomer.Contact,
        //     Fail_existing = paymentLinkDto.RazorpayCustomer.Fail_existing,
        //     Gstin = paymentLinkDto.RazorpayCustomer.Gstin,
        //     Notes = paymentLinkDto.RazorpayCustomer.Notes

        // }; 

        // var customer = await CreateCustomerAsync(customerObj); 

        // if (customer is null)
        // {
        //     Console.WriteLine("Cannot create Customer"); 
        //     return null; 
        // }

        // var customerId = customer.Id; 

        // var itemObj = new ItemDto
        // {
        //      Name = paymentLinkDto.Item.Name, 
        //     Amount = paymentLinkDto.Item.Amount,
        //     Currency = paymentLinkDto.Item.Currency,
        //     Description = paymentLinkDto.Item.Description,
           
        // }; 

        // var item = await CreateItemAsync(itemObj); 

        // if (item is null)
        // {
        //      Console.WriteLine("Cannot create Item"); 
        //     return null; 
        // }

        // var itemId =  item.Id; 

     

        // var invoice = await CreateInvoiceAsync(customerId, itemId);

        // if (invoice is null)
        // {
        //      Console.WriteLine("Cannot create Invoice"); 
        //     return null; 
        // } 

      var paymentLinkObj = new PaymentLinkDto
{
    Amount = paymentLinkDto.Amount,
    Currency = paymentLinkDto.Currency,
    AcceptPartial = paymentLinkDto.AcceptPartial,
    FirstMinPartialAmount = paymentLinkDto.FirstMinPartialAmount,
    ExpireBy = DateTimeOffset.UtcNow.AddHours(24).ToUnixTimeSeconds(),
    ReferenceId = $"REF-{Guid.NewGuid().ToString().Replace("-", "").Substring(0, 10).ToUpper()}",
    Description = paymentLinkDto.Description,
    Customer = new CustomerDto
    {
        Name = paymentLinkDto.Customer.Name,
        Contact = paymentLinkDto.Customer.Contact,
        Email = paymentLinkDto.Customer.Email
    },
    Notify = new RazorpayNotify
    {
        Sms = paymentLinkDto.Notify.Sms,
        Email = paymentLinkDto.Notify.Email
    },
    ReminderEnable = paymentLinkDto.ReminderEnable,
    Notes = paymentLinkDto.Notes,
    CallbackUrl = paymentLinkDto.CallbackUrl,
    CallbackMethod = paymentLinkDto.CallbackMethod
};

        var content = new StringContent(JsonConvert.SerializeObject(paymentLinkObj), Encoding.UTF8, "application/json"); 

        var response = await _client.PostAsync("payment_links", content); 

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
        if (customerDto == null)
        {
            return null; 
            
        }

        var json = JsonConvert.SerializeObject(customerDto); 

        Console.WriteLine(json); 

        

        var content = new StringContent(json, Encoding.UTF8, "application/json"); 

        Console.WriteLine(content); 

        var response = await _client.PostAsync("customers", content); 
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

    public async Task<CreateInvoiceResponseDto?> CreateInvoiceAsync(string customerId,  string itemId)
    {
        if (string.IsNullOrEmpty(customerId) || string.IsNullOrEmpty(itemId))
        {
            return null; 
        }

        var invoiceDto = new InvoiceDto 
        {
            Customer_Id  = customerId,
            Line_Items = new List<LineItemDto>
            {
                new LineItemDto
                {
                    Item_Id = itemId, 
                }
            },
            


        }; 

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
