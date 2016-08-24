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
    public class BTPOSOperatorsController : ApiController
    {
        [HttpGet]
        public DataTable BTPOSOP()//Main Method
        {
            DataTable Tbl = new DataTable();


            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSOP credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetBTPOSOperators";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSOP Credentials completed.");
            // int found = 0;
            return Tbl;
        }
         [HttpPost]
        public HttpResponseMessage BTPOSOPs(BTPOSOPRTR O)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "PostBTPOSOPs credentials....");
 
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database
                
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insBTPOSOperators";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter OId = new SqlParameter();
                OId.ParameterName = "@Id";
                OId.SqlDbType = SqlDbType.Int;
                OId.Value = Convert.ToString(O.Id);
                cmd.Parameters.Add(OId);
                SqlParameter OBTPOSId = new SqlParameter();
                OBTPOSId.ParameterName = "@BTPOSId";
                OBTPOSId.SqlDbType = SqlDbType.Int;
                OBTPOSId.Value  = Convert.ToString(O.BTPOSId);
                cmd.Parameters.Add(OBTPOSId);
                SqlParameter OUserid = new SqlParameter();
                OUserid.ParameterName = "@Userid ";
                OUserid.SqlDbType = SqlDbType.Int;
                OUserid.Value = Convert.ToString(O.Userid);
                cmd.Parameters.Add(OUserid);
                SqlParameter OActive = new SqlParameter();
                OActive.ParameterName = "@Active ";
                OActive.SqlDbType = SqlDbType.Int;
                OActive.Value = Convert.ToString(O.Active);
                cmd.Parameters.Add(OActive);
                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "PostBTPOSOPs Credentials completed.");
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

    




