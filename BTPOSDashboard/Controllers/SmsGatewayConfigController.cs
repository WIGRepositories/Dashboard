using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboard.Controllers
{
    public class SmsGatewayConfigController : ApiController
    {
        [HttpGet]

        public DataTable GetSmsGatewayConfig()
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetSmsGatewayConfig credentials....");
 

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getSmsGatewayeConfiguration";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetSmsGatewayConfig Credentials completed.");
            // int found = 0;
            return Tbl;
        }
         [HttpPost]
        public HttpResponseMessage SaveSmsGatewaySettings(SMSGatewayConfiguration b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSmsGatewaySettings credentials....");
 
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelSMSGatewayConfiguration";
            cmd.Connection = conn;
            conn.Open();

            SqlParameter id = new SqlParameter();
            id.ParameterName = "@Id";
            id.SqlDbType = SqlDbType.VarChar;
            id.Value = b.Id;
            cmd.Parameters.Add(id);
          

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@providername";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.providername;
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@enddate";
            lid.SqlDbType = SqlDbType.Date;
            lid.Value = b.enddate;
            cmd.Parameters.Add(lid);
           

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@hashkey";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value = b.hashkey;
            cmd.Parameters.Add(pid);         
           
            

            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@pwd";
            ii.SqlDbType = SqlDbType.VarChar;
            ii.Value = b.pwd;
            cmd.Parameters.Add(ii);
          

            SqlParameter vv = new SqlParameter();
            vv.ParameterName = "@saltkey";
            vv.SqlDbType = SqlDbType.VarChar;
            vv.Value =b.saltkey;
            cmd.Parameters.Add(vv);

            SqlParameter vvi = new SqlParameter();
            vvi.ParameterName = "@startdate";
            vvi.SqlDbType = SqlDbType.Date;
            vvi.Value =b.startdate;
            cmd.Parameters.Add(vvi);

            SqlParameter vvu = new SqlParameter();
            vvu.ParameterName = "@username";
            vvu.SqlDbType = SqlDbType.VarChar;
            vvu.Value = b.username;
            cmd.Parameters.Add(vvu);

            SqlParameter Cli = new SqlParameter();
            Cli.ParameterName = "@ClientId";
            Cli.SqlDbType = SqlDbType.VarChar;
            Cli.Value = b.ClientId;
            cmd.Parameters.Add(Cli);


            SqlParameter Sl = new SqlParameter();
            Sl.ParameterName = "@SecretId";
            Sl.SqlDbType = SqlDbType.VarChar;
            Sl.Value = b.SecretId;
            cmd.Parameters.Add(Sl);

            SqlParameter insdelflag = new SqlParameter("@insupdflag", SqlDbType.VarChar);
            insdelflag.Value = b.insupdflag;
            cmd.Parameters.Add(insdelflag);





            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
           // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSmsGatewaySettings Credentials completed.");
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

