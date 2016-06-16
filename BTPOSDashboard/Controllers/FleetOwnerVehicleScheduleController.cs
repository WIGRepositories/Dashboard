using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;
namespace BTPOSDashboard.Controllers
{
    public class FleetOwnerVehicleScheduleController : ApiController
    {
        [HttpGet]
        [Route("api/FleetOwnerVehicleSchedule/getFORVehicleSchedule")]
        public DataTable getFORVehicleSchedule(int fleetownerid, int routeid, int vehicleId)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getFORVehicleSchedule";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            SqlParameter fo = new SqlParameter();
            fo.ParameterName = "@fleetownerId";
            fo.SqlDbType = SqlDbType.Int;
            fo.Value = fleetownerid;
            cmd.Parameters.Add(fo);

            SqlParameter fsc = new SqlParameter();
            fsc.ParameterName = "@vehicleId";
            fsc.SqlDbType = SqlDbType.Int;
            fsc.Value = vehicleId;
            cmd.Parameters.Add(fsc);

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@routeid";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = routeid;
            cmd.Parameters.Add(cid);

            db.Fill(Tbl);
          
            return Tbl;
       }

        [HttpPost]
        public DataTable saveFORVehicleSchedule(IEnumerable<FORVehicleSchedule> schedList)
        {
            DataTable Tbl = new DataTable();



            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelFORVehicleSchedule";
            cmd.Connection = conn;
            conn.Open();

            foreach (FORVehicleSchedule b in schedList)
            {
                 SqlParameter vid = new SqlParameter();
                vid.ParameterName = "@VehicleId";
                vid.SqlDbType = SqlDbType.Int;
                vid.Value = b.VehicleId;
                cmd.Parameters.Add(vid);

                SqlParameter ccd = new SqlParameter();
                ccd.ParameterName = "@RouteId";
                ccd.SqlDbType = SqlDbType.Int;
                ccd.Value = b.RouteId;
                cmd.Parameters.Add(ccd);

                SqlParameter ccdf = new SqlParameter();
                ccdf.ParameterName = "@StopId";
                ccdf.SqlDbType = SqlDbType.Int;
                ccdf.Value = b.StopId;
                cmd.Parameters.Add(ccdf);

                SqlParameter ccdff = new SqlParameter();
                ccdff.ParameterName = "@FleetOwnerId";
                ccdff.SqlDbType = SqlDbType.Int;
                ccdff.Value = b.FleetOwnerId;
                cmd.Parameters.Add(ccdff);

                SqlParameter cname = new SqlParameter();
                cname.ParameterName = "@ArrivalHr";
                cname.SqlDbType = SqlDbType.VarChar;
                cname.Value = b.ArrivalHr;
                cmd.Parameters.Add(cname);


                SqlParameter dd = new SqlParameter();
                dd.ParameterName = "@DepartureHr";
                dd.SqlDbType = SqlDbType.Decimal;
                dd.Value = b.DepartureHr;
                cmd.Parameters.Add(dd);

                SqlParameter pup = new SqlParameter();
                pup.ParameterName = "@ArrivalMin";
                pup.SqlDbType = SqlDbType.Decimal;
                pup.Value = b.ArrivalMin;
                cmd.Parameters.Add(pup);

                SqlParameter pupa = new SqlParameter();
                pupa.ParameterName = "@DepartureMin";
                pupa.SqlDbType = SqlDbType.Decimal;
                pupa.Value = b.DepartureMin;
                cmd.Parameters.Add(pupa);               

                SqlParameter fd = new SqlParameter();
                fd.ParameterName = "@ArrivalTime";
                fd.SqlDbType = SqlDbType.DateTime;
                fd.Value = b.ArrivalTime;
                cmd.Parameters.Add(fd);


                SqlParameter td = new SqlParameter();
                td.ParameterName = "@DepartureTime";
                td.SqlDbType = SqlDbType.DateTime;
                td.Value = b.DepartureTime;
                cmd.Parameters.Add(td);

                SqlParameter am = new SqlParameter();
                am.ParameterName = "@ArrivalAMPM";
                am.SqlDbType = SqlDbType.VarChar;
                am.Value = b.arrMeridian;
                cmd.Parameters.Add(am);

                 SqlParameter dm = new SqlParameter();
                 dm.ParameterName = "@DepartureAMPM";
                dm.SqlDbType = SqlDbType.VarChar;
                dm.Value = b.deptMeridian;
                cmd.Parameters.Add(dm);

                 SqlParameter d = new SqlParameter();
                d.ParameterName = "@Duration";
                d.SqlDbType = SqlDbType.Decimal;
                d.Value = b.duration;
                cmd.Parameters.Add(d);

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
