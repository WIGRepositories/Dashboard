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
        public HttpResponseMessage SaveCartItems(ShoppingCart f)
        {
            SqlConnection conn = new SqlConnection();
            try
            {


                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelShoppingCart";
                cmd.Connection = conn;

                conn.Open();

                

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

                SqlParameter gsac = new SqlParameter("@UnitPrice", SqlDbType.Money);
                gsac.Value = f.UnitPrice;
                cmd.Parameters.Add(gsac);

                

                SqlParameter flag = new SqlParameter("@insupddelflag", SqlDbType.Char);
                flag.Value = f.insupddelflag;
                cmd.Parameters.Add(flag);


                cmd.ExecuteScalar();
                conn.Close();

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
