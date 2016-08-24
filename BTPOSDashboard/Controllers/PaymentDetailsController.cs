using BTPOSDashboard;
using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTPOSDashboardAPI.Controllers
{
    public class PaymentDetailsController : ApiController
    {
        [HttpGet]
        public DataTable PaymentD()//Main Method
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetPaymentDetails credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetPaymentDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetPaymentDetails Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage PaymentDtls(Payment p)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SavePaymentDetails credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insPaymentDetails";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter PId = new SqlParameter();
                PId.ParameterName = "@Id ";
                PId.SqlDbType = SqlDbType.Int;
                PId.Value = Convert.ToString(p.Id);
                cmd.Parameters.Add(PId);
                SqlParameter pdate = new SqlParameter();
                pdate.ParameterName = "@PaymentTypeId";
                pdate.SqlDbType = SqlDbType.Int;
                pdate.Value = Convert.ToString(p.PaymentTypeId);
                cmd.Parameters.Add(pdate);
                SqlParameter Damount = new SqlParameter();
                Damount.ParameterName = "@Amount";
                Damount.SqlDbType = SqlDbType.Int;
                Damount.Value = Convert.ToString(p.Amount);
                cmd.Parameters.Add(Damount);
                SqlParameter Date = new SqlParameter();
                Date.ParameterName = "@date";
                Date.SqlDbType = SqlDbType.VarChar;
                Date.Value = p.date;
                cmd.Parameters.Add(Date);
                
                SqlParameter DBTId = new SqlParameter();
                DBTId.ParameterName = "@TransactionId ";
                DBTId.SqlDbType = SqlDbType.Int;
                DBTId.Value = Convert.ToString(p.TransactionId);
                cmd.Parameters.Add(DBTId);

               
                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SavePaymentDetails Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public void Options()
        {

        }

        public DataTable Tbl { get; set; }
    }
}
