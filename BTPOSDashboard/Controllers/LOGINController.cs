
using BTPOSDashboardAPI.Models;
using POSDBAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Login.Controllers
{
    public class LOGINController : ApiController
    {
        [HttpGet]

        public DataTable ValidateCredentials(string username, string pwd)
        {
            DataTable Tbl = new DataTable();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_login";

            cmd.Connection = conn;
            conn.Open();
            SqlParameter lUserName = new SqlParameter();
            lUserName.ParameterName = "@UserName";
            lUserName.SqlDbType = SqlDbType.VarChar;
            lUserName.Value = username;
            cmd.Parameters.Add(lUserName);


            SqlParameter lPassword = new SqlParameter();
            lPassword.ParameterName = "@Password";
            lPassword.SqlDbType = SqlDbType.VarChar;
            lPassword.Value = pwd;
            cmd.Parameters.Add(lPassword);





            //SqlParameter fFirstName = new SqlParameter();
            //fFirstName.ParameterName = "@FirstName";
            //fFirstName.SqlDbType = SqlDbType.VarChar;
            //fFirstName.Value = fFirstName;
            //cmd.Parameters.Add(fFirstName);


            //SqlParameter kLastName = new SqlParameter();
            //kLastName.ParameterName = "@LastName";
            //kLastName.SqlDbType = SqlDbType.VarChar;
            //kLastName.Value = kLastName;
            //cmd.Parameters.Add(kLastName);



            

            //SqlParameter mMobileNo = new SqlParameter();
            //mMobileNo.ParameterName = "@MobileNo";
            //mMobileNo.SqlDbType = SqlDbType.Int;
            //mMobileNo.Value = mMobileNo;
            //cmd.Parameters.Add(mMobileNo);

            SqlParameter rresult = new SqlParameter();
            rresult.ParameterName = "@result";
            rresult.SqlDbType = SqlDbType.Int;
            rresult.Value = 0;
            rresult.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(rresult);
             

            
            cmd.ExecuteScalar();

            string val = rresult.Value.ToString();

            conn.Close();
            // int found = 0;
            Tbl.Columns.Add("result");
            DataRow dr = Tbl.NewRow();
            dr[0] = val;
            Tbl.Rows.Add(dr);

            return Tbl;

        }

 
        [HttpGet]
        public DataTable login()
        {
            DataTable Tbl = new DataTable();


           // connect to database
           SqlConnection conn = new SqlConnection();
           // connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Getsp_login";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

           //  int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable password(login l)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
           // connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "sp_login";
            
            cmd.Connection = conn;
            conn.Open();
            SqlParameter lUserName = new SqlParameter();
            lUserName.ParameterName = "@UserName";
            lUserName.SqlDbType = SqlDbType.VarChar;
            lUserName.Value = l.UserName;
             cmd.Parameters.Add(lUserName);


             SqlParameter lPassword = new SqlParameter();
             lPassword.ParameterName = "@Password";
             lPassword.SqlDbType = SqlDbType.VarChar;
             lPassword.Value =l.Password;
             cmd.Parameters.Add(lPassword);




             //SqlParameter fFirstName = new SqlParameter();
             //fFirstName.ParameterName = "@FirstName";
             //fFirstName.SqlDbType = SqlDbType.VarChar;
             //fFirstName.Value = fFirstName;
             //cmd.Parameters.Add(fFirstName);


             //SqlParameter kLastName = new SqlParameter();
             //kLastName.ParameterName = "@LastName";
             //kLastName.SqlDbType = SqlDbType.VarChar;
             //kLastName.Value = kLastName;
             //cmd.Parameters.Add(kLastName);



             //SqlParameter mMobileNo = new SqlParameter();
             //mMobileNo.ParameterName = "@MobileNo";
             //mMobileNo.SqlDbType = SqlDbType.Int;
             //mMobileNo.Value = mMobileNo;
             //cmd.Parameters.Add(mMobileNo);

            SqlParameter rresult = new SqlParameter();
            rresult.ParameterName = "@result";
            rresult.SqlDbType = SqlDbType.Int;
            rresult.Value = 0;
            rresult.Direction = ParameterDirection.Output;

            cmd.Parameters.Add(rresult);

            //lresult.Value = Convert.ToString(l.Password);
            //cmd.Parameters.Add(lresult);

            cmd.ExecuteScalar();

            string val = rresult.Value.ToString();

            conn.Close();
             //int found = 0;
            return Tbl;
        }
         public void Options() { }


    }
}
