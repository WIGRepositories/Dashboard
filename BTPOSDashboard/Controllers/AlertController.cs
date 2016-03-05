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
    public class AlertController : ApiController
    {
        [HttpGet]
        public DataTable pos()
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
        public DataTable check(Model n)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI;";
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelAlertNot";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(n.Id);
            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@Date";
            dd.SqlDbType = SqlDbType.DateTime;
            dd.Value = n.Date;
            cmd.Parameters.Add(dd);
            SqlParameter mm = new SqlParameter();
            mm.ParameterName = "@Message";
            mm.SqlDbType = SqlDbType.VarChar;
            mm.Value = n.Message;
            cmd.Parameters.Add(mm);
            SqlParameter md = new SqlParameter();
            md.ParameterName = "@MessageTypeId";
            md.SqlDbType = SqlDbType.VarChar;
            md.Value = n.MessageTypeId;
            cmd.Parameters.Add(md);
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@Status";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = n.Status;
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
              public void Options(){}
           
    }
}


