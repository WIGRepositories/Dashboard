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
using System.Web.Http.Tracing;


namespace BTPOSDashboardAPI.Controllers
{
    public class BTPOSLicenseController : ApiController
    {
        [HttpGet]
        public DataTable BOTPos()//Main Method
        {
            DataTable Tbl = new DataTable();



            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "BTPOSLICENSE credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetBTPOSLicense";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "BTPOSLICENSE Credentials completed.");
            // int found = 0;
            return Tbl;
        }
         [HttpPost]
        public HttpResponseMessage BOTPosPs(BOTPOSL B)
        {
            SqlConnection conn = new SqlConnection();
            try
            {

                LogTraceWriter traceWriter = new LogTraceWriter();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SAVEBTPOSLICENSE credentials....");
                //connect to database
                
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insBTPOSLicense";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter LId = new SqlParameter();
                LId.ParameterName = "@Id";
                LId.SqlDbType = SqlDbType.Int;
                LId.Value = Convert.ToString(B.Id);
                cmd.Parameters.Add(LId);
                SqlParameter LBTPOSid = new SqlParameter();
                LBTPOSid.ParameterName = "@BTPOSid";
                LBTPOSid.SqlDbType = SqlDbType.Int;
                LBTPOSid.Value =Convert.ToString(B.BTPOSid);
                cmd.Parameters.Add(LBTPOSid);
                SqlParameter LlicenseId = new SqlParameter();
                LlicenseId.ParameterName = "@licenseId";
                LlicenseId.SqlDbType = SqlDbType.Int;
                LlicenseId.Value =B.licenseId;
                cmd.Parameters.Add(LlicenseId);
                SqlParameter LFromDate = new SqlParameter();
                LFromDate.ParameterName = "@FromDate";
                 LFromDate.SqlDbType = SqlDbType.DateTime;
                 LFromDate.Value = Convert.ToString(B.FromDate);
                cmd.Parameters.Add(LFromDate);
                SqlParameter LEndDate = new SqlParameter();
                LEndDate.ParameterName = "@EndDate";
                LEndDate.SqlDbType = SqlDbType.DateTime;
                LEndDate.Value = Convert.ToString(B.EndDate);
                cmd.Parameters.Add(LEndDate);
                SqlParameter LNotificationDate = new SqlParameter();
                LNotificationDate.ParameterName = "@NotificationDate";
                LNotificationDate.SqlDbType = SqlDbType.DateTime;
                LNotificationDate.Value = Convert.ToString(B.NotificationDate);
                cmd.Parameters.Add(LNotificationDate);
                SqlParameter LTransactionId = new SqlParameter();
                LTransactionId.ParameterName = "@TransactionId";
                LTransactionId.SqlDbType = SqlDbType.Int;
                LTransactionId.Value = Convert.ToString(B.TransactionId);
                cmd.Parameters.Add(LTransactionId);
                SqlParameter LRenewedOn = new SqlParameter();
                LRenewedOn.ParameterName = "@RenewedOn ";
                LRenewedOn.SqlDbType = SqlDbType.DateTime;
                LRenewedOn.Value = B.RenewedOn;
                cmd.Parameters.Add(LRenewedOn);
               
                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SAVEBTPOSLICENSE Credentials completed.");

                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SAVEBTPOSLICENSE:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
    public void Options()
        {

        }

    public DataTable Tbl { get; set; }
    }
}

    


    

