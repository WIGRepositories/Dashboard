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
    public class AlertsConfigurationController : ApiController
    {
        [HttpGet]
        public DataTable GetAlertsConfiguration()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getAlertsConfiguration";
            cmd.Connection = conn;

            //SqlParameter Rid = new SqlParameter();
            //Rid.ParameterName = "@TypeGroupId";
            //Rid.SqlDbType = SqlDbType.Int;
            //Rid.Value = TypeGroupId;
            //cmd.Parameters.Add(Rid);



            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
    }


}
