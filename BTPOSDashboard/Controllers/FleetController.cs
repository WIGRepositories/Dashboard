using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
namespace BTPOSDashboard.Controllers
{
    public class FleetController : ApiController
    {
        [HttpGet]
  [Route("api/fleet/getFleetList")]
        public DataSet List(int cmpId, int fleetOwnerId)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetList credentials....");
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
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetList Credentials completed.");
            // int found = 0;
            return ds;
        }

        [HttpPost]
        public HttpResponseMessage NewFleetDetails(FleetDetails n)
        {
            SqlConnection conn = new SqlConnection();
            LogTraceWriter traceWriter = new LogTraceWriter();
            try
            {
              
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNewFleetDetails credentials....");
                //connect to database
               
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsupddelFleetDetails";
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

                SqlParameter stid = new SqlParameter("@ServiceTypeId", SqlDbType.VarChar);
                stid.SqlDbType = SqlDbType.Int;
                stid.Value = n.ServiceTypeId;
                cmd.Parameters.Add(stid);


                SqlParameter engg = new SqlParameter("@EngineNo", SqlDbType.VarChar);
                engg.SqlDbType = SqlDbType.VarChar;
                engg.Value = n.EngineNo;
                cmd.Parameters.Add(engg);

                SqlParameter fuel = new SqlParameter("@FuelUsed", SqlDbType.VarChar);
                fuel.SqlDbType = SqlDbType.VarChar;
                fuel.Value = n.FuelUsed;
                cmd.Parameters.Add(fuel);

                SqlParameter mntt = new SqlParameter("@MonthAndYrOfMfr", SqlDbType.VarChar);
                mntt.SqlDbType = SqlDbType.DateTime;
                mntt.Value = n.MonthAndYrOfMfr;
                cmd.Parameters.Add(mntt);

                SqlParameter chss = new SqlParameter("@ChasisNo", SqlDbType.VarChar);
                chss.SqlDbType = SqlDbType.VarChar;
                chss.Value = n.ChasisNo;
                cmd.Parameters.Add(chss);


                SqlParameter seatc = new SqlParameter("@SeatingCapacity", SqlDbType.VarChar);
                seatc.SqlDbType = SqlDbType.Int;
                seatc.Value = n.SeatingCapacity;
                cmd.Parameters.Add(seatc);


                SqlParameter deat = new SqlParameter("@DateOfRegistration", SqlDbType.VarChar);
                deat.SqlDbType = SqlDbType.DateTime;
                deat.Value = n.DateOfRegistration;
                cmd.Parameters.Add(deat);
               


                SqlParameter nActive = new SqlParameter("@Active", SqlDbType.Int);
                nActive.Value = n.Active;
                cmd.Parameters.Add(nActive);
               
                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@insupdflag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = n.insupddelflag;
                //llid.Value = b.Active;
                cmd.Parameters.Add(flag);
                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveNewFleetDetails Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveNewFleetDetails:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }


        [HttpGet]
        public DataSet VehicleConfiguration()
        {
            DataSet ds = new DataSet();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetVehicleConfiguration credentials....");
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
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetVehicleConfiguration Credentials completed.");
            return ds;
        }


        [HttpGet]
        public DataSet VehicleLayoutConfiguration(int vehicleLayoutTypeId)
        {
            DataSet ds = new DataSet();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetVehicleLayoutConfiguration credentials....");
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
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetVehicleLayoutConfiguration Credentials completed.");
            return ds;
        }
        
        
        public void Options()
        {
        }

    }
}
