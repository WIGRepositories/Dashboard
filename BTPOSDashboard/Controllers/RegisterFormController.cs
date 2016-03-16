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

namespace registerform.Controllers
{
    public class RegisterFormController : ApiController
    {

        [HttpGet]

        public DataTable logindb()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "data source=NAVEEN\\SQLEXPRESS;initial catalog=POSNEW;user id=sa;password=lucky;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Getregister";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
    


        [HttpPost]
        public DataTable pos(Register b)
        
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "data source=NAVEEN\\SQLEXPRESS;initial catalog=POSNEW;user id=sa;password=lucky;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELregisterform";
            cmd.Connection = conn;
            conn.Open();
            //string insertquery = "insert into login(UserName,Password,FirstName,LastName,MobileNo) values (@UserName,@Password,@FirstName,@lastName,@MobileNo)";




            //SqlCommand con=new SqlCommand(insertquery,conn);
         
          
   
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@UserName";
            Aid.SqlDbType = SqlDbType.VarChar;
            Aid.Value = b.UserName ;
            cmd.Parameters.Add(Aid);

           

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@Password";
            lid.SqlDbType = SqlDbType.VarChar;
            lid.Value = b.Password;
            cmd.Parameters.Add(lid);
          
            SqlParameter bb = new SqlParameter();
            bb.ParameterName = "@ConfirmPassword";
            bb.SqlDbType = SqlDbType.VarChar;
            bb.Value = b.ConfirmPassword;
            cmd.Parameters.Add(bb);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@Emailaddress";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.Emailaddress;
            cmd.Parameters.Add(Gid);

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@FirstName ";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value =b.FirstName;
            cmd.Parameters.Add(pid);
          
            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@LastName";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.LastName;
            cmd.Parameters.Add(aa);


          

            //SqlParameter rr = new SqlParameter();
            //rr.ParameterName = "@result";
            //rr.SqlDbType = SqlDbType.Int;
            //rr.Value = b.result;
            //cmd.Parameters.Add(rr);
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


