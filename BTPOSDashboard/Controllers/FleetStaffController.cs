using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboard.Controllers
{
  
    
        public class FleetStaffController : ApiController
        {
            [HttpGet]
            [Route("api/FleetStaff/GetFleetStaff")]
            public DataSet GetFleetStaff()
            {
                DataTable Tbl = new DataTable();

                //connect to database
                SqlConnection conn = new SqlConnection();
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetFleetStaff";
                cmd.Connection = conn;
                DataSet ds = new DataSet();
                SqlDataAdapter db = new SqlDataAdapter(cmd);

                db.Fill(ds);
                // Tbl = ds.Tables[0];

                // int found = 0;
                return ds;
            }  
           
             [HttpPost]
        public DataTable NewFleetStaff(FleetStaff f)
        {
            DataTable Tbl = new DataTable();

            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsupdelFleetStaff";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Id";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = f.Id;
                cmd.Parameters.Add(gsa);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@StaffRole";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = f.StaffRole;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@UserId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = f.UserId;
                cmd.Parameters.Add(gsab);

                SqlParameter gsac = new SqlParameter("@FromDate", SqlDbType.DateTime);
                gsac.Value = f.FromDate;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@ToDate";
                gid.SqlDbType = SqlDbType.DateTime;
                gid.Value = f.ToDate;
                cmd.Parameters.Add(gid);

                SqlParameter nActive = new SqlParameter("@Active", SqlDbType.Int);
                nActive.Value = f.Active;
                cmd.Parameters.Add(nActive);
                cmd.ExecuteScalar();
                conn.Close();
             
               // DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                //Tbl = ds.Tables[0];

            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            // int found = 0;
           return Tbl;

        }
        [HttpGet]
        public DataSet VehicleConfiguration()
        {
            DataSet ds = new DataSet();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VehicleConfiguration";
            cmd.Connection = conn;

            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);

            return ds;
        }
        public void Options()
        {
        }


    }
}

            
        
                    
