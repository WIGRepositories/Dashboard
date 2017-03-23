using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Models;
using BTPOSDashboard;
using System.Web.Http.Tracing;

namespace BTPOSDashboardAPI.Controllers
{
    public class InventoryController : ApiController
    {

        [HttpGet]
        public DataTable GetInventory()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventory credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetCategories";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventory Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]

        public HttpResponseMessage SaveInventory(Inventory1 n)
       {


           LogTraceWriter traceWriter = new LogTraceWriter();
           traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveInventory credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {

            //connect to database
            
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelInventory";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@InventoryId";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = n.InventoryId;
                cmd.Parameters.Add(gsn);

                SqlParameter guid1 = new SqlParameter();
                guid1.ParameterName = "@Name";
                guid1.SqlDbType = SqlDbType.VarChar;
                guid1.Value = n.Name;
                cmd.Parameters.Add(guid1);

                SqlParameter guid11 = new SqlParameter();
                guid11.ParameterName = "@Image";
                guid11.SqlDbType = SqlDbType.VarChar;
                guid11.Value = n.Name;
                cmd.Parameters.Add(guid11);

                SqlParameter gida = new SqlParameter();
                gida.ParameterName = "@Code";
                gida.SqlDbType = SqlDbType.VarChar;
                gida.Value = n.Code;
                cmd.Parameters.Add(gida);

                SqlParameter gidb = new SqlParameter();
                gidb.ParameterName = "@Description";
                gidb.SqlDbType = SqlDbType.VarChar;
                gidb.Value = n.Description;
                cmd.Parameters.Add(gidb);

                SqlParameter gb = new SqlParameter();
                gb.ParameterName = "@AvailableQty";
                gb.SqlDbType = SqlDbType.Int;
                gb.Value = Convert.ToString(n.AvailableQty);
                cmd.Parameters.Add(gb);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@CategoryId";
                gid.SqlDbType = SqlDbType.Int;
                gid.Value = n.Category;
                cmd.Parameters.Add(gid);

                SqlParameter gd = new SqlParameter();
                gd.ParameterName = "@SubCategoryId";
                gd.SqlDbType = SqlDbType.Int;
                gd.Value = n.SubCategory;
                cmd.Parameters.Add(gd);

                SqlParameter gsna = new SqlParameter();
                gsna.ParameterName = "@PerUnitPrice";
                gsna.SqlDbType = SqlDbType.Int;
                gsna.Value = Convert.ToString(n.PerUnitPrice);
                cmd.Parameters.Add(gsna);

                SqlParameter gsns = new SqlParameter();
                gsns.ParameterName = "@ReorderPont";
                gsns.SqlDbType = SqlDbType.Int;
                gsns.Value = Convert.ToString(n.ReorderPont);
                cmd.Parameters.Add(gsns);

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@Active";
                gs.SqlDbType = SqlDbType.Int;
                gs.Value = n.Active;
                cmd.Parameters.Add(gs);
                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = n.insupdflag;
                cmd.Parameters.Add(insupdflag);

                //SqlParameter ga = new SqlParameter();
                //ga.ParameterName = "@Active";
                //ga.SqlDbType = SqlDbType.Int;
                //ga.Value = Convert.ToString(n.Active);
                //cmd.Parameters.Add(ga);

                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveInventory Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveInventory:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        
        }
        public void Options()
        {
        }
       
    }
}
