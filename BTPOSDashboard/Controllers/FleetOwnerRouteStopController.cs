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
    public class FleetOwnerRouteStopController : ApiController
    {
        [HttpGet]
        public DataTable GetFleetOwnerRouteStop()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetOwnerRouteStop";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable saveFleetOwnerRoute(FleetOwnerRouteStop b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELRouteStops";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value = b.Id;
            SqlParameter ccd = new SqlParameter();
            ccd.ParameterName = "@FleetOwnerId";
            ccd.SqlDbType = SqlDbType.Int;
            ccd.Value = Convert.ToString(b.FleetOwnerId);
            cmd.Parameters.Add(ccd);

            SqlParameter ccdsa = new SqlParameter();
            ccdsa.ParameterName = "@RouteId";
            ccdsa.SqlDbType = SqlDbType.Int;
            ccdsa.Value = Convert.ToString(b.RouteId);
            cmd.Parameters.Add(ccdsa);
             SqlParameter ccdsas = new SqlParameter();
            ccdsas.ParameterName = "@StopNo";
            ccdsas.SqlDbType = SqlDbType.Int;
            ccdsas.Value = Convert.ToString(b.StopNo);
            cmd.Parameters.Add(ccdsas);
              SqlParameter ccdsass = new SqlParameter();
            ccdsass.ParameterName = "@StopId";
            ccdsass.SqlDbType = SqlDbType.Int;
            ccdsass.Value = Convert.ToString(b.StopId);
            cmd.Parameters.Add(ccdsass);

            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@PreviousStop";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value = b.PreviousStop;
            cmd.Parameters.Add(dd);
            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@NextStop";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.NextStop;
            cmd.Parameters.Add(cname);


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
