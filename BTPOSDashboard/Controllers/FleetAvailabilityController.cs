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
    public class FleetAvailabilityController : ApiController
    {
        [HttpGet]
        [Route("api/FleetAvailability/GetFleetAvailability")]
        public DataTable List(int foId, int cmpid)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetAvailabilityList credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFleetAvailability";
            cmd.Connection = conn;

            SqlParameter fo = new SqlParameter();
            fo.ParameterName = "@fleetownerId";
            fo.SqlDbType = SqlDbType.Int;
            fo.Value = foId;
            cmd.Parameters.Add(fo);

            SqlParameter fsc = new SqlParameter();
            fsc.ParameterName = "@cmpId";
            fsc.SqlDbType = SqlDbType.Int;
            fsc.Value = cmpid;
            cmd.Parameters.Add(fsc);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);

            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetFleetAvailabilityList Credentials completed.");
            return Tbl;
        }


        [HttpPost]
        public HttpResponseMessage SetFleetAvailability(FleetAvailability fa)
        {
            SqlConnection conn = new SqlConnection();
            try
            {
                LogTraceWriter traceWriter = new LogTraceWriter();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSetFleetAvailability credentials....");
            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelFleetAvailability";
            cmd.Connection = conn;
            conn.Open();

            SqlParameter cc = new SqlParameter();
            cc.ParameterName = "@Id";
            cc.SqlDbType = SqlDbType.Int;
            cc.Value = fa.Id;
            cmd.Parameters.Add(cc);


            SqlParameter cname = new SqlParameter();
            cname.ParameterName = "@VehicleId";
            cname.SqlDbType = SqlDbType.VarChar;
            cname.Value = fa.VehicleId;
            cmd.Parameters.Add(cname);
            
            SqlParameter gsac = new SqlParameter("@FromDate", SqlDbType.DateTime);
            gsac.Value = fa.FromDate;
            cmd.Parameters.Add(gsac);
            
            SqlParameter gsacd = new SqlParameter("@ToDate", SqlDbType.DateTime);
            gsacd.Value = fa.ToDate;
            cmd.Parameters.Add(gsacd);

            SqlParameter flag = new SqlParameter("@insupddelflag", SqlDbType.Char);
            flag.Value = fa.insupddelflag;
            cmd.Parameters.Add(flag);

            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveSetFleetAvailability Credentials completed.");
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

