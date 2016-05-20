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
            //[HttpPost]
           
            //    public DataSet AddFleetStaff(FleetStaff fs)
            //    {
            //        DataTable tb1 = new DataTable();
            //        try
            //        {
            //            SqlConnection con = new SqlConnection();
            //            con.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //            SqlCommand cmd = new SqlCommand();
            //            cmd.CommandType = CommandType.StoredProcedure;
            //            cmd.CommandText = "InsupdelFleetDetails";
            //            cmd.Connection = con;

            //            con.Open();
            //        }
            //        return;
            //    }


            }
        
}                     
