﻿using BTPOSDashboardAPI.Models;
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

        public HttpResponseMessage save(FORouteFleetSchedule n)
        {
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelFORouteFleetSchedule";
                cmd.Connection = conn;

                conn.Open();

                //SqlParameter gsa = new SqlParameter();
                //gsa.ParameterName = "@Id";
                //gsa.SqlDbType = SqlDbType.Int;
                //gsa.Value = n.Id;
                //cmd.Parameters.Add(gsa);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@VehicleId ";
                gsn.SqlDbType = SqlDbType.VarChar;
                gsn.Value = n.VehicleId;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@RouteId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = n.RouteId;
                cmd.Parameters.Add(gsab);

                SqlParameter gsab1 = new SqlParameter();
                gsab1.ParameterName = "@FleetOwnerId";
                gsab1.SqlDbType = SqlDbType.Int;
                gsab1.Value = n.FleetOwnerId;
                cmd.Parameters.Add(gsab1);

                SqlParameter gsac = new SqlParameter("@StopId", SqlDbType.VarChar);
                gsac.Value = n.StopId;
                gsac.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@ArrivalHr";
                gid.SqlDbType = SqlDbType.Int;
                gid.Value = n.ArrivalHr;
                cmd.Parameters.Add(gid);

                SqlParameter stid = new SqlParameter("@DepartureHr", SqlDbType.VarChar);
                stid.SqlDbType = SqlDbType.Int;
                stid.Value = n.DepartureHr;
                cmd.Parameters.Add(stid);


                SqlParameter engg = new SqlParameter("@Duration", SqlDbType.VarChar);
                engg.SqlDbType = SqlDbType.Decimal;
                engg.Value = n.Duration;
                cmd.Parameters.Add(engg);

                SqlParameter fuel = new SqlParameter("@ArrivalMin", SqlDbType.VarChar);
                fuel.SqlDbType = SqlDbType.Int;
                fuel.Value = n.ArrivalMin;
                cmd.Parameters.Add(fuel);

                SqlParameter mntt = new SqlParameter("@DepartureMin", SqlDbType.VarChar);
                mntt.SqlDbType = SqlDbType.Int;
                mntt.Value = n.DepartureMin;
                cmd.Parameters.Add(mntt);

                SqlParameter chss = new SqlParameter("@ArrivalAMPM", SqlDbType.VarChar);
                chss.SqlDbType = SqlDbType.VarChar;
                chss.Value = n.ArrivalAMPM;
                cmd.Parameters.Add(chss);


                SqlParameter chss1 = new SqlParameter("@DepartureAmPm", SqlDbType.VarChar);
                chss1.SqlDbType = SqlDbType.VarChar;
                chss1.Value = n.DepartureAmPm;
                cmd.Parameters.Add(chss1);

                SqlParameter ee = new SqlParameter("@StopName", SqlDbType.VarChar);
                ee.SqlDbType = SqlDbType.VarChar;
                ee.Value = n.StopName;
                cmd.Parameters.Add(ee);

                SqlParameter ee1 = new SqlParameter("@StopCode", SqlDbType.VarChar);
                ee1.SqlDbType = SqlDbType.VarChar;
                ee1.Value = n.StopCode;
                cmd.Parameters.Add(ee1);

                SqlParameter ee2 = new SqlParameter("@StopNo", SqlDbType.VarChar);
                ee2.SqlDbType = SqlDbType.Int;
                ee2.Value = n.StopNo;
                cmd.Parameters.Add(ee2);


                SqlParameter seatc = new SqlParameter("@arrivaltime", SqlDbType.VarChar);
                seatc.SqlDbType = SqlDbType.Int;
                seatc.Value = n.arrivaltime;
                cmd.Parameters.Add(seatc);


                SqlParameter deat = new SqlParameter("@departuretime", SqlDbType.VarChar);
                deat.SqlDbType = SqlDbType.Int;
                deat.Value = n.departuretime;
                cmd.Parameters.Add(deat);

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

           
    }
}
