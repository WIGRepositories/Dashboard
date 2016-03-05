using POSDBAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POSDBAccess.Controllers
{
    public class CompanyGroupsController : ApiController
    {
        [HttpGet]
        [Route("api/GetCompanyGroups")]
        public DataTable CompanyGroups1()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
          conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getCompanyGroups";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }

        [HttpPost]

        public DataTable CompanyGroups2(CompanyGroups n)
        {
            DataTable Tbl = new DataTable();

            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI;";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelCompanyGroups";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@active";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = Convert.ToBoolean(n.active) ? "1" : "0";
                cmd.Parameters.Add(gsa);

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@admin";
                gs.SqlDbType = SqlDbType.VarChar;
                gs.Value = n.admin;
                cmd.Parameters.Add(gs);

                SqlParameter gsaa = new SqlParameter();
                gsaa.ParameterName = "@adminId";
                gsaa.SqlDbType = SqlDbType.Int;
                gsaa.Value = Convert.ToString(n.adminId);
                cmd.Parameters.Add(gsaa);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@code";
                gsn.SqlDbType = SqlDbType.VarChar;
                gsn.Value = n.code;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@descr";
                gsab.SqlDbType = SqlDbType.VarChar;
                gsab.Value = n.descr;
                cmd.Parameters.Add(gsab);

                SqlParameter gsac = new SqlParameter();
                gsac.ParameterName = "@Id";
                gsac.SqlDbType = SqlDbType.Int;
                gsac.Value = Convert.ToString(n.Id);
                cmd.Parameters.Add(gsac);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@Name";
                gid.SqlDbType = SqlDbType.VarChar;
                gid.Value = n.Name;
                cmd.Parameters.Add(gid);

                //SqlParameter ga = new SqlParameter();
                //ga.ParameterName = "@Active";
                //ga.SqlDbType = SqlDbType.Int;
                //ga.Value = Convert.ToString(n.Active);
                //cmd.Parameters.Add(ga);

                cmd.ExecuteScalar();
                conn.Close();
                DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                //Tbl = ds.Tables[0];
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            // int found = 0;
            return Tbl;

        }
        public void Options()
        {
        }
       
    }
}
