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
    public class FleetOwnerRouteController : ApiController
    {
        [HttpGet]
        public DataTable getFleetOwnerRoute(int cmpId, int fleetownerId)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetOwnerRoute";
            cmd.Connection = conn;

            SqlParameter cmpid = new SqlParameter();
            cmpid.ParameterName = "@cmpId";
            cmpid.SqlDbType = SqlDbType.Int;
            cmpid.Value = cmpId;
            cmd.Parameters.Add(cmpid);

            SqlParameter foid = new SqlParameter();
            foid.ParameterName = "@fleetownerId";
            foid.SqlDbType = SqlDbType.Int;
            foid.Value = fleetownerId;
            cmd.Parameters.Add(foid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }

        [HttpPost]
        public DataTable saveFleetOwnerRoute(FleetownerRoute b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetOwnerRouterss";
            cmd.Connection = conn;
            conn.Open();
           
            SqlParameter ccdsa = new SqlParameter();
            ccdsa.ParameterName = "@CompanyName";
            ccdsa.SqlDbType = SqlDbType.Int;
            ccdsa.Value = Convert.ToString(b.RouteId);
            cmd.Parameters.Add(ccdsa);

         
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
        public void Options()
        {

        }
    }
}
