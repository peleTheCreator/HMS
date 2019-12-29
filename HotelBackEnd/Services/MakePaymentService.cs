//using Stripe;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace HotelBackEnd.Services
//{
//    public class MakePaymentService
//    {
//        public static async Task<dynamic> PayAsync(string cardNumber, int month, int year, string cvc, int value )
//        {
//            try
//            {
//                //set the api key,use the secret key cos u doing in backend
//                StripeConfiguration.ApiKey = "sk_test_sf30g4zcbizyOL6QLgcRvCET003BM5BkWW";

//                //capturing 
//                var optiontoken = new TokenCreateOptions
//                {
//                    Card = new CreditCardOptions
//                    {
//                        Number = cardNumber,
//                        ExpMonth = month,
//                        ExpYear = year,
//                        Cvc = cvc
//                    }
//                };
//                //creating optiontoken
//                var servicetoken = new TokenService();
//                Token stripetoken = await servicetoken.CreateAsync(optiontoken);

//                //creating charge
//                var chargeoption = new ChargeCreateOptions
//                {
//                    Amount = value,
//                    Currency = "NGN",
//                    Description = "test",
//                    Source = stripetoken.Id,
//                };
//                //creating charge
//                var chrageservice = new ChargeService();
//                Charge charge = chrageservice.Create(chargeoption);
//                if (charge.Status == "succeeded")
//                {
//                    //strore BalanceTransactionId in database
//                    string BalanceTransactionId = charge.BalanceTransactionId;
//                }
//                if (charge.Paid)
//                {
//                    return "success";
//                }
//                else
//                {
//                    return "failed";
//                }
                
//            }
//            catch (Exception ex)
//            {
//                return ex.Message;
//            }
//        }
//    }
//}
