﻿
using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace blocklist1.Controllers
{
    public class PayablesController : ApiController
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
            cmd.CommandText = "GetPayables";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }


        [HttpPost]
          public DataTable pos(Payables b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELPayables";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = b.Id;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@Amount";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.Amount;
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@MasterId";
            lid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.MasterId);
            lid.Value = b.MasterId;
            cmd.Parameters.Add(lid);
           

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@Paidby ";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value =b.Paidby;
            cmd.Parameters.Add(pid);
          
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

    
