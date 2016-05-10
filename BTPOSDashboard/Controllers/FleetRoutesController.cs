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

    public class FleetRoutesController : ApiController
    {

        [HttpGet]
        public DataSet GetFleetRoutes()
        {
            DataTable Tbl = new DataTable();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetfleetRoutes";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(ds);
             Tbl = ds.Tables[0];

            // int found = 0;
            return ds;
        }

        public DataTable NewFleetRoutes(FleetRoutes f)
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
                cmd.CommandText = "insupdelFleetRoutes";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Id";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = f.Id;
                cmd.Parameters.Add(gsa);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@VehicleId";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = f.VehicleId;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@RouteId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = f.RouteId;
                cmd.Parameters.Add(gsab);

                SqlParameter gsac = new SqlParameter("@EffectiveFrom", SqlDbType.DateTime);
                gsac.Value = f.EffectiveFrom;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@EffectiveTill";
                gid.SqlDbType = SqlDbType.DateTime;
                gid.Value = f.EffectiveTill;
                cmd.Parameters.Add(gid);
            
                SqlParameter nActive = new SqlParameter("@Active", SqlDbType.Int);
                nActive.Value = f.Active;
                cmd.Parameters.Add(nActive);
                cmd.ExecuteScalar();
                conn.Close();
                DataSet ds = new DataSet();
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
        public void Options()
        {
        }

    }
}
