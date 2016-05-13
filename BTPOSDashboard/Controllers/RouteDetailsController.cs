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
    public class RouteDetailsController : ApiController
    {
         [HttpGet]
        public DataTable getroutedetails(int routeid)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getRouteDetails";
            cmd.Connection = conn;

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@routeid";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = routeid;
            cmd.Parameters.Add(cid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }



        [HttpPost]
        public DataTable saveroutedetails(RouteDetails b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelRouteDetails";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(cc);

            SqlParameter ccw = new SqlParameter();
            ccw.ParameterName = "@RouteId";
            ccw.SqlDbType = SqlDbType.VarChar;
            ccw.Value =Convert.ToInt16(b.RouteId);
            cmd.Parameters.Add(ccw);

            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@stopname";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.stopname;
            cmd.Parameters.Add(cname);

            SqlParameter cca = new SqlParameter();
            cca.ParameterName = "@Description";
            cca.SqlDbType = SqlDbType.VarChar;
            cca.Value = b.Description;
            cmd.Parameters.Add(cca);

            SqlParameter ccad = new SqlParameter();
            ccad.ParameterName = "@StopCode";
            ccad.SqlDbType = SqlDbType.VarChar;
            ccad.Value =b.StopCode;
            cmd.Parameters.Add(ccad);

            SqlParameter ccwa = new SqlParameter();
            ccwa.ParameterName = "@DistanceFromSource";
            ccwa.SqlDbType = SqlDbType.Int;
            ccwa.Value = b.DistanceFromSource;
            cmd.Parameters.Add(ccwa);

            SqlParameter ccwad = new SqlParameter();
            ccwad.ParameterName = "@DistanceFromDestination";
            ccwad.SqlDbType = SqlDbType.Int;
            ccwad.Value=b.DistanceFromDestination;
            cmd.Parameters.Add(ccwad);

                SqlParameter ccwade = new SqlParameter();
                ccwade.ParameterName = "@DistanceFromPreviousStop";
            ccwade.SqlDbType = SqlDbType.Int;
            ccwade.Value =b.DistanceFromPreviousStop;
            cmd.Parameters.Add(ccwade);


            SqlParameter ccwadep = new SqlParameter();
            ccwadep.ParameterName = "@PreviousStopId";
            ccwadep.SqlDbType = SqlDbType.Int;
            ccwadep.Value = b.DistanceFromPreviousStop;
            cmd.Parameters.Add(ccwadep);

               SqlParameter ccwadeas = new SqlParameter();
               ccwadeas.ParameterName = "@NextStopId";
            ccwadeas.SqlDbType = SqlDbType.Int;
            ccwadeas.Value = b.DistanceFromNextStop;
            cmd.Parameters.Add(ccwadeas);
             cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        
        }
        public void Options() { }

    }
}

