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
    public class FleetController : ApiController
    {
        [HttpGet]
  [Route("api/fleet/getFleetList")]
        public DataSet List()
        {
            DataTable Tbl = new DataTable();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
            // Tbl = ds.Tables[0];

            // int found = 0;
            return ds;
        }

        [HttpPost]
        public DataTable NewFleetDetails(FleetDetails n)
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
                cmd.CommandText = "InsupdelFleetDetails";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Id";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = n.Id;
                cmd.Parameters.Add(gsa);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@VehicleRegNo";
                gsn.SqlDbType = SqlDbType.VarChar;
                gsn.Value = n.VehicleRegNo;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@VehicleTypeId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = n.VehicleTypeId;
                cmd.Parameters.Add(gsab);

                SqlParameter gsac = new SqlParameter("@FleetOwnerId", SqlDbType.VarChar);
                gsac.Value = n.FleetOwnerId;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@CompanyId";
                gid.SqlDbType = SqlDbType.VarChar;
                gid.Value = n.CompanyId;
                cmd.Parameters.Add(gid);

                SqlParameter nser = new SqlParameter("@ServiceTypeId", SqlDbType.VarChar);
                nser.Value = n.ServiceTypeId;
                cmd.Parameters.Add(nser);

                SqlParameter nActive = new SqlParameter("@Active", SqlDbType.Int);
                nActive.Value = n.Active;
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
