using keseneni1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace keseneni1.Controllers
{
    public class mulitiplicationsaveController : ApiController
    {
        [HttpPost]
        public DataTable Getmulitiplication(mulitiplication b)
        {
            DataTable Tb = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=commericialsite;Integrated Security=SSPI;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELmulitiplicationsave";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@rows";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = b.rows;
            Gid.Value = Convert.ToString(b.rows);
            cmd.Parameters.Add(Gid);


            SqlParameter Fid = new SqlParameter();
            Fid.ParameterName = "@columns";
            Fid.SqlDbType = SqlDbType.Int;
            Fid.Value = b.Columns;
            Fid.Value = Convert.ToString(b.Columns);
            cmd.Parameters.Add(Fid);


            SqlParameter Eid = new SqlParameter();
            Eid.ParameterName = "@layoutId";
            Eid.SqlDbType = SqlDbType.Int;
            Eid.Value = b.layoutId;
            Eid.Value = Convert.ToString(b.layoutId);
            cmd.Parameters.Add(Eid);

            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tb;
        }
        public void Options() { }


    }
}



