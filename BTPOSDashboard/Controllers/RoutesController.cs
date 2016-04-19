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
    public class RoutesController : ApiController
    {
        [HttpGet]
        public DataTable GetRoutes()
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
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable saveRoutes(Routes r)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelRoutes";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@Id";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = Convert.ToString(r.Id);
            cmd.Parameters.Add(cid);

            SqlParameter broute = new SqlParameter();
            broute.ParameterName = "@Route";
            broute.SqlDbType = SqlDbType.VarChar;
            broute.Value = r.Route;
            cmd.Parameters.Add(broute);

            SqlParameter acode = new SqlParameter();
            acode.ParameterName = "@Code";
            acode.SqlDbType = SqlDbType.VarChar;
            acode.Value = r.Code;
            cmd.Parameters.Add(acode);

            //SqlParameter ddes = new SqlParameter();
            //ddes.ParameterName = "@Description";
            //ddes.SqlDbType = SqlDbType.VarChar;
            //ddes.Value = r.Description;
            //cmd.Parameters.Add(ddes);

           
            //SqlParameter gact = new SqlParameter();
            //gact.ParameterName = "@Active";
            //gact.SqlDbType = SqlDbType.Int;
            //gact.Value = r.Active;
            //cmd.Parameters.Add(gact);

            //SqlParameter ii = new SqlParameter();
            //ii.ParameterName = "@BTPOSGroupId";
            //ii.SqlDbType = SqlDbType.VarChar;
            //ii.Value = r.BTPOSGroupId;
            //cmd.Parameters.Add(ii);

            SqlParameter ff = new SqlParameter();
            ff.ParameterName = "@Source";
            ff.SqlDbType = SqlDbType.VarChar;
            ff.Value = r.Source;
            cmd.Parameters.Add(ff);

            SqlParameter hh = new SqlParameter();
            hh.ParameterName = "@Destination";
            hh.SqlDbType = SqlDbType.VarChar;
            hh.Value = r.Destination;
            cmd.Parameters.Add(hh);


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
