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
        public DataTable saveFleetOwnerRoutefare(IEnumerable<FleetOwnerRouteFare> fareList)
        {
            DataTable Tbl = new DataTable();



            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelFleetOwnerRouteFare";
            cmd.Connection = conn;
            conn.Open();

            foreach (FleetOwnerRouteFare b in fareList)
            {
                SqlParameter ccd = new SqlParameter();
                ccd.ParameterName = "@RouteId";
                ccd.SqlDbType = SqlDbType.Int;
                ccd.Value = b.RouteId;
                cmd.Parameters.Add(ccd);

                SqlParameter ccdf = new SqlParameter();
                ccdf.ParameterName = "@FromStopId";
                ccdf.SqlDbType = SqlDbType.Int;
                ccdf.Value = b.FromStopId;
                cmd.Parameters.Add(ccdf);

                SqlParameter ccdff = new SqlParameter();
                ccdff.ParameterName = "@ToStopId";
                ccdff.SqlDbType = SqlDbType.Int;
                ccdff.Value = b.ToStopId;
                cmd.Parameters.Add(ccdff);

                SqlParameter cname = new SqlParameter();
                cname.ParameterName = "@VehicleTypeId";
                cname.SqlDbType = SqlDbType.VarChar;
                cname.Value = b.VehicleTypeId;
                cmd.Parameters.Add(cname);


                SqlParameter dd = new SqlParameter();
                dd.ParameterName = "@Distance";
                dd.SqlDbType = SqlDbType.Decimal;
                dd.Value = b.Distance;
                cmd.Parameters.Add(dd);

                SqlParameter pup = new SqlParameter();
                pup.ParameterName = "@PerUnitPrice";
                pup.SqlDbType = SqlDbType.Decimal;
                pup.Value = b.PerUnitPrice;
                cmd.Parameters.Add(pup);

                SqlParameter pupa = new SqlParameter();
                pupa.ParameterName = "@Amount";
                pupa.SqlDbType = SqlDbType.Decimal;
                pupa.Value = b.Amount;
                cmd.Parameters.Add(pupa);

                SqlParameter dda = new SqlParameter();
                dda.ParameterName = "@FareTypeId";
                dda.SqlDbType = SqlDbType.Int;
                dda.Value = b.FareTypeId;
                cmd.Parameters.Add(dda);


                SqlParameter aa = new SqlParameter();
                aa.ParameterName = "@Active";
                aa.SqlDbType = SqlDbType.Int;
                aa.Value = b.Active;
                cmd.Parameters.Add(aa);

                SqlParameter fd = new SqlParameter();
                fd.ParameterName = "@FromDate";
                fd.SqlDbType = SqlDbType.DateTime;
                fd.Value = b.FromDate;
                cmd.Parameters.Add(fd);


                SqlParameter td = new SqlParameter();
                td.ParameterName = "@ToDate";
                td.SqlDbType = SqlDbType.DateTime;
                td.Value = b.ToDate;
                cmd.Parameters.Add(td);


                SqlParameter vid = new SqlParameter();
                vid.ParameterName = "@VehicleId";
                vid.SqlDbType = SqlDbType.Int;
                vid.Value = b.VehicleId;
                cmd.Parameters.Add(vid);

            
                cmd.ExecuteScalar();

                cmd.Parameters.Clear();
            }
            conn.Close();
            // int found = 0;
            return Tbl;
        }
        public void Options()
        {

        }
    }
}
