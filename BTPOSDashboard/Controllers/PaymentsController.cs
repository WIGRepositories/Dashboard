using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Net;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json.Linq;
using PayPal.Api;
using Newtonsoft.Json;

namespace BTPOSDashboard.Controllers
{
    public class PaymentsController : ApiController
    {
        [HttpGet]
        [Route("api/MakePayment")]
        public HttpResponseMessage MakePayment() {           
            try
            {

                // ### Api Context
                // Pass in a `APIContext` object to authenticate 
                // the call and to send a unique request id 
                // (that ensures idempotency). The SDK generates
                // a request id if you do not pass one explicitly. 
                // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
                var apiContext = BTPOSDashboard.Controllers.Configuration.GetAPIContext();

                // A transaction defines the contract of a payment - what is the payment for and who is fulfilling it. 
                var transaction = new Transaction()
                {
                    amount = new Amount()
                    {
                        currency = "USD",
                        total = "7",
                        details = new Details()
                        {
                            shipping = "1",
                            subtotal = "5",
                            tax = "1"
                        }
                    },
                    description = "This is the payment transaction description.",
                    item_list = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "1",
                            quantity = "5",
                            sku = "sku"
                        }
                    },
                        shipping_address = new ShippingAddress
                        {
                            city = "Johnstown",
                            country_code = "US",
                            line1 = "52 N Main ST",
                            postal_code = "43210",
                            state = "OH",
                            recipient_name = "Joe Buyer"
                        }
                    },
                    invoice_number = Common.GetRandomInvoiceNumber()
                };

                // A resource representing a Payer that funds a payment.
                var payer = new Payer()
                {
                    payment_method = "credit_card",
                    funding_instruments = new List<FundingInstrument>()
                {
                    new FundingInstrument()
                    {
                        credit_card = new CreditCard()
                        {
                            billing_address = new Address()
                            {
                                city = "Johnstown",
                                country_code = "US",
                                line1 = "52 N Main ST",
                                postal_code = "43210",
                                state = "OH"
                            },
                            cvv2 = "874",
                            expire_month = 11,
                            expire_year = 2018,
                            first_name = "Joe",
                            last_name = "Shopper",
                            number = "4024007185826731",//"4877274905927862",
                            type = "visa"
                        }
                    }
                },
                    payer_info = new PayerInfo
                    {
                        email = "test@email.com"
                    }
                };

                // A Payment resource; create one using the above types and intent as `sale` or `authorize`
                var payment = new Payment()
                {
                    intent = "sale",
                    payer = payer,
                    transactions = new List<Transaction>() { transaction }
                };

                // Create a payment using a valid APIContext
                var createdPayment = payment.Create(apiContext);               

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {               
                string str = ex.Message;
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }


        [HttpGet]
        [Route("api/GetPaymentAck")]
        public DataTable GetPaymentAck(string BTPOSId, decimal amt, string cardno, string cvv, string expirydate)
        {
            try
            {

                // ### Api Context
                // Pass in a `APIContext` object to authenticate 
                // the call and to send a unique request id 
                // (that ensures idempotency). The SDK generates
                // a request id if you do not pass one explicitly. 
                // See [Configuration.cs](/Source/Configuration.html) to know more about APIContext.
                var apiContext = BTPOSDashboard.Controllers.Configuration.GetAPIContext();

                // A transaction defines the contract of a payment - what is the payment for and who is fulfilling it. 
                var transaction = new Transaction()
                {
                    amount = new Amount()
                    {
                        currency = "USD",
                        total = "7",
                        details = new Details()
                        {
                            shipping = "1",
                            subtotal = "5",
                            tax = "1"
                        }
                    },
                    description = "This is the payment transaction description.",
                    item_list = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Item Name",
                            currency = "USD",
                            price = "1",
                            quantity = "5",
                            sku = "sku"
                        }
                    },
                        shipping_address = new ShippingAddress
                        {
                            city = "Johnstown",
                            country_code = "US",
                            line1 = "52 N Main ST",
                            postal_code = "43210",
                            state = "OH",
                            recipient_name = "Joe Buyer"
                        }
                    },
                    invoice_number = Common.GetRandomInvoiceNumber()
                };

                // A resource representing a Payer that funds a payment.
                var payer = new Payer()
                {
                    payment_method = "credit_card",
                    funding_instruments = new List<FundingInstrument>()
                {
                    new FundingInstrument()
                    {
                        credit_card = new CreditCard()
                        {
                            billing_address = new Address()
                            {
                                city = "Johnstown",
                                country_code = "US",
                                line1 = "52 N Main ST",
                                postal_code = "43210",
                                state = "OH"
                            },
                            cvv2 = "874",
                            expire_month = 11,
                            expire_year = 2018,
                            first_name = "Joe",
                            last_name = "Shopper",
                            number = "4024007185826731",//"4877274905927862",
                            type = "visa"
                        }
                    }
                },
                    payer_info = new PayerInfo
                    {
                        email = "test@email.com"
                    }
                };

                // A Payment resource; create one using the above types and intent as `sale` or `authorize`
                var payment = new Payment()
                {
                    intent = "sale",
                    payer = payer,
                    transactions = new List<Transaction>() { transaction }
                };

                // Create a payment using a valid APIContext
                var createdPayment = payment.Create(apiContext);

                DataTable indexTbl = new DataTable();
                indexTbl.Columns.Add("Status");
                indexTbl.Columns.Add("PymntAckId");
                DataRow dr = indexTbl.NewRow();
                dr[0] = 1;
                dr[1] = createdPayment.id;
                indexTbl.Rows.Add(dr);

                return indexTbl;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                DataTable indexTbl = new DataTable();
                indexTbl.Columns.Add("Status");
                indexTbl.Columns.Add("PymntAckId");
                DataRow dr = indexTbl.NewRow();
                dr[0] = 0;
                dr[1] = str;
                indexTbl.Rows.Add(dr);

                return indexTbl;
            }
        }       
    }

    public static class Configuration
    {
        public readonly static string ClientId;
        public readonly static string ClientSecret;

        // Static constructor for setting the readonly static members.
        static Configuration()
        {
            var config = GetConfig();
            ClientId = config["clientId"];
            ClientSecret = config["clientSecret"];
        }

        // Create the configuration map that contains mode and other optional configuration details.
        public static Dictionary<string, string> GetConfig()
        {
            return ConfigManager.Instance.GetProperties();
        }

        // Create accessToken
        private static string GetAccessToken()
        {
            // ###AccessToken
            // Retrieve the access token from
            // OAuthTokenCredential by passing in
            // ClientID and ClientSecret
            // It is not mandatory to generate Access Token on a per call basis.
            // Typically the access token can be generated once and
            // reused within the expiry window                
            string accessToken = new OAuthTokenCredential(ClientId, ClientSecret, GetConfig()).GetAccessToken();
            return accessToken;
        }

        // Returns APIContext object
        public static APIContext GetAPIContext(string accessToken = "")
        {
            // ### Api Context
            // Pass in a `APIContext` object to authenticate 
            // the call and to send a unique request id 
            // (that ensures idempotency). The SDK generates
            // a request id if you do not pass one explicitly. 
            var apiContext = new APIContext(string.IsNullOrEmpty(accessToken) ? GetAccessToken() : accessToken);
            apiContext.Config = GetConfig();

            // Use this variant if you want to pass in a request id  
            // that is meaningful in your application, ideally 
            // a order id.
            // String requestId = Long.toString(System.nanoTime();
            // APIContext apiContext = new APIContext(GetAccessToken(), requestId ));

            return apiContext;
        }

    }

    public static class Common
    {
        public static string FormatJsonString(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return string.Empty;
            }

            if (json.StartsWith("["))
            {
                // Hack to get around issue with the older Newtonsoft library
                // not handling a JSON array that contains no outer element.
                json = "{\"list\":" + json + "}";
                var formattedText = JObject.Parse(json).ToString(Formatting.Indented);
                formattedText = formattedText.Substring(13, formattedText.Length - 14).Replace("\n  ", "\n");
                return formattedText;
            }
            return JObject.Parse(json).ToString(Formatting.Indented);
        }

        /// <summary>
        /// Gets a random invoice number to be used with a sample request that requires an invoice number.
        /// </summary>
        /// <returns>A random invoice number in the range of 0 to 999999</returns>
        public static string GetRandomInvoiceNumber()
        {
            return new Random().Next(999999).ToString();
        }
    }
}