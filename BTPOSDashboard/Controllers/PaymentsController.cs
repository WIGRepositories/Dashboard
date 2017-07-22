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
        public DataTable MakePayment(decimal amt)
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
                        total = amt.ToString(),
                        details = new Details()
                        {
                            shipping = "0",
                            subtotal = amt.ToString(),
                            tax = "0"
                        }
                    },
                    description = "This is the payment transaction description.",
                    item_list = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "Fleet Owner License",
                            currency = "USD",
                            price = amt.ToString(),
                            quantity = "1",
                            sku = "sku"
                        }
                    },
                        shipping_address = new ShippingAddress
                        {
                            city = "Harare",
                            country_code = "US",
                            line1 = "52 N Main ST",
                            postal_code = "43210",
                            state = "OH",
                            recipient_name = "Admin admin"
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
                                city = "Harare",
                                country_code = "US",
                                line1 = "52 N Main ST",
                                postal_code = "43210",
                                state = "OH"
                            },
                            cvv2 = "874",
                            expire_month = 11,
                            expire_year = 2018,
                            first_name = "admin",
                            last_name = "admin",
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

                DataTable dt = new DataTable();
                dt.Columns.Add("result");
                dt.Columns.Add("detail");

                DataRow dr = dt.NewRow();
                dr[0] = "Success";
                dr[1] = createdPayment.id;

                dt.Rows.Add(dr);


                return dt;
            }
            catch (Exception ex)
            {
                string str = ex.Message;
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                throw ex;
            }
        }


        [HttpGet]
        [Route("api/GetPaymentAck")]
        public DataTable GetPaymentAck(string BTPOSId, decimal amt, string cardno, string cvv, string expirydate)
        {
            int btposTransId = -1;

            SqlConnection conn = new SqlConnection();

            try
            {
                #region insert initial record for trans

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsUpdDelBTPOSTrans";
                cmd1.Connection = conn;

                SqlParameter cid = new SqlParameter();
                cid.ParameterName = "@BTPOSId";
                cid.SqlDbType = SqlDbType.VarChar;
                cid.Value = BTPOSId;
                cmd1.Parameters.Add(cid);

                SqlParameter fi = new SqlParameter();
                fi.ParameterName = "@AmountPaid";
                fi.SqlDbType = SqlDbType.Decimal;
                fi.Value = amt;
                cmd1.Parameters.Add(fi);

                SqlParameter f = new SqlParameter();
                f.ParameterName = "@Date";
                f.SqlDbType = SqlDbType.DateTime;
                f.Value = DateTime.Now;
                cmd1.Parameters.Add(f);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@GatewayTransId";
                gid.SqlDbType = SqlDbType.VarChar;
                gid.Value = "-1";

                cmd1.Parameters.Add(gid);

                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@insupdflag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = "I";
                cmd1.Parameters.Add(flag);

                SqlParameter tid = new SqlParameter();
                tid.ParameterName = "@posTransId";
                tid.SqlDbType = SqlDbType.Int;
                tid.Direction = ParameterDirection.Output;

                cmd1.Parameters.Add(tid);

                //insert into db
                conn.Open();
                cmd1.ExecuteNonQuery();

                object val = tid.Value;

                #endregion insert initial record for trans

                #region paypal

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
                        total = amt.ToString(),
                        details = new Details()
                        {
                            shipping = "0",
                            subtotal = amt.ToString(),
                            tax = "0"
                        }
                    },
                    description = "This is the ticket payment transaction.",
                    item_list = new ItemList()
                    {
                        items = new List<Item>()
                    {
                        new Item()
                        {
                            name = "BT POS Ticket",
                            currency = "USD",
                            price = amt.ToString(),
                            quantity = "1",
                            sku = "sku"
                        }
                    }
                        //,
                        //    shipping_address = new ShippingAddress
                        //    {
                        //        city = "johnstown",
                        //        country_code = "US",
                        //        line1 = "52 N Main ST",
                        //        postal_code = "43210",
                        //        state = "OH",
                        //        recipient_name = "joe Buyer"
                        //    }
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
                            //billing_address = new Address()
                            //{
                            //    city = "johnstown",
                            //    country_code = "US",
                            //    line1 = "52 N Main ST",
                            //    postal_code = "43210",
                            //    state = "OH"
                            //},
                            cvv2 = "874",
                            expire_month = 11,
                            expire_year = 2018,
                            first_name = "admin",
                            last_name = "admin",
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

                #endregion paypal

                #region update transagain

                cmd1.Parameters["@insupdflag"].Value = "U";
                cmd1.Parameters["@GatewayTransId"].Value = createdPayment.id;
                cmd1.Parameters.Add("@Id", SqlDbType.Int).Value = val;

                cmd1.ExecuteNonQuery();

                #endregion update transagain

                DataTable indexTbl = new DataTable();
                indexTbl.Columns.Add("Status");
                //indexTbl.Columns.Add("PymntAckId");
                //indexTbl.Columns.Add("btposTransId");

                DataRow dr = indexTbl.NewRow();
                dr[0] = "~1" + ","+ createdPayment.id + "," + val+"~";
                //dr[1] = createdPayment.id;
                //dr[2] = val;

                indexTbl.Rows.Add(dr);
                conn.Close();
                return indexTbl;
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                DataTable indexTbl = new DataTable();
                indexTbl.Columns.Add("Status");
                //indexTbl.Columns.Add("PymntAckId");
                //indexTbl.Columns.Add("btposTransId");

                DataRow dr = indexTbl.NewRow();
                dr[0] = "~0" + ","+ str + "," + btposTransId + "~"; 
               // dr[1] = str;
               // dr[1] = btposTransId;

                indexTbl.Rows.Add(dr);

                return indexTbl;
            }
        }

        /// <summary>
        /// this is to save the btpos transactions such as printed tickets etc.,
        /// </summary>
        /// <param name="BTPOSId"></param>
        /// <param name="transTypeId"></param>
        /// <param name="amt"></param>
        /// <param name="gatewayId"></param>
        /// <param name="datetime"></param>
        /// <param name="srcId"></param>
        /// <param name="destId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetPaymentAck")]
        public DataTable GetPaymentAck(string BTPOSId, int transTypeId, decimal amt, string gatewayId, string datetime, string srcId, string destId)
        {
            DataTable indexTbl = new DataTable();
            indexTbl.Columns.Add("Status");

            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsUpdDelBTPOSTrans";
                cmd1.Connection = conn;

                SqlParameter cid = new SqlParameter();
                cid.ParameterName = "@BTPOSId";
                cid.SqlDbType = SqlDbType.VarChar;
                cid.Value = BTPOSId;
                cmd1.Parameters.Add(cid);

                SqlParameter fid1 = new SqlParameter();
                fid1.ParameterName = "@transTypeId";
                fid1.SqlDbType = SqlDbType.Int;
                fid1.Value = transTypeId;
                cmd1.Parameters.Add(fid1);

                SqlParameter fi = new SqlParameter();
                fi.ParameterName = "@amt";
                fi.SqlDbType = SqlDbType.Decimal;
                fi.Value = amt;
                cmd1.Parameters.Add(fi);

                SqlParameter f = new SqlParameter();
                f.ParameterName = "@datetime";
                f.SqlDbType = SqlDbType.VarChar;
                f.Value = datetime;
                cmd1.Parameters.Add(f);

                SqlParameter f1 = new SqlParameter();
                f1.ParameterName = "@gatewayId";
                f1.SqlDbType = SqlDbType.VarChar;
                f1.Value = gatewayId;
                cmd1.Parameters.Add(f1);

                SqlParameter ff = new SqlParameter();
                ff.ParameterName = "@srcId";
                ff.SqlDbType = SqlDbType.VarChar;
                ff.Value = srcId;
                cmd1.Parameters.Add(ff);

                SqlParameter fid2 = new SqlParameter();
                fid2.ParameterName = "@destId";
                fid2.SqlDbType = SqlDbType.VarChar;
                fid2.Value = destId;
                cmd1.Parameters.Add(fid2);

                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@insupdflag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = "U";
                cmd1.Parameters.Add(flag);

                //insert into db
                conn.Open();
                int btposTransId = (int)cmd1.ExecuteScalar();
                conn.Close();

                if (btposTransId > 0)
                {
                }

                DataRow dr = indexTbl.NewRow();
                dr[0] = 1;

                indexTbl.Rows.Add(dr);

                return indexTbl;
            }
            catch (Exception e) {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                DataRow dr = indexTbl.NewRow();
                dr[0] = 0;

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
        public static string FormatjsonString(string json)
        {
            if (string.IsNullOrEmpty(json))
            {
                return string.Empty;
            }

            if (json.StartsWith("["))
            {
                // Hack to get around issue with the older Newtonsoft library
                // not handling a jSON array that contains no outer element.
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