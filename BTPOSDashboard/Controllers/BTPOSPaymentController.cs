using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace BTPOSDashboard.Controllers
{
    public class BtposPaymentController : ApiController
    {
         [HttpGet]
        public DataTable GetBtposPayment() 
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBtposPayment credentials....");
 

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBtposPayment";
            cmd.Connection = conn;

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBtposPayment Credentials completed.");
            // int found = 0;
            return Tbl;
        }

         [HttpGet]
         
         public DataTable GetBTPOSTransactions(string btposId, int fleetOwnerId) {

             DataTable Tbl = new DataTable();
             LogTraceWriter traceWriter = new LogTraceWriter();
             traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSTransactions....");


             //connect to database
             SqlConnection conn = new SqlConnection();
             //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
             conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "GetBTPOSTransactions";
             cmd.Connection = conn;

             cmd.Parameters.Add("@fleetOwnerId", SqlDbType.Int).Value = fleetOwnerId;
             cmd.Parameters.Add("@POSId", SqlDbType.VarChar).Value = btposId;

             DataSet ds = new DataSet();
             SqlDataAdapter db = new SqlDataAdapter(cmd);
             db.Fill(ds);
             Tbl = ds.Tables[0];
             traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSTransactions completed.");
             // int found = 0;
             return Tbl;
         }
    }
    
}
