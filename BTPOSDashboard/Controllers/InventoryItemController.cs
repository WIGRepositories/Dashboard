using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace BTPOSDashboard.Controllers
{
    public class InventoryItemController : ApiController
    {

        public DataTable GetInventoryItem(int subCatId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventoryItem ....");
 

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInventoryItem";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@subCatId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = subCatId;
            cmd.Parameters.Add(Gid);
            
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventoryItem completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage SaveinventoryItem(InventoryItem b)
       {

           LogTraceWriter traceWriter = new LogTraceWriter();
           traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveinventoryItem ...");
            SqlConnection conn = new SqlConnection();
            try
            {

            //connect to database
           
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsupdDelInventoryItem";
            cmd.Connection = conn;
            conn.Open();

            SqlParameter Cid = new SqlParameter();
            Cid.ParameterName = "@Id";
            Cid.SqlDbType = SqlDbType.Int;
            Cid.Value = b.Id;
            cmd.Parameters.Add(Cid);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@ItemName";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.ItemName;
            cmd.Parameters.Add(Gid);

            //SqlParameter li = new SqlParameter();
            //li.ParameterName = "@ItemImage";
            //li.SqlDbType = SqlDbType.VarChar;
            //li.Value = b.ItemImage;
            //cmd.Parameters.Add(li);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@Code";
            lid.SqlDbType = SqlDbType.VarChar;
            lid.Value = b.Code;
            cmd.Parameters.Add(lid);

            SqlParameter pDesc = new SqlParameter();
            pDesc.ParameterName = "@Description";
            pDesc.SqlDbType = SqlDbType.VarChar;
            pDesc.Value = b.Description;
            cmd.Parameters.Add(pDesc);

            SqlParameter lAct = new SqlParameter();
            lAct.ParameterName = "@CategoryId";
            lAct.SqlDbType = SqlDbType.Int;
            lAct.Value = b.Category;
            //llid.Value = b.Active;
            cmd.Parameters.Add(lAct);
            SqlParameter psub = new SqlParameter();
            psub.ParameterName = "@SubCategoryId";
            psub.SqlDbType = SqlDbType.Int;
            psub.Value = b.SubCategory;
            cmd.Parameters.Add(psub);

            SqlParameter prop = new SqlParameter();
            prop.ParameterName = "@ReOrderPoint";
            prop.SqlDbType = SqlDbType.Int;
            prop.Value = b.ReOrderPoint;
            cmd.Parameters.Add(prop);

            cmd.ExecuteScalar();
            conn.Close();

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveinventoryItem completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveinventoryItem:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
       }
        public void Options() { }
    }
}
