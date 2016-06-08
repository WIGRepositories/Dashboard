using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTPOSDashboard.Controllers
{
    public class BTPOSConfigController : ApiController
    {

        [HttpGet]
        public DataTable GetFleeBTPosDetails(int cmpId, int fleetOwnerId, int BTPOSID)
        {
             DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSRecords";
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

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@BTPOSID";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = BTPOSID;
            cmd.Parameters.Add(cid);

            
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            // Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
    }
}
