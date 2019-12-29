using HotelFrontEnd.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HotelFrontEnd.Services
{
    public static class MakePayment
    {
        public static async Task<GetPaymentModel> MakePaymentAsync(BookingViewModel book)
        {
            GetPaymentModel model = new GetPaymentModel();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(book), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("https://cyberpay-payment-api.azurewebsites.net/api/v1/payments", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    model = JsonConvert.DeserializeObject<GetPaymentModel>(apiResponse);
                }
            }
            return model;
        }
    }
}
