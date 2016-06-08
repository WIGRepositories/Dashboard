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
        public DataSet List(int cmpId, int fleetOwnerId)
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

            SqlParameter gid = new SqlParameter();
            gid.ParameterName = "@cmpId";
            gid.SqlDbType = SqlDbType.Int;
            gid.Value = cmpId;
            cmd.Parameters.Add(gid);

            SqlParameter fid = new SqlParameter();
            fid.ParameterName = "@fleetOwnerId";
            fid.SqlDbType = SqlDbType.Int;
            fid.Value = fleetOwnerId;
            cmd.Parameters.Add(fid);

            
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

                SqlParameter gsab1 = new SqlParameter();
                gsab1.ParameterName = "@VehicleLayoutId";
                gsab1.SqlDbType = SqlDbType.Int;
                gsab1.Value = n.VehicleLayoutId;
                cmd.Parameters.Add(gsab1);

                SqlParameter gsac = new SqlParameter("@FleetOwnerId", SqlDbType.VarChar);
                gsac.Value = n.FleetOwnerId;
                gsac.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@CompanyId";
                gid.SqlDbType = SqlDbType.Int;
                gid.Value = n.CompanyId;
                cmd.Parameters.Add(gid);

                SqlParameter nser = new SqlParameter("@ServiceTypeId", SqlDbType.VarChar);
                nser.SqlDbType = SqlDbType.Int;
                nser.Value = n.ServiceTypeId;
                cmd.Parameters.Add(nser);


                SqlParameter engg = new SqlParameter("@EngineNo", SqlDbType.VarChar);
                engg.SqlDbType = SqlDbType.Int;
                engg.Value = n.ServiceTypeId;
                cmd.Parameters.Add(nser);

                SqlParameter fuel = new SqlParameter("@FuelUsed", SqlDbType.VarChar);
                fuel.SqlDbType = SqlDbType.Int;
                fuel.Value = n.ServiceTypeId;
                cmd.Parameters.Add(nser);

                SqlParameter mntt = new SqlParameter("@MonthAndYrOfMfr", SqlDbType.VarChar);
                mntt.SqlDbType = SqlDbType.Int;
                mntt.Value = n.ServiceTypeId;
                cmd.Parameters.Add(nser);

                SqlParameter chss = new SqlParameter("@ChasisNo", SqlDbType.VarChar);
                chss.SqlDbType = SqlDbType.Int;
                chss.Value = n.ServiceTypeId;
                cmd.Parameters.Add(nser);


                SqlParameter seatc = new SqlParameter("@SeatingCapacity", SqlDbType.VarChar);
                seatc.SqlDbType = SqlDbType.Int;
                seatc.Value = n.ServiceTypeId;
                cmd.Parameters.Add(nser);


                SqlParameter deat = new SqlParameter("@DateOfRegistration", SqlDbType.VarChar);
                deat.SqlDbType = SqlDbType.Int;
                deat.Value = n.ServiceTypeId;
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


        [HttpGet]
        public DataSet VehicleLayoutConfiguration(int vehicleLayoutTypeId)
        {
            DataSet ds = new DataSet();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetVehicleLayoutConfiguration";
            cmd.Connection = conn;


            SqlParameter gsa = new SqlParameter();
            gsa.ParameterName = "@vlTypeId";
            gsa.SqlDbType = SqlDbType.Int;
            gsa.Value = vehicleLayoutTypeId;
            cmd.Parameters.Add(gsa);

            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);

            return ds;
        }
        
        
        public void Options()
        {
        }

    }
}
