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
        [Route("api/FleetOwnerVehicleSchedule/getfleetroutelist")]
       public DataTable getroutedetails(int sId, int cmpid, int routeid)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getRoutes";
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

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@routeid";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = routeid;
            cmd.Parameters.Add(cid);

            db.Fill(ds);
           Tbl = ds.Tables[0];

           // int found = 0;
            return Tbl;
       }
           
    }
}
