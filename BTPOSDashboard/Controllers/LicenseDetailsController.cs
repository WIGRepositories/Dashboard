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
    public class LicenseDetailsController : ApiController
    {
        [HttpGet]
        public DataTable getLicenseDetails(int catId)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getLicenseDetails credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicenseDetails";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@ltypeId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = catId;
            cmd.Parameters.Add(Gid);

           
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getLicenseDetails Credentials completed.");

            // int found = 0;
            return Tbl;
        }
   
        [HttpPost]
        public HttpResponseMessage SaveLicenseDetails(LicenseDetails b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseDetails credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelLicenseDetails";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@LicenseTypeId";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToString(b.LicenseTypeId);
            cmd.Parameters.Add(lid);           
           
            SqlParameter nn = new SqlParameter();
            nn.ParameterName = "@FeatureTypeId";
            nn.SqlDbType = SqlDbType.Int;
            nn.Value = b.FeatureTypeId;
            cmd.Parameters.Add(nn);

             SqlParameter nm = new SqlParameter();
            nm.ParameterName = "@FeatureLabel";
            nm.SqlDbType = SqlDbType.VarChar;
            nm.Value = b.FeatureLabel;
            cmd.Parameters.Add(nm);

             SqlParameter mn = new SqlParameter();
            mn.ParameterName = "@FeatureValue";
            mn.SqlDbType = SqlDbType.VarChar;
            mn.Value = b.FeatureValue;
            cmd.Parameters.Add(mn);

            SqlParameter ln = new SqlParameter();
            ln.ParameterName = "@LabelClass";
            ln.SqlDbType = SqlDbType.VarChar;
            ln.Value = b.LabelClass;
            cmd.Parameters.Add(ln);

            SqlParameter gsac = new SqlParameter("@fromDate", SqlDbType.DateTime);
            gsac.Value = b.fromDate;
            cmd.Parameters.Add(gsac);


            SqlParameter gsacd = new SqlParameter("@toDate", SqlDbType.DateTime);
            gsacd.Value = b.toDate;
            cmd.Parameters.Add(gsacd);


            SqlParameter flag = new SqlParameter("@insupddelflag", SqlDbType.Char);
            flag.Value = b.insupddelflag;
            cmd.Parameters.Add(flag);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
           
            cmd.ExecuteScalar();
            conn.Close();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseDetails Credentials completed.");
            return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveLicenseDetails:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }

        [HttpGet]
        [Route("api/License/GetLicenseTypes")]
        public DataTable GetLicenseTypes(int catid)
        {
            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenseTypes credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicenseTypes";
            cmd.Connection = conn;

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@licenseCategoryId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = catid;
            cmd.Parameters.Add(Gid);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetLicenseTypes Credentials completed.");
            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        [Route("api/License/SaveLicenseType")]
        public HttpResponseMessage SaveLicenseTypes(LicenseTypes b)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseTypes credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {
                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdLicenseTypes";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter Aid = new SqlParameter();
                Aid.ParameterName = "@Id";
                Aid.SqlDbType = SqlDbType.Int;
                Aid.Value = Convert.ToString(b.Id);
                cmd.Parameters.Add(Aid);

                SqlParameter lid = new SqlParameter();
                lid.ParameterName = "@LicenseCatId";
                lid.SqlDbType = SqlDbType.Int;
                lid.Value = Convert.ToString(b.LicenseCategoryId);
                cmd.Parameters.Add(lid);

                SqlParameter ss = new SqlParameter();
                ss.ParameterName = "@LicenseType";
                ss.SqlDbType = SqlDbType.VarChar;
                ss.Value = b.LicenseType;
                cmd.Parameters.Add(ss);

                SqlParameter ii = new SqlParameter();
                ii.ParameterName = "@Description";
                ii.SqlDbType = SqlDbType.VarChar;
                ii.Value = b.Desc;

                cmd.Parameters.Add(ii);
                SqlParameter ll = new SqlParameter();
                ll.ParameterName = "@Active";
                ll.SqlDbType = SqlDbType.VarChar;
                ll.Value = b.Active;

                cmd.ExecuteScalar();

                conn.Close();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveLicenseTypes Credentials completed.");
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in SaveLicenseTypes:" + ex.Message);
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
        }
        //[HttpPost]
        //[Route("api/License/SaveLicenseType")]
        //public HttpResponseMessage SaveLicenseTypes1(LicenseTypes1 b)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {
        //        //connect to database

        //        //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "InsUpdLicenseTypes";
        //        cmd.Connection = conn;
        //        conn.Open();
        //        SqlParameter Aid = new SqlParameter();
        //        Aid.ParameterName = "@Id";
        //        Aid.SqlDbType = SqlDbType.Int;
        //        Aid.Value = Convert.ToString(b.Id);
        //        cmd.Parameters.Add(Aid);

        //        SqlParameter lid = new SqlParameter();
        //        lid.ParameterName = "@LicenseCatId";
        //        lid.SqlDbType = SqlDbType.Int;
        //        lid.Value = Convert.ToString(b.LicenseCategoryId);
        //        cmd.Parameters.Add(lid);

        //        SqlParameter ss = new SqlParameter();
        //        ss.ParameterName = "@LicenseType";
        //        ss.SqlDbType = SqlDbType.VarChar;
        //        ss.Value = b.LicenseType;
        //        cmd.Parameters.Add(ss);

        //        SqlParameter ii = new SqlParameter();
        //        ii.ParameterName = "@Description";
        //        ii.SqlDbType = SqlDbType.VarChar;
        //        ii.Value = b.Desc;

        //        cmd.Parameters.Add(ii);
        //        SqlParameter ll = new SqlParameter();
        //        ll.ParameterName = "@Active";
        //        ll.SqlDbType = SqlDbType.VarChar;
        //        ll.Value = b.Active;

        //        cmd.ExecuteScalar();

        //        conn.Close();
        //        //// conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        //SqlCommand cmd1 = new SqlCommand();
        //        //cmd1.CommandType = CommandType.StoredProcedure;
        //        //cmd1.CommandText = "InsUpdDelLicensePricing";
        //        //cmd1.Connection = conn;
        //        //// conn.Open();

              



        //        ////SqlParameter Aidd = new SqlParameter();
        //        ////Aidd.ParameterName = "@Id";
        //        ////Aidd.SqlDbType = SqlDbType.Int;
        //        ////Aidd.Value = Convert.ToString(b.Id);
        //        ////cmd1.Parameters.Add(Aidd);

        //        //SqlParameter lsid = new SqlParameter();
        //        //lsid.ParameterName = "@LicenseId";
        //        //lsid.SqlDbType = SqlDbType.Int;
        //        //lsid.Value = Convert.ToString(b.LicenseId);
        //        //cmd1.Parameters.Add(lsid);

        //        //SqlParameter Rf = new SqlParameter();
        //        //Rf.ParameterName = "@RenewalFreqTypeId";
        //        //Rf.SqlDbType = SqlDbType.Int;
        //        //Rf.Value = b.RenewalFreqTypeId;
        //        //cmd1.Parameters.Add(Rf);

        //        //SqlParameter pid = new SqlParameter();
        //        //pid.ParameterName = "@RenewalFreq";
        //        //pid.SqlDbType = SqlDbType.Int;
        //        //pid.Value = b.RenewalFreq;
        //        //cmd1.Parameters.Add(pid);

        //        //SqlParameter sid = new SqlParameter();
        //        //sid.ParameterName = "@UnitPrice";
        //        //sid.SqlDbType = SqlDbType.Decimal;
        //        //sid.Value = b.UnitPrice;
        //        //cmd1.Parameters.Add(sid);

        //        //SqlParameter gid = new SqlParameter();
        //        //gid.ParameterName = "@todate";
        //        //gid.SqlDbType = SqlDbType.DateTime;
        //        //gid.Value = b.todate;
        //        //cmd1.Parameters.Add(gid);

        //        //SqlParameter fid = new SqlParameter();
        //        //fid.ParameterName = "@fromdate";
        //        //fid.SqlDbType = SqlDbType.DateTime;
        //        //fid.Value = b.fromdate;
        //        //cmd1.Parameters.Add(fid);


        //        //SqlParameter nActive = new SqlParameter("@insupddelflag", SqlDbType.Char);
        //        //nActive.Value = b.insupddelflag;
        //        //cmd1.Parameters.Add(nActive);

        //        //cmd1.ExecuteScalar();
        //        //conn.Close();


              

        //        //SqlCommand cmd2 = new SqlCommand();
        //        //cmd2.CommandType = CommandType.StoredProcedure;
        //        //cmd2.CommandText = "InsUpdDelLicenseDetails1";
        //        //cmd2.Connection = conn;

        //        //SqlParameter idd = new SqlParameter();
        //        //idd.ParameterName = "@Id";
        //        //idd.SqlDbType = SqlDbType.Int;
        //        //idd.Value = Convert.ToString(b.Id);
        //        //cmd1.Parameters.Add(idd);

              
        //        //SqlParameter nn = new SqlParameter();
        //        //nn.ParameterName = "@FeatureTypeId";
        //        //nn.SqlDbType = SqlDbType.Int;
        //        //nn.Value = b.FeatureName;
        //        //cmd.Parameters.Add(nn);

        //        //SqlParameter nm = new SqlParameter();
        //        //nm.ParameterName = "@FeatureLabel";
        //        //nm.SqlDbType = SqlDbType.VarChar;
        //        //nm.Value = b.FeatureLabel;
        //        //cmd.Parameters.Add(nm);

        //        //SqlParameter mn = new SqlParameter();
        //        //mn.ParameterName = "@FeatureValue";
        //        //mn.SqlDbType = SqlDbType.VarChar;
        //        //mn.Value = b.FeatureValue;
        //        //cmd.Parameters.Add(mn);



        //        return new HttpResponseMessage(HttpStatusCode.OK);
        //    }
        //    catch (Exception ex)
        //    {
        //        if (conn != null && conn.State == ConnectionState.Open)
        //        {
        //            conn.Close();
        //        }
        //        string str = ex.Message;
        //        return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
        //    }
        //}
        //public void Options() { }
    }
}

