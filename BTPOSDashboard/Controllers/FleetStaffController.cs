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
    public class FleetStaffController : ApiController
    {

        [HttpGet]
        public DataTable getFleetStaff()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetStaff";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable saveFleetStaff(FleetStaff b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelObjects";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value = b.Id;
            cmd.Parameters.Add(cc);
            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@StaffRole";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.StaffRole;
            cmd.Parameters.Add(cname);
            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@UserId";
            dd.SqlDbType = SqlDbType.Int;
            dd.Value = Convert.ToString(b.UserId);
            cmd.Parameters.Add(dd);
            SqlParameter dda = new SqlParameter();
            dda.ParameterName = "@FromDate";
            dda.SqlDbType = SqlDbType.VarChar;
            dda.Value = b.FromDate;
            cmd.Parameters.Add(dda);


            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@ToDate";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.ToDate;
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
