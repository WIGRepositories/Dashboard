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
    public class FleetAvailabilityController : ApiController
    {
        [HttpGet]
        [Route("api/FleetAvailability/GetFleetAvailability")]
        public DataSet List()
        {
            DataTable Tbl = new DataTable();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetAvailability";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            // Tbl = ds.Tables[0];

            // int found = 0;
            return ds;
        }
    }
}
//       [HttpPost]
//        public DataTable saveFleet(FleetAvailability b)
//        {
//            DataTable Tbl = new DataTable();


//            //connect to database
//            SqlConnection conn = new SqlConnection();
//            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
//            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

//            SqlCommand cmd = new SqlCommand();
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.CommandText = "InsUpdDelFleetAvailability";
//            cmd.Connection = conn;
//            conn.Open();
//            SqlParameter cc = new SqlParameter();
//            cc.ParameterName = "@Id";
//            cc.SqlDbType = SqlDbType.Int;
//            cc.Value = b.Id;
//            cmd.Parameters.Add(cc);
//            //SqlParameter cname = new SqlParameter();
//            //cname.ParameterName = "@Vehicle";
//            //cname.SqlDbType = SqlDbType.VarChar;
//            //cname.Value = b.Vehicle;
//            //cmd.Parameters.Add(cname);

//            //SqlParameter cType = new SqlParameter();
//            //cType.ParameterName = "@ServiceType";
//            //cType.SqlDbType = SqlDbType.VarChar;
//            //cType.Value = b.ServiceType;
//            //cmd.Parameters.Add(cType);
//            //SqlParameter gsac = new SqlParameter("@FromDate", SqlDbType.DateTime);
//            //gsac.Value = b.FromDate;
//            //cmd.Parameters.Add(gsac);


//            //SqlParameter gsacd = new SqlParameter("@ToDate", SqlDbType.DateTime);
//            //gsacd.Value = b.ToDate;
//            //cmd.Parameters.Add(gsacd);

           


//            //DataSet ds = new DataSet();
//            //SqlDataAdapter db = new SqlDataAdapter(cmd);
//            //db.Fill(ds);
//            // Tbl = Tables[0];
//            cmd.ExecuteScalar();
//            conn.Close();
//            // int found = 0;
//            return Tbl;
//        }
//        public void Options()
//        {

//        }
//    }
//}
