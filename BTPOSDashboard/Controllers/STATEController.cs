
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

namespace blocklist1.Controllers
{
    public class STATEController : ApiController
    {

          [HttpGet]

        public DataTable POSDashboard1()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetSTATE credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetSTATE";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetSTATE Credentials completed.");
            
            // int found = 0;
            return Tbl;
        }
          [HttpPost]
          public HttpResponseMessage pos(STATE b)
          {

              LogTraceWriter traceWriter = new LogTraceWriter();
              traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSTATE credentials....");
              //connect to database
              SqlConnection conn = new SqlConnection();
              try
              {

                  //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                  conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                  SqlCommand cmd = new SqlCommand();
                  cmd.CommandType = CommandType.StoredProcedure;
                  cmd.CommandText = "InsUpdDelELSTATE";
                  cmd.Connection = conn;
                  conn.Open();


                  SqlParameter Aid = new SqlParameter();
                  Aid.ParameterName = "@Id";
                  Aid.SqlDbType = SqlDbType.VarChar;
                  Aid.Value = b.Id;
                  Aid.Value = Convert.ToString(b.Id);
                  cmd.Parameters.Add(Aid);

                  SqlParameter Gid = new SqlParameter();
                  Gid.ParameterName = "@Name";
                  Gid.SqlDbType = SqlDbType.VarChar;
                  Gid.Value = b.Name;
                  cmd.Parameters.Add(Gid);

                  SqlParameter lid = new SqlParameter();
                  lid.ParameterName = "@Count";
                  lid.SqlDbType = SqlDbType.VarChar;
                  lid.Value = b.Count;
                  cmd.Parameters.Add(lid);


                  SqlParameter pid = new SqlParameter();
                  pid.ParameterName = "@Code";
                  pid.SqlDbType = SqlDbType.VarChar;
                  pid.Value = b.Code;
                  cmd.Parameters.Add(pid);

                  SqlParameter ss = new SqlParameter();
                  ss.ParameterName = "@Active";
                  ss.SqlDbType = SqlDbType.VarChar;
                  ss.Value = b.Active;
                  cmd.Parameters.Add(ss);

                  //DataSet ds = new DataSet();
                  //SqlDataAdapter db = new SqlDataAdapter(cmd);
                  //db.Fill(ds);
                  // Tbl = Tables[0];
                  cmd.ExecuteScalar();
                  conn.Close();

                  traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSTATE Credentials completed.");
            
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
          public void Options() { }

    }
}
    
