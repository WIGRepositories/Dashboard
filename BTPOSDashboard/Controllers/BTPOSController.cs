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
    public class BTPOSRoutesController : ApiController
    {
        [HttpGet]
        public DataTable Btpos()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOS";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable pos(Btpos b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelBTPOS";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@GroupId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = Convert.ToString(b.GroupId);
            cmd.Parameters.Add(Gid);
            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@POSId";
            pid.SqlDbType = SqlDbType.Int;
            pid.Value = Convert.ToString(b.POSId);
            cmd.Parameters.Add(pid);
          
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@Status";
            ss.SqlDbType = SqlDbType.NVarChar;
            ss.Value = b.Status;
            cmd.Parameters.Add(ss);

            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@IMEI";
            ii.SqlDbType = SqlDbType.VarChar;
            ii.Value = b.IMEI;
            cmd.Parameters.Add(ii);
            SqlParameter ll = new SqlParameter();
            ll.ParameterName = "@Location";
            ll.SqlDbType = SqlDbType.VarChar;
            ll.Value = b.Location;
            cmd.Parameters.Add(ll);

            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
           // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
              public void Options(){}

              //[HttpGet]
              //[Route("api/BtposRoutes/getBtposRoutes")]
              //public DataTable getBtposRoutes()
              //{
              //    DataTable Tb1 = new DataTable();


              //    //connect to database
              //    SqlConnection conn = new SqlConnection();
              //    //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
              //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

              //    SqlCommand cmd = new SqlCommand();
              //    cmd.CommandType = CommandType.StoredProcedure;
              //    cmd.CommandText = "GetBTposRoutes";
              //    cmd.Connection = conn;
              //    DataSet ds = new DataSet();
              //    SqlDataAdapter db = new SqlDataAdapter(cmd);
              //    db.Fill(ds);
              //    Tb1 = ds.Tables[0];

              //    // int found = 0;
              //    return Tb1;


              //}
           
    }
}



    

