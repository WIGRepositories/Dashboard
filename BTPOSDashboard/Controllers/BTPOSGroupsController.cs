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
    public class BTPOSGroupsController : ApiController
    {
        [HttpGet]
        public DataTable groups()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSGroups credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAlertNotification";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSGroups Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage btpos(btposgroups b)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                LogTraceWriter traceWriter = new LogTraceWriter();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveBTPOSGroups  credentials....");

            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelBTPOSGroups";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@GroupName";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.GroupName;
            cmd.Parameters.Add(ss);

            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@Desc";
            ii.SqlDbType = SqlDbType.VarChar;
            ii.Value = b.Desc;
            cmd.Parameters.Add(ii);
            SqlParameter ll = new SqlParameter();
            ll.ParameterName = "@Active";
            ll.SqlDbType = SqlDbType.VarChar;
            ll.Value = b.Active;
            cmd.Parameters.Add(ll);
            SqlParameter nn = new SqlParameter();
            nn.ParameterName = "@Code";
            nn.SqlDbType = SqlDbType.VarChar;
            nn.Value = b.Code;
            cmd.Parameters.Add(nn);
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveBTPOSGroups Credentials completed.");
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveBTPOSGroups:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public void Options() { }
    }
}
