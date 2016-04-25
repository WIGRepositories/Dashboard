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
    public class InventoryItemController : ApiController
    {
         [HttpGet]
        public DataTable GetInventoryItem()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "dbo.GetInventoryItem";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
         public DataTable SaveInventoryItem(InventoryItem b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsupdDelInventoryItem";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(cc);
            SqlParameter ccd = new SqlParameter();
            ccd.ParameterName = "@ItemName";
            ccd.SqlDbType = SqlDbType.VarChar;
            ccd.Value = b.ItemName;
            cmd.Parameters.Add(ccd);

            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@Code";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = b.Code;
            cmd.Parameters.Add(cname);
            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@Description";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value = b.Description;
            cmd.Parameters.Add(dd);
            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@Category";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.Category;
            cmd.Parameters.Add(aa);
            SqlParameter aac = new SqlParameter();
            aac.ParameterName = "@SubCategory";
            aac.SqlDbType = SqlDbType.VarChar;
            aac.Value = b.SubCategory;
            cmd.Parameters.Add(aac);
            SqlParameter aacd = new SqlParameter();
            aacd.ParameterName = "@ReOrderPoint";
            aacd.SqlDbType = SqlDbType.Int;
            aacd.Value = Convert.ToString(b.ReOrderPoint);
            cmd.Parameters.Add(aacd);


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

