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
    public class UserLoginsController : ApiController
    {
        [HttpGet]
        public DataTable users()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUserLogins credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUserLogins";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetUserLogins Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage userlogins(UserLogin b)
        {
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Saveuserlogins credentials...."); 
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            { 
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelUserLogins";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
            SqlParameter iid = new SqlParameter();
            iid.ParameterName = "@UserId";
            iid.SqlDbType = SqlDbType.Int;
            iid.Value = Convert.ToString(b.UserId);
            cmd.Parameters.Add(iid);
            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@LoginInfo";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value = b.LoginInfo;
            cmd.Parameters.Add(pid);
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@Passkey";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.Passkey;
            cmd.Parameters.Add(ss);
            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@Salt";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value = b.Salt;
            cmd.Parameters.Add(dd);
            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@Active";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.Active;
            cmd.Parameters.Add(aa);

            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Saveuserlogins Credentials completed.");
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




        [HttpPost]
        [Route("api/UserLogins/ResetPassword")]
        public HttpResponseMessage savepassword(reset b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveResetPassword credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            { 
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getresetpassword";
            cmd.Connection = conn;
            conn.Open();


            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@UserName";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.UserName;
            cmd.Parameters.Add(Gid);


            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@OldPassword";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value = b.OldPassword;
            cmd.Parameters.Add(pid);

            SqlParameter uid = new SqlParameter();
            uid.ParameterName = "@NewPassword";
            uid.SqlDbType = SqlDbType.VarChar;
            uid.Value = b.NewPassword;
            cmd.Parameters.Add(uid);


            SqlParameter gid = new SqlParameter();
            gid.ParameterName = "@ReenterNewPassword";
            gid.SqlDbType = SqlDbType.VarChar;
            gid.Value = b.ReenterNewPassword;
            cmd.Parameters.Add(gid);

            SqlParameter oid = new SqlParameter();

            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveResetPassword Credentials completed.");
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
    }
 
    }
