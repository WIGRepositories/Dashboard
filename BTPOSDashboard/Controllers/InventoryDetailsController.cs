﻿using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTPOSDashboardAPI.Controllers
{
    public class InventoryDetailsController : ApiController
    {

        [HttpGet]
        public DataTable ctrl()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInventoryDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable test(detail b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelInventoryDetails";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);
            SqlParameter iid = new SqlParameter();
            iid.ParameterName = "@InventoryId";
            iid.SqlDbType = SqlDbType.Int;
            iid.Value = Convert.ToString(b.InventoryId);
            cmd.Parameters.Add(iid);
            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@PerUnitPrice";
            pid.SqlDbType = SqlDbType.Int;
            pid.Value = Convert.ToString(b.PerUnitPrice);
            cmd.Parameters.Add(pid);
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@ReorderPoint";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.ReorderPoint;
            cmd.Parameters.Add(ss);
            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@AvailableQty";
            dd.SqlDbType = SqlDbType.Int;
            dd.Value = Convert.ToString(b.AvailableQty);
            cmd.Parameters.Add(dd);
           

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