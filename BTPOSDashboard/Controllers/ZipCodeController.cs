﻿
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Controllers;
using BTPOSDashboardAPI.Models;

namespace blocklist1.Controllers
{
    public class ZipCodeController : ApiController
    {

          [HttpGet]

        public DataTable POSDashboard1()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetZipCode";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
          [HttpPost]
          public DataTable pos(ZipCode b)
          {
              DataTable Tbl = new DataTable();

              //connect to database
              SqlConnection conn = new SqlConnection();
              //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
              conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "InsUpdDelELZipCode";
              cmd.Connection = conn;
              conn.Open();

      
              SqlParameter Aid = new SqlParameter();
              Aid.ParameterName = "@Id";
              Aid.SqlDbType = SqlDbType.VarChar;
              Aid.Value = b.Id;
              Aid.Value = Convert.ToString(b.Id);
              cmd.Parameters.Add(Aid);

              SqlParameter Gid = new SqlParameter();
              Gid.ParameterName = "@Code";
              Gid.SqlDbType = SqlDbType.VarChar;
              Gid.Value = b.Code;
              cmd.Parameters.Add(Gid);

              SqlParameter lid = new SqlParameter();
              lid.ParameterName = "@Active";
              lid.SqlDbType = SqlDbType.VarChar;
              lid.Value = b.Active;
              cmd.Parameters.Add(lid);

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
    
   