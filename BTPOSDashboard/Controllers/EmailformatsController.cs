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
    public class EmailformatsController : ApiController
    {
        [HttpGet]
        public DataTable Emailform()//Main Method
        {


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEmailform credentials....");
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetEmailformats";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEmailform Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage Emailforms(Gmailformat g)
        {


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveEmailform credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database
               
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insEmailformats";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter gId = new SqlParameter();
                gId.ParameterName = "@Id";
                gId.SqlDbType = SqlDbType.Int;
                gId.Value = Convert.ToString(g.Id);
                cmd.Parameters.Add(gId);
                SqlParameter gmessage = new SqlParameter();
                gmessage.ParameterName = "@message";
                gmessage.SqlDbType = SqlDbType.VarChar;
                gmessage.Value =g.message;
                cmd.Parameters.Add(gmessage);
                SqlParameter gActive = new SqlParameter();
                gActive.ParameterName = "@Active ";
                gActive.SqlDbType = SqlDbType.Int;
                gActive.Value = Convert.ToString(g.Active);
                cmd.Parameters.Add(gActive);
                SqlParameter gDesc1 = new SqlParameter();
                gDesc1.ParameterName = "@Desc1";
                gDesc1.SqlDbType = SqlDbType.VarChar;
                gDesc1.Value = g.Desc1;
                cmd.Parameters.Add(gDesc1);

                SqlParameter gfromaddr = new SqlParameter();
                gfromaddr.ParameterName = "@Fromaddr ";
                gfromaddr.SqlDbType = SqlDbType.VarChar;
                gfromaddr.Value = g.Fromaddr;
                cmd.Parameters.Add(gfromaddr);
                SqlParameter gToAddr = new SqlParameter();
                gToAddr.ParameterName = "@Toaddrs ";
                gToAddr.SqlDbType = SqlDbType.VarChar;
                gToAddr.Value = g.Toaddrs;
                cmd.Parameters.Add(gToAddr);
                SqlParameter gBTPOSGrpId  = new SqlParameter();
                gBTPOSGrpId.ParameterName = "@BTPOSGrpId";
                gBTPOSGrpId .SqlDbType = SqlDbType.Int;
                gBTPOSGrpId.Value = Convert.ToString(g.BTPOSGrpId);
                cmd.Parameters.Add(gBTPOSGrpId);



                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveEmailform Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;

                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveEmailform:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        public void Options()
        {

        }

        public DataTable Tbl { get; set; }
    }
}

    

