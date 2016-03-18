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
    public class RolesController : ApiController
    {
        [HttpGet]
        public DataTable getroles()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetRoles";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable saveroles(roles b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelRoles";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value =Convert.ToString (b.Id);
            cmd.Parameters.Add(cc);
            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@Name";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.Name;
            cmd.Parameters.Add(cname);
            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@Description";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value = b.Description;
            cmd.Parameters.Add(dd);
       
            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@Active";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = Convert.ToBoolean(b.Active)?"1":"0";
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
