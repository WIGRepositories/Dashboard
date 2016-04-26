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
    public class DashboardController : ApiController
    {

        [HttpGet]
        public DataSet getdashboard(int userid, int roleid)
        {
            DataTable Ds = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetDashboardDetails";

            SqlParameter uid = new SqlParameter();
            uid.ParameterName = "@userid";
            uid.SqlDbType = SqlDbType.Int;
            uid.Value = userid;
            cmd.Parameters.Add(uid);


            SqlParameter rid = new SqlParameter();
            rid.ParameterName = "@userid";
            rid.SqlDbType = SqlDbType.Int;
            rid.Value = roleid;
            cmd.Parameters.Add(rid);


            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            // Tbl = ds.Tables[0];

            // int found = 0;
            return ds;
        }
    }
}
