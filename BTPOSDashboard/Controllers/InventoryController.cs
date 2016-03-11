using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using POSDBAccess.Models;

namespace BTPOSDashboardAPI.Controllers
{
    public class InventoryController : ApiController
    {
        public DataTable GetInventory()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "data source=NAVEEN\\SQLEXPRESS;initial catalog=POSNEW;user id=sa;password=lucky;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getInventory";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]

        public DataTable SaveInventory(Inventory1 n)
        {
            DataTable Tbl = new DataTable();

            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = "data source=NAVEEN\\SQLEXPRESS;initial catalog=POSNEW;user id=sa;password=lucky;";

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelInventory";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@Active";
                gs.SqlDbType = SqlDbType.Int;
                gs.Value = Convert.ToBoolean(n.Active) ? "1" : "0";
                cmd.Parameters.Add(gs);

                SqlParameter gb = new SqlParameter();
                gb.ParameterName = "@availableQty";
                gb.SqlDbType = SqlDbType.Int;
                gb.Value = Convert.ToString(n.availableQty);
                cmd.Parameters.Add(gb);


                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@category";
                gid.SqlDbType = SqlDbType.VarChar;
                gid.Value = n.category;
                cmd.Parameters.Add(gid);

                SqlParameter gida = new SqlParameter();
                gida.ParameterName = "@code";
                gida.SqlDbType = SqlDbType.VarChar;
                gida.Value = n.code;
                cmd.Parameters.Add(gida);

                SqlParameter gidb = new SqlParameter();
                gidb.ParameterName = "@desc";
                gidb.SqlDbType = SqlDbType.VarChar;
                gidb.Value = n.desc;
                cmd.Parameters.Add(gidb);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@InventoryId";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = n.InventoryId;
                cmd.Parameters.Add(gsn);

                SqlParameter guid = new SqlParameter();
                guid.ParameterName = "@name";
                guid.SqlDbType = SqlDbType.VarChar;
                guid.Value = n.name;
                cmd.Parameters.Add(guid);

                SqlParameter gsna = new SqlParameter();
                gsna.ParameterName = "@PerUnitPrice";
                gsna.SqlDbType = SqlDbType.Int;
                gsna.Value = Convert.ToString(n.PerUnitPrice);
                cmd.Parameters.Add(gsna);

                SqlParameter gsns = new SqlParameter();
                gsns.ParameterName = "@reorderpoint";
                gsns.SqlDbType = SqlDbType.Int;
                gsns.Value = Convert.ToString(n.reorderpoint);
                cmd.Parameters.Add(gsns);

                SqlParameter gd = new SqlParameter();
                gd.ParameterName = "@subcat";
                gd.SqlDbType = SqlDbType.VarChar;
                gd.Value = n.subcat;
                cmd.Parameters.Add(gd);

                //SqlParameter ga = new SqlParameter();
                //ga.ParameterName = "@Active";
                //ga.SqlDbType = SqlDbType.Int;
                //ga.Value = Convert.ToString(n.Active);
                //cmd.Parameters.Add(ga);

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
