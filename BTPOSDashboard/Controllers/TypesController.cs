﻿using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.IO;

namespace BTPOSDashboardAPI.Controllers
{
    public class TypesController : ApiController
    {
        [HttpGet]
        public DataTable TypesByGroupId(int groupid)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetTypesByGroupId";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@typegrpid";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = groupid;
            cmd.Parameters.Add(Gid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            //prepare a file
            StringBuilder str = new StringBuilder();

            str.Append(string.Format("test\n{0}", groupid.ToString()));

            


            // int found = 0;
            return Tbl;
        }



        [HttpPost]
        public DataTable SaveType(Types b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdTypes";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Cid = new SqlParameter();
            Cid.ParameterName = "@Id";
            Cid.SqlDbType = SqlDbType.Int;
            Cid.Value = Convert.ToInt32(b.Id);
            cmd.Parameters.Add(Cid);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@Name";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.Name;
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@TypeGroupId";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToInt32(b.TypeGroupId);
            cmd.Parameters.Add(lid);

            SqlParameter pDesc = new SqlParameter();
            pDesc.ParameterName = "@Description";
            pDesc.SqlDbType = SqlDbType.VarChar;
            pDesc.Value = b.Description;
            cmd.Parameters.Add(pDesc);


            SqlParameter llid = new SqlParameter();
            llid.ParameterName = "@Active";
            llid.SqlDbType = SqlDbType.Int;
            llid.Value = 1;// b.Active;
            //llid.Value = b.Active;
            cmd.Parameters.Add(llid);

            SqlParameter flag = new SqlParameter();
            flag.ParameterName = "@insupdflag";
            flag.SqlDbType = SqlDbType.VarChar;
            flag.Value = b.insupddelflag;
            //llid.Value = b.Active;
            cmd.Parameters.Add(flag);
           
            
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
        public void Options() { }

    }
}

