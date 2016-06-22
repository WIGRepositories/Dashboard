using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboard.Controllers
{
    public class FleetBtposController : ApiController
    {
        [HttpGet]
        public DataTable GetFleebtDetails(int sId, int cmpid)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetBtpos";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            SqlParameter fo = new SqlParameter();
            fo.ParameterName = "@fleetownerId";
            fo.SqlDbType = SqlDbType.Int;
            fo.Value = sId;
            cmd.Parameters.Add(fo);

            SqlParameter fsc = new SqlParameter();
            fsc.ParameterName = "@cmpId";
            fsc.SqlDbType = SqlDbType.Int;
            fsc.Value = cmpid;
            cmd.Parameters.Add(fsc);

            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }

        [HttpPost]
        public HttpResponseMessage AssignFleetBTPOS(FleetBTPOS fb)
        {
            SqlConnection conn = new SqlConnection();
            try
            {


                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelFleetBTPOS";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@Id";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = fb.Id;
                cmd.Parameters.Add(gsa);

                SqlParameter vid = new SqlParameter();
                vid.ParameterName = "@VehicleId";
                vid.SqlDbType = SqlDbType.Int;
                vid.Value = fb.vehicleId;
                cmd.Parameters.Add(vid);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@btposId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = fb.BTPOSId;
                cmd.Parameters.Add(gsab);

                SqlParameter gsac = new SqlParameter("@FromDate", SqlDbType.DateTime);
                gsac.ParameterName = "@FromDate";
                gsac.SqlDbType = SqlDbType.DateTime;
                gsac.Value = fb.FromDate;
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@ToDate";
                gid.SqlDbType = SqlDbType.DateTime;
                gid.Value = fb.ToDate;
                cmd.Parameters.Add(gid);

                SqlParameter flag = new SqlParameter("@insupddelflag", SqlDbType.Char);
                flag.Value = fb.insupddelflag;
                cmd.Parameters.Add(flag);

                cmd.ExecuteScalar();
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


