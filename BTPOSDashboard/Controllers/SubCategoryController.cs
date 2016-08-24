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
    public class SubCategoryController : ApiController
    {
        [HttpGet]
        public DataTable getcategory()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getcategory credentials....");
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
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getcategory Credentials completed.");
            // int found = 0;
            return Tbl;
        }

        [HttpGet]
        public DataTable getsubcategory(int catid)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getsubcategory credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetSubCategories";
            cmd.Connection = conn;

            SqlParameter catidParam = new SqlParameter();
            catidParam.ParameterName = "@catid";
            catidParam.SqlDbType = SqlDbType.VarChar;
            catidParam.Value = catid;
            cmd.Parameters.Add(catidParam);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getsubcategory Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public HttpResponseMessage savesubcategory(Types b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "savesubcategory credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();

            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelSubCategory";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter cc = new SqlParameter();
                cc.ParameterName = "@Id";
                cc.SqlDbType = SqlDbType.Int;
                cc.Value = Convert.ToString(b.Id);
                cmd.Parameters.Add(cc);
                SqlParameter ccd = new SqlParameter();
                ccd.ParameterName = "@CategoryId";
                ccd.SqlDbType = SqlDbType.Int;
                ccd.Value = Convert.ToString(b.TypeGroupId);
                cmd.Parameters.Add(ccd);

                SqlParameter cname = new SqlParameter();
                cname.ParameterName = "@Name";
                cname.SqlDbType = SqlDbType.VarChar;
                cname.Value = b.Name;
                cmd.Parameters.Add(cname);
                SqlParameter dd = new SqlParameter();
                dd.ParameterName = "@Description";
                dd.SqlDbType = SqlDbType.VarChar;
                dd.Value = b.Description;
                cmd.Parameters.Add(dd);
                SqlParameter aa = new SqlParameter();
                aa.ParameterName = "@Active";
                aa.SqlDbType = SqlDbType.VarChar;
                aa.Value = b.Active;
                cmd.Parameters.Add(aa);


                //DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                // Tbl = Tables[0];
                cmd.ExecuteScalar();
                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "savesubcategory Credentials completed.");
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
