
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

namespace blocklist1.Controllers
{
    public class PayablesMasterController : ApiController
    {
 [HttpGet]
        public DataTable POSDashboard1()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetPayablesMaster credentials....");
 

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetPayablesMaster";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetPayablesMaster Credentials completed.");
            // int found = 0;
            return Tbl;
        }


        [HttpPost]
         public HttpResponseMessage pos(PayablesMaster b)
         {
             LogTraceWriter traceWriter = new LogTraceWriter();
             traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SavePayablesMaster credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            { 
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELPayablesMaster";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = b.Id;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@Date";
            Gid.SqlDbType = SqlDbType.DateTime;
            Gid.Value = b.Date;
            Gid.Value = Convert.ToString(b.Date);
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@PaidFor";
            lid.SqlDbType = SqlDbType.VarChar;
            lid.Value = b.PaidFor;
            cmd.Parameters.Add(lid);
           

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@Desc";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value =b.Desc;
            cmd.Parameters.Add(pid);
          
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
           // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SavePayablesMaster Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SavePayablesMaster:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
         }
        public void Options() { }

    }
    }



    

