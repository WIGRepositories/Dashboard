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
    public class EditHistoryDetailsController : ApiController
    {
           [HttpGet]
        public DataTable GetEditHistoryDetails(int edithistoryid)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEditHistoryDetails credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getEditHistoryDetails";
            cmd.Connection = conn;


            SqlParameter gsa = new SqlParameter();
            gsa.ParameterName = "@edithistoryid";
            gsa.SqlDbType = SqlDbType.Int;
            gsa.Value = edithistoryid;
            cmd.Parameters.Add(gsa);


            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetEditHistoryDetails Credentials completed.");
            // int found = 0;
            return Tbl;

        }
    }
}
   
   
