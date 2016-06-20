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
    public class VehicleDetailsController : ApiController
    {
        [HttpGet]
    
        public DataTable getVehicleDetails()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getVehicleDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]

        public HttpResponseMessage saveVehicleDetails(VehicleDetails n)
        {
           
            SqlConnection conn = new SqlConnection();

            try
            {

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelVehicleDetails";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@busId";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = Convert.ToString(n.busId);
                cmd.Parameters.Add(gsa);

                SqlParameter gsaa = new SqlParameter();
                gsaa.ParameterName = "@busTypeId";
                gsaa.SqlDbType = SqlDbType.Int;
                gsaa.Value = Convert.ToString(n.busTypeId);
                cmd.Parameters.Add(gsaa);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@conductorId";
                gsab.SqlDbType = SqlDbType.Int;
                gsab.Value = Convert.ToString(n.conductorId);
                cmd.Parameters.Add(gsab);

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@conductorName";
                gs.SqlDbType = SqlDbType.VarChar;
                gs.Value = n.conductorName;
                cmd.Parameters.Add(gs);

                SqlParameter gsac = new SqlParameter();
                gsac.ParameterName = "@driverId";
                gsac.SqlDbType = SqlDbType.Int;
                gsac.Value = Convert.ToString(n.driverId);
                cmd.Parameters.Add(gsac);

                SqlParameter gsk = new SqlParameter();
                gsk.ParameterName = "@driverName";
                gsk.SqlDbType = SqlDbType.VarChar;
                gsk.Value = n.driverName;
                cmd.Parameters.Add(gsk);

                SqlParameter gsabc = new SqlParameter();
                gsabc.ParameterName = "@fleetOwnerId";
                gsabc.SqlDbType = SqlDbType.Int;
                gsabc.Value = Convert.ToString(n.fleetOwnerId);
                cmd.Parameters.Add(gsabc);

                SqlParameter gska = new SqlParameter();
                gska.ParameterName = "@CompanyName";
                gska.SqlDbType = SqlDbType.VarChar;
                gska.Value = n.CompanyName;
                cmd.Parameters.Add(gska);

                SqlParameter gsacd = new SqlParameter();
                gsacd.ParameterName = "@Id";
                gsacd.SqlDbType = SqlDbType.Int;
                gsacd.Value = Convert.ToString(n.Id);
                cmd.Parameters.Add(gsacd);

                SqlParameter gsad = new SqlParameter();
                gsad.ParameterName = "@POSID";
                gsad.SqlDbType = SqlDbType.Int;
                gsad.Value = Convert.ToString(n.POSID);
                cmd.Parameters.Add(gsad);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@RegNo";
                gid.SqlDbType = SqlDbType.VarChar;
                gid.Value = n.RegNo;
                cmd.Parameters.Add(gid);


                SqlParameter gidb = new SqlParameter();
                gidb.ParameterName = "@route";
                gidb.SqlDbType = SqlDbType.VarChar;
                gidb.Value = n.route;
                cmd.Parameters.Add(gidb);

                SqlParameter gidba = new SqlParameter();
                gidba.ParameterName = "@Status";
                gidba.SqlDbType = SqlDbType.VarChar;
                gidba.Value = n.Status;
                cmd.Parameters.Add(gidba);

                SqlParameter gsae = new SqlParameter();
                gsae.ParameterName = "@statusid";
                gsae.SqlDbType = SqlDbType.Int;
                gsae.Value = Convert.ToString(n.statusid);
                cmd.Parameters.Add(gsae);



                SqlParameter ga = new SqlParameter();
                ga.ParameterName = "@Active";
                ga.SqlDbType = SqlDbType.Int;
                ga.Value = Convert.ToString(n.Active);
                cmd.Parameters.Add(ga);

                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = n.insupdflag;
                cmd.Parameters.Add(insupdflag);

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
        public void Options()
        {
        }
    }
}
