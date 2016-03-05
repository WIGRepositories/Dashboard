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
    public class UserRolesController : ApiController
    {
        [HttpGet]
        public DataTable users()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUserRoles";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable roles(userroles b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelUserRoles";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
            SqlParameter iid = new SqlParameter();
            iid.ParameterName = "@UserId";
            iid.SqlDbType = SqlDbType.Int;
            iid.Value = Convert.ToString(b.UserId);
            cmd.Parameters.Add(iid);
            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@GroupId";
            ii.SqlDbType = SqlDbType.Int;
            ii.Value = Convert.ToString(b.GroupId);
            cmd.Parameters.Add(ii);
            SqlParameter rr = new SqlParameter();
            rr.ParameterName = "@RoleId";
            rr.SqlDbType = SqlDbType.Int;
            rr.Value = Convert.ToString(b.RoleId);
            cmd.Parameters.Add(rr);
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@Passkey";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.Passkey;
            cmd.Parameters.Add(ss);
            

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
