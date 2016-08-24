using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTPOSDashboardAPI.Controllers
{
    public class BTPOSDetailsController : ApiController
    {
        //[HttpGet]

        //public DataTable GetBTPOSDetails(int cmpId, int fId)
        //{
        //    DataTable Tbl = new DataTable();


        //    //connect to database
        //    SqlConnection conn = new SqlConnection();
        //    //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "getBTPOSDetails";
        //    cmd.Connection = conn;

        //    SqlParameter cmp = new SqlParameter("@cmpId", SqlDbType.Int);
        //    cmp.Value = cmpId;
        //    cmd.Parameters.Add(cmp);

        //    SqlParameter fo = new SqlParameter("@fleetownerId", SqlDbType.Int);
        //    fo.Value = fId;
        //    cmd.Parameters.Add(fo);

        //    SqlDataAdapter db = new SqlDataAdapter(cmd);            
        //    db.Fill(Tbl);
            
        //    return Tbl;
        //}
        //[HttpGet]

        //public DataTable GetBTPOSDetails1(int cmpId, int fId, int pageno, int pagesize)
        //{

        //    DataTable Tbl = new DataTable();

        //    //connect to database
        //    SqlConnection conn = new SqlConnection();
        //    //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "GetBTPOSDetails";
        //    cmd.Connection = conn;

        //    SqlParameter cmp = new SqlParameter("@cmpId", SqlDbType.Int);
        //    cmp.Value = cmpId;
        //    cmd.Parameters.Add(cmp);

        //    SqlParameter fo = new SqlParameter("@fleetownerId", SqlDbType.Int);
        //    fo.Value = fId;
        //    cmd.Parameters.Add(fo);

        //    SqlParameter pNo = new SqlParameter("@pageno", SqlDbType.Int);
        //    pNo.Value = pageno;
        //    cmd.Parameters.Add(pNo);

        //    SqlParameter pSize = new SqlParameter("@pagesize", SqlDbType.Int);
        //    pSize.Value = pagesize;
        //    cmd.Parameters.Add(pSize);

        //    SqlDataAdapter db = new SqlDataAdapter(cmd);
        //    db.Fill(Tbl);

        //    return Tbl;
        //}

        [HttpGet]

        public DataTable GetBTPOSDetails()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSDetails credentials....");

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSDetails";
            cmd.Connection = conn;

            //SqlParameter cmp = new SqlParameter("@cmpId", SqlDbType.Int);
            //cmp.Value = cmpId;
            //cmd.Parameters.Add(cmp);

            //SqlParameter fo = new SqlParameter("@fleetownerId", SqlDbType.Int);
            //fo.Value = fId;
            //cmd.Parameters.Add(fo);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSDetails Credentials completed.");
            return Tbl;
        }
        [HttpGet]

        public DataSet Paging(int cmpId, int fId, int pageno, int pagesize)
        {

            DataSet Tbl = new DataSet();

        
            //LogTraceWriter traceWriter = new LogTraceWriter();
            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Paging credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSDetails";
            cmd.Connection = conn;

            SqlParameter cmp = new SqlParameter("@cmpId", SqlDbType.Int);
            cmp.Value = cmpId;
            cmd.Parameters.Add(cmp);

            SqlParameter fo = new SqlParameter("@fleetownerId", SqlDbType.Int);
            fo.Value = fId;
            cmd.Parameters.Add(fo);

            SqlParameter pNo = new SqlParameter("@pagenum", SqlDbType.Int);
            pNo.Value = pageno;
            cmd.Parameters.Add(pNo);

            SqlParameter pSize = new SqlParameter("@pagesize", SqlDbType.Int);
            pSize.Value = pagesize;
            cmd.Parameters.Add(pSize);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);

            //traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Validate Credentials completed.");
            return Tbl;
        }
        

        [HttpPost]

        public HttpResponseMessage SaveBTPOSDetails(IEnumerable<BTPOSDetails> posList)
        {
             SqlConnection conn = new SqlConnection();
            try
            {

                LogTraceWriter traceWriter = new LogTraceWriter();
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveBTPOSDetails credentials....");
            // BTPOSDetails n = new BTPOSDetails();
            
                //connect to database
                
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelBTPOSDetails";
                cmd.Connection = conn;

                conn.Open();

                foreach (BTPOSDetails n in posList)
                {
                    SqlParameter ba = new SqlParameter("@Id", SqlDbType.Int);
                     ba.Value = n.Id;
                     cmd.Parameters.Add(ba);

                    SqlParameter bb = new SqlParameter("@CompanyId", SqlDbType.Int);
                    bb.Value = n.CompanyId;
                    cmd.Parameters.Add(bb);

                    SqlParameter bd = new SqlParameter("@IMEI", SqlDbType.VarChar, 20);
                    bd.Value = n.IMEI;
                    cmd.Parameters.Add(bd);


                    SqlParameter bf = new SqlParameter("@POSID", SqlDbType.VarChar, 20);
                    bf.Value = (n.insupdflag == "I") ? "POS" + Guid.NewGuid().ToString().Replace("-", "") : n.POSID;
                    cmd.Parameters.Add(bf);

                    SqlParameter bh = new SqlParameter("@StatusId", SqlDbType.Int);
                    bh.Value = n.StatusId;
                    cmd.Parameters.Add(bh);

                    SqlParameter ipconfig = new SqlParameter("@ipconfig", SqlDbType.VarChar, 20);
                    ipconfig.Value = n.ipconfig;
                    cmd.Parameters.Add(ipconfig);


                    SqlParameter active = new SqlParameter("@active", SqlDbType.Int);
                    active.Value = 1;
                    cmd.Parameters.Add(active);

                    SqlParameter fo = new SqlParameter("@fleetownerid", SqlDbType.Int);
                    fo.Value = n.fleetownerid;
                    cmd.Parameters.Add(fo);

                    //SqlParameter fo1 = new SqlParameter("@pageno", SqlDbType.Int);
                    //fo1.Value = n.fleetownerid;
                    //cmd.Parameters.Add(fo1);

                    //SqlParameter fo2 = new SqlParameter("@pagesize", SqlDbType.Int);
                    //fo2.Value = n.fleetownerid;
                    //cmd.Parameters.Add(fo2);

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                    insupdflag.Value = n.insupdflag;
                    cmd.Parameters.Add(insupdflag);

                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }
                conn.Close();

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveBTPOSDetails Credentials completed.");
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


        //[HttpPost]

        //public HttpResponseMessage SaveBTPOSDetails1(IEnumerable<BTPOSDetails> posList)
        //{
        //    SqlConnection conn = new SqlConnection();
        //    try
        //    {

        //        // BTPOSDetails n = new BTPOSDetails();

        //        //connect to database

        //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
        //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //        SqlCommand cmd1 = new SqlCommand();
        //        cmd1.CommandType = CommandType.StoredProcedure;
        //        cmd1.CommandText = "InsUpdDelBTPOSDetails";
        //        cmd1.Connection = conn;

        //        conn.Open();

        //        foreach (BTPOSDetails n in posList)
        //        {
        //            SqlParameter ba = new SqlParameter("@Id", SqlDbType.Int);
        //            ba.Value = n.Id;
        //            cmd1.Parameters.Add(ba);

        //            SqlParameter bd = new SqlParameter("@IMEI", SqlDbType.VarChar, 20);
        //            bd.Value = n.IMEI;
        //            cmd1.Parameters.Add(bd);

        //            SqlParameter ipconfig = new SqlParameter("@ipconfig", SqlDbType.VarChar, 20);
        //            ipconfig.Value = n.ipconfig;
        //            cmd1.Parameters.Add(ipconfig);

        //            SqlParameter active = new SqlParameter("@active", SqlDbType.Int);
        //            active.Value = 1;
        //            cmd1.Parameters.Add(active);

        //            SqlParameter fo = new SqlParameter("@fleetowner", SqlDbType.Int);
        //            fo.Value = n.fleetownerid;
        //            cmd1.Parameters.Add(fo);

        //            SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
        //            insupdflag.Value = n.insupdflag;
        //            cmd1.Parameters.Add(insupdflag);

        //            cmd1.ExecuteScalar();

        //            cmd1.Parameters.Clear();
        //        }
        //        conn.Close();

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
              

        public void Options()
        {
        }

    }
}
