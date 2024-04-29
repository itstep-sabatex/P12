using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using static HttpClientDemo.PrivatBankApi;



namespace HttpClientDemo
{
    public class PrivatBankApi
    {
        public record CurrencyDescriptor(string BaseCurrency, string Currency, double SaleRateNB, double PurchaseRateNB);
        public record ExchangeRate(CurrencyDescriptor[] exchangeRate );

        private readonly HttpClient client;
        public PrivatBankApi()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://api.privatbank.ua/p24api/");
        }

        public async Task<ExchangeRate> GetRateAsync(DateTime date)
        {
            var response = await client.GetAsync($"exchange_rates?date={date.ToString("dd.MM.yyyy")}");
            if (response.IsSuccessStatusCode) 
            {
                return await response.Content.ReadFromJsonAsync<ExchangeRate>();
            }
            return new ExchangeRate(new CurrencyDescriptor[] { } );
            //return await client.GetFromJsonAsync<CurrencyDescriptor[]>($"exchange_rates?date={date.ToString("dd.MM.yyyy")}");
        }


    }
}
