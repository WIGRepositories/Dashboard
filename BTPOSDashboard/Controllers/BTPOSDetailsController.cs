using BTPOSDashboardAPI.Models;
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
    public class BTPOSDetailsController : ApiController
    {
        [HttpGet]
        [Route("api/GetBTPOSDetails")]
        public DataTable BTPOSDetails1()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getBTPOSDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }

        [HttpPost]

        public DataTable BTPOSDetails2(BTPOSDetails n)
        {
            DataTable Tbl = new DataTable();

            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelELBTPOSDetails";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter ba = new SqlParameter();
                ba.ParameterName = "@Id";
                ba.SqlDbType = SqlDbType.Int;
                ba.Value = Convert.ToString(n.Id);
                cmd.Parameters.Add(ba);


                SqlParameter bb = new SqlParameter();
                bb.ParameterName = "@GroupName";
                bb.SqlDbType = SqlDbType.VarChar;
                bb.Value = n.GroupName;
                cmd.Parameters.Add(bb);

                SqlParameter bc = new SqlParameter();
                bc.ParameterName = "@GroupId";
                bc.SqlDbType = SqlDbType.Int;
                bc.Value = Convert.ToString(n.GroupId);
                cmd.Parameters.Add(bc);

                SqlParameter bd = new SqlParameter();
                bd.ParameterName = "@IMEI";
                bd.SqlDbType = SqlDbType.VarChar;
                bd.Value = n.IMEI;
                cmd.Parameters.Add(bd);

            

               
                SqlParameter bf = new SqlParameter();
                bf.ParameterName = "@POSID";
                bf.SqlDbType = SqlDbType.Int;
                bf.Value = Convert.ToString(n.POSID);
                cmd.Parameters.Add(bf);

              

                SqlParameter bh = new SqlParameter();
                bh.ParameterName = "@Status";
                bh.SqlDbType = SqlDbType.VarChar;
                bh.Value = n.Status;
                cmd.Parameters.Add(bh);

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
