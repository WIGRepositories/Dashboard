using DAshboard.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DAshboard.Controllers
{
    public class BTPOSGroupsController : ApiController
    {
        [HttpGet]
        public DataTable groups()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetAlertNotification";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable btpos(btposgroups b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelBTPOSGroups";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@GroupName";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.GroupName;
            cmd.Parameters.Add(ss);

            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@Desc";
            ii.SqlDbType = SqlDbType.VarChar;
            ii.Value = b.Desc;
            cmd.Parameters.Add(ii);
            SqlParameter ll = new SqlParameter();
            ll.ParameterName = "@Active";
            ll.SqlDbType = SqlDbType.VarChar;
            ll.Value = b.Active;
            cmd.Parameters.Add(ll);
            SqlParameter nn = new SqlParameter();
            nn.ParameterName = "@Code";
            nn.SqlDbType = SqlDbType.VarChar;
            nn.Value = b.Code;
            cmd.Parameters.Add(nn);
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
        public void Options() { }
    }
}
