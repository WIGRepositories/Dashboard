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
        [Route("api/FleetOwnerRoute/getFleetOwnerRoute")]
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

        [HttpGet]
        [Route("api/FleetOwnerRoute/GetFleetOwnerRouteAssigned")]
        public DataTable GetFleetOwnerRouteAssigned(int fleetownerId)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetOwnerRouteAssigned";
            cmd.Connection = conn;

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
        public HttpResponseMessage saveFleetOwnerRoute(IEnumerable<FleetownerRoute> foRoutes)
         {
            SqlConnection conn = new SqlConnection();
            try
            {


            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelFleetOwnerRoutes";
            cmd.Connection = conn;
            conn.Open();

            foreach (FleetownerRoute b  in foRoutes)
            {

                SqlParameter rid = new SqlParameter();
                rid.ParameterName = "@RouteId";
                rid.SqlDbType = SqlDbType.Int;
                rid.Value = b.RouteId;
                cmd.Parameters.Add(rid);

                SqlParameter cmpid = new SqlParameter();
                cmpid.ParameterName = "@cmpId";
                cmpid.SqlDbType = SqlDbType.Int;
                cmpid.Value = b.CompanyId;
                cmd.Parameters.Add(cmpid);


                SqlParameter fid = new SqlParameter();
                fid.ParameterName = "@fleetOwnerId";
                fid.SqlDbType = SqlDbType.Int;
                fid.Value = b.FleetOwnerId;
                cmd.Parameters.Add(fid);


                SqlParameter fdt = new SqlParameter();
                fdt.ParameterName = "@FromDate";
                fdt.SqlDbType = SqlDbType.DateTime;
                fdt.Value = b.From;
                cmd.Parameters.Add(fdt);

                SqlParameter tdt = new SqlParameter();
                tdt.ParameterName = "@ToDate";
                tdt.SqlDbType = SqlDbType.DateTime;
                tdt.Value = b.To;
                cmd.Parameters.Add(tdt);

                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@insupddelflag";
                flag.SqlDbType = SqlDbType.Char;
                flag.Value = b.insupddelflag;
                cmd.Parameters.Add(flag);

                cmd.ExecuteScalar();

                cmd.Parameters.Clear();
            }

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
    }
}
