using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboard.Controllers
{
    public class ShoppingCartController : ApiController
    {
        [HttpGet]
        public DataTable GetItems()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getShoppingCart";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;

        }
        [HttpPost]
        public HttpResponseMessage SaveCartItems(items f)
        {
            SqlConnection conn = new SqlConnection();
            try
            {


                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelSalesordernw";
                cmd.Connection = conn;

                conn.Open();
                //SqlParameter Cid = new SqlParameter();
                //Cid.ParameterName = "@Id";
                //Cid.SqlDbType = SqlDbType.Int;
                //Cid.Value = f.Id;
                // cmd.Parameters.Add(Cid);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@ItemId";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = f.ItemId;
                cmd.Parameters.Add(gsn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@ItemName";
                gsab.SqlDbType = SqlDbType.VarChar;
                gsab.Value = f.ItemName;
                cmd.Parameters.Add(gsab);

                SqlParameter gsac = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                gsac.Value = f.UnitPrice;
                cmd.Parameters.Add(gsac);

                //SqlParameter insupdelflag = new SqlParameter("@insupddelflag", SqlDbType.VarChar);
                //insupdelflag.SqlDbType = SqlDbType.VarChar;
                //insupdelflag.Value = f.insupddelflag;
                //cmd.Parameters.Add(insupdelflag);


                cmd.ExecuteScalar();
                cmd.Parameters.Clear();


                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsUpdDelPaymentdetailsnw";
                cmd1.Connection = conn;

                conn.Open();
                //SqlParameter Cid = new SqlParameter();
                //Cid.ParameterName = "@Id";
                //Cid.SqlDbType = SqlDbType.Int;
                //Cid.Value = f.Id;
                //cmd.Parameters.Add(Cid);

                SqlParameter gsn1 = new SqlParameter();
                gsn1.ParameterName = "@ItemId";
                gsn1.SqlDbType = SqlDbType.Int;
                gsn1.Value = f.ItemId;
                cmd.Parameters.Add(gsn1);

                SqlParameter gsab1 = new SqlParameter();
                gsab1.ParameterName = "@ItemName";
                gsab1.SqlDbType = SqlDbType.VarChar;
                gsab1.Value = f.ItemName;
                cmd.Parameters.Add(gsab1);

                SqlParameter gsac1 = new SqlParameter("@UnitPrice", SqlDbType.Decimal);
                gsac1.Value = f.UnitPrice;
                cmd.Parameters.Add(gsac1);

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@Transactionid";
                gs.SqlDbType = SqlDbType.Int;
                gs.Value = f.ItemName;
                cmd.Parameters.Add(gs);

                SqlParameter g = new SqlParameter();
                g.ParameterName = "@Quantity";
                g.SqlDbType = SqlDbType.Int;
                g.Value = f.ItemName;
                cmd.Parameters.Add(g);

                cmd1.ExecuteScalar();
                cmd1.Parameters.Clear();


                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        public void Options()
        {
        }

    }
}
