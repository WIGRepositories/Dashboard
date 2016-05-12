using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTPOSDashboard.Controllers
{
    public class LicensePricingController : ApiController
    {

        [HttpGet]
        public DataTable LicensePricing()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicensePricing";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
    
   
        [HttpPost]
        public DataTable SaveLicensePricing(LicensePricing b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelLicensePricing";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
           
              SqlParameter lid = new SqlParameter();
              lid.ParameterName = "@LicenseId";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToString(b.LicenseId);
            cmd.Parameters.Add(lid);

            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@TimePeriod";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.TimePeriod;
            cmd.Parameters.Add(ss);

             SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@MinTimePeriods";
            pid.SqlDbType = SqlDbType.Int;
            pid.Value = Convert.ToString(b.MinTimePeriods);
            cmd.Parameters.Add(pid);

            SqlParameter sid = new SqlParameter();
            sid.ParameterName = "@UnitPrice";
            sid.SqlDbType = SqlDbType.Int;
            sid.Value = Convert.ToString(b.UnitPrice);
            cmd.Parameters.Add(sid);

            SqlParameter gid = new SqlParameter();
            gid.ParameterName = "@todate";
            gid.SqlDbType = SqlDbType.DateTime;
            gid.Value = DateTime.Now;
            cmd.Parameters.Add(gid);

            SqlParameter fid = new SqlParameter();
            fid.ParameterName = "@fromdate";
            fid.SqlDbType = SqlDbType.DateTime;
            fid.Value = b.fromdate;
            cmd.Parameters.Add(fid);
            

              SqlParameter nActive = new SqlParameter("@Active", SqlDbType.Int);
                nActive.Value = b.Active;
                cmd.Parameters.Add(nActive);
                cmd.ExecuteScalar();
                conn.Close();
             

             //int found = 0;
            return Tbl;
        }
        public void Options() { }
    }
}


  