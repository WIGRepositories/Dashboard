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
    public class BTPOSLocController : ApiController
    {
        [HttpGet]
        public DataTable BTPOSLOC()//Main Method
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSLoc credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetBTPOSLoc";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSLoc Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage Btoploc(BTPOSLoc L)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveBtoploc credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {


                //connect to database
               
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insBTPOSLoc";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter LId = new SqlParameter();
                LId.ParameterName = "@Id";
                LId.SqlDbType = SqlDbType.Int;
                LId.Value = Convert.ToString(L.Id);
                cmd.Parameters.Add(LId);
                SqlParameter LBTPOSId = new SqlParameter();
                LBTPOSId.ParameterName = "@BTPOSid";
                LBTPOSId.SqlDbType = SqlDbType.Int;
                LBTPOSId.Value = Convert.ToString(L.BTPOSid);
                cmd.Parameters.Add(LBTPOSId);
                SqlParameter LXcord = new SqlParameter();
                LXcord.ParameterName = "@Xcord ";
                LXcord.SqlDbType = SqlDbType.Int;
                LXcord.Value = Convert.ToString(L.Xcord);
                cmd.Parameters.Add(LXcord);
                SqlParameter LYcord = new SqlParameter();
                LYcord.ParameterName = "@Ycord ";
                LYcord.SqlDbType = SqlDbType.Int;
                LYcord.Value = Convert.ToString(L.Ycord);
                cmd.Parameters.Add(LYcord);
                SqlParameter Ltime = new SqlParameter();
                Ltime.ParameterName = "@time ";
                Ltime.SqlDbType = SqlDbType.Time;
                Ltime.Value = Convert.ToString(L.time);
                cmd.Parameters.Add(Ltime);
                SqlParameter Ldate = new SqlParameter();
                Ldate.ParameterName = "@date";
                Ldate.SqlDbType = SqlDbType.DateTime;
                Ldate.Value = Convert.ToString(L.date);
                cmd.Parameters.Add(Ldate);
                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveBtoploc Credentials completed.");
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
