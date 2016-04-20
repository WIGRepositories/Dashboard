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
    public class InventoryPurchaseController : ApiController
    {
        public DataTable GetInventoryPurchases()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInventoryPurchases";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]

        public DataTable SaveInventoryPurchases(IPurchases P)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsupdInventoryPurchases";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@Id";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = P.Id;
                cmd.Parameters.Add(gsn);

                SqlParameter guid = new SqlParameter();
                guid.ParameterName = "@ItemName";
                guid.SqlDbType = SqlDbType.VarChar;
                guid.Value = P.ItemName;
                cmd.Parameters.Add(guid);

                SqlParameter gida = new SqlParameter();
                gida.ParameterName = "@Quantity";
                gida.SqlDbType = SqlDbType.Int;
                gida.Value = P.Quantity;
                cmd.Parameters.Add(gida);

                SqlParameter gidb = new SqlParameter();
                gidb.ParameterName = "@PerUnitPrice";
                gidb.SqlDbType = SqlDbType.Int;
                gidb.Value = P.PerUnitPrice;
                cmd.Parameters.Add(gidb);

                SqlParameter gb = new SqlParameter();
                gb.ParameterName = "@PurchaseDate";
                gb.SqlDbType = SqlDbType.VarChar;
                gb.Value = P.PurchaseDate;
                cmd.Parameters.Add(gb);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@PurchaseOrderNumber";
                gid.SqlDbType = SqlDbType.Int;
                gid.Value = P.PurchaseOrderNumber;
                cmd.Parameters.Add(gid);



                //SqlParameter ga = new SqlParameter();
                //ga.ParameterName = "@Active";
                //ga.SqlDbType = SqlDbType.Int;
                //ga.Value = Convert.ToString(n.Active);
                //cmd.Parameters.Add(ga);

                cmd.ExecuteScalar();
                conn.Close();

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
