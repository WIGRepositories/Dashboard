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
    public class FleetOwnerRouteFareController : ApiController
    {
        [HttpGet]
        public DataTable GetFOVehicleFareConfig(int vehicleId, int routeId)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFOVehicleFareConfig";
            cmd.Connection = conn;

            SqlParameter ccd = new SqlParameter();
            ccd.ParameterName = "@vehicleid";
            ccd.SqlDbType = SqlDbType.Int;
            ccd.Value = vehicleId;
            cmd.Parameters.Add(ccd);

            SqlParameter rid = new SqlParameter();
            rid.ParameterName = "@routeId";
            rid.SqlDbType = SqlDbType.Int;
            rid.Value = routeId;

            cmd.Parameters.Add(rid);
            
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable saveFleetOwnerRoutefare(FleetOwnerRouteFare b)
        {
            DataTable Tbl = new DataTable();



            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELRouteFare";
            cmd.Connection = conn;
            conn.Open();
           
            SqlParameter ccd = new SqlParameter();
            ccd.ParameterName = "@RouteId";
            ccd.SqlDbType = SqlDbType.Int;
            ccd.Value = Convert.ToString(b.RouteId);
            cmd.Parameters.Add(ccd);
            SqlParameter ccdf = new SqlParameter();
            ccdf.ParameterName = "@FleetOwnerId";
            ccdf.SqlDbType = SqlDbType.Int;
            ccdf.Value = Convert.ToString(b.FleetOwnerId);
            cmd.Parameters.Add(ccdf);
            SqlParameter ccdff = new SqlParameter();
            ccdff.ParameterName = "@CompanyId";
            ccdff.SqlDbType = SqlDbType.Int;
            ccdff.Value = Convert.ToString(b.CompanyId);
            cmd.Parameters.Add(ccdff);

            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@VehicleType";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.VehicleType;
            cmd.Parameters.Add(cname);
            SqlParameter ccds = new SqlParameter();
            ccds.ParameterName = "@SourceStopId";
            ccds.SqlDbType = SqlDbType.Int;
            ccds.Value = Convert.ToString(b.SourceStopId);
            cmd.Parameters.Add(ccds);
            SqlParameter ccdsa = new SqlParameter();
            ccdsa.ParameterName = "@DestinationStopId";
            ccdsa.SqlDbType = SqlDbType.Int;
            ccdsa.Value = Convert.ToString(b.DestinationStopId);
            cmd.Parameters.Add(ccdsa);

            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@Distance";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value = b.Distance;
            cmd.Parameters.Add(dd);
            SqlParameter pup = new SqlParameter();
            pup.ParameterName = "@PerUnitPrice";
            pup.SqlDbType = SqlDbType.Int;
            pup.Value = Convert.ToString(b.PerUnitPrice);
            cmd.Parameters.Add(pup);
            SqlParameter pupa = new SqlParameter();
            pupa.ParameterName = "@Amount";
            pupa.SqlDbType = SqlDbType.Int;
            pupa.Value = Convert.ToString(b.Amount);
            cmd.Parameters.Add(pupa);
            SqlParameter dda = new SqlParameter();
            dda.ParameterName = "@FareType";
            dda.SqlDbType = SqlDbType.VarChar;
            dda.Value = b.FareType;
            cmd.Parameters.Add(dda);


            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@Active";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.Active;
            cmd.Parameters.Add(aa);


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
