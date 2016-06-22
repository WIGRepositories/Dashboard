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
    public class SMSformatsController : ApiController
    {
        [HttpGet]
        public DataTable Smsform()//Main Method
        {
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetSMSformats";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage Smsforms(Smsformat s)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {


                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insSMSformats";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter SId = new SqlParameter();
                SId.ParameterName = "@Id";
                SId.SqlDbType = SqlDbType.Int;
                SId.Value = Convert.ToString(s.Id);
                cmd.Parameters.Add(SId);
                SqlParameter smessage = new SqlParameter();
                smessage.ParameterName = "@message";
                smessage.SqlDbType = SqlDbType.VarChar;
                smessage.Value = s.message;
                cmd.Parameters.Add(smessage);
                SqlParameter sActive = new SqlParameter();
                sActive.ParameterName = "@Active ";
                sActive.SqlDbType = SqlDbType.Int;
                sActive.Value = Convert.ToString(s.Active);
                cmd.Parameters.Add(sActive);
                SqlParameter sDesc1 = new SqlParameter();
                sDesc1.ParameterName = "@Desc1";
                sDesc1.SqlDbType = SqlDbType.VarChar;
                sDesc1.Value = s.Desc1;
                cmd.Parameters.Add(sDesc1);

                SqlParameter sfromaddr = new SqlParameter();
                sfromaddr.ParameterName = "@fromaddr ";
                sfromaddr.SqlDbType = SqlDbType.VarChar;
                sfromaddr.Value = s.fromaddr;
                cmd.Parameters.Add(sfromaddr);
                SqlParameter sToAddr = new SqlParameter();
                sToAddr.ParameterName = "@ToAddr ";
                sToAddr.SqlDbType = SqlDbType.VarChar;
                sToAddr.Value = s.ToAddr;
                cmd.Parameters.Add(sToAddr);
                SqlParameter sBTPOSGrpId = new SqlParameter();
                sBTPOSGrpId.ParameterName = "@BTPOSGrpId";
                sBTPOSGrpId.SqlDbType = SqlDbType.Int;
                sBTPOSGrpId.Value = Convert.ToString(s.BTPOSGrpId);
                cmd.Parameters.Add(sBTPOSGrpId);



                cmd.ExecuteScalar();
                conn.Close();

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
