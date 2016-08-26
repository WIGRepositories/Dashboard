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
  
    public class BtposRoutesController : ApiController
    {
          [HttpGet]
          [Route("api/BtposRoutes/GetFleetBtposRoutes")]
        public DataTable getBtposRoutes(int cmpId, int fleetOwnerId)
          {
              DataTable Tb1 = new DataTable();
              LogTraceWriter traceWriter = new LogTraceWriter();
              traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getBtposRoutes credentials....");

              //connect to database
              SqlConnection conn = new SqlConnection();
              //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
              conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

             

              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "[GetFleetDetails]";
              cmd.Connection = conn;

              SqlParameter gid = new SqlParameter();
              gid.ParameterName = "@cmpId";
              gid.SqlDbType = SqlDbType.Int;
              gid.Value = cmpId;
              cmd.Parameters.Add(gid);

              SqlParameter fid = new SqlParameter();
              fid.ParameterName = "@fleetOwnerId";
              fid.SqlDbType = SqlDbType.Int;
              fid.Value = fleetOwnerId;
              cmd.Parameters.Add(fid);

             // SqlParameter fid1 = new SqlParameter();
             // fid1.ParameterName = "@POSID";
             // fid1.SqlDbType = SqlDbType.Int;
             // fid1.Value = POSID;
             // cmd.Parameters.Add(fid1);

             // SqlParameter rid = new SqlParameter();
             //rid.ParameterName = "@route";
             // rid.SqlDbType = SqlDbType.Varchar;
             // rid.Value = fleetOwnerId;
             // cmd.Parameters.Add(rid);



              cmd.Connection = conn;
              DataSet ds = new DataSet();
              SqlDataAdapter db = new SqlDataAdapter(cmd);
              db.Fill(ds);
             Tb1= ds.Tables[0];
             traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "getBtposRoutes Credentials completed.");
              // int found = 0;
              return Tb1;


          }

          //[HttpPost]
          //public DataTable NewFleetDetails(FleetDetails n)
          //{
          //    DataTable Tbl = new DataTable();

          //    try
          //    {
          //        //connect to database
          //        SqlConnection conn = new SqlConnection();
          //        // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
          //        conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

          //        SqlCommand cmd = new SqlCommand();
          //        cmd.CommandType = CommandType.StoredProcedure;
          //        cmd.CommandText = "InsupdelFleetDetails";
          //        cmd.Connection = conn;

          //        conn.Open();

          //        SqlParameter gsa = new SqlParameter();
          //        gsa.ParameterName = "@Id";
          //        gsa.SqlDbType = SqlDbType.Int;
          //        gsa.Value = n.Id;
          //        cmd.Parameters.Add(gsa);

          //        SqlParameter gsn = new SqlParameter();
          //        gsn.ParameterName = "@VehicleRegNo";
          //        gsn.SqlDbType = SqlDbType.VarChar;
          //        gsn.Value = n.VehicleRegNo;
          //        cmd.Parameters.Add(gsn);

                 
                 

          //        SqlParameter gsac = new SqlParameter("@POSID", SqlDbType.VarChar);
          //        gsac.Value = n.POSID;
          //        gsac.SqlDbType = SqlDbType.Int;
          //        cmd.Parameters.Add(gsac);

          //        SqlParameter gsn = new SqlParameter();
          //        gsn.ParameterName = "@route";
          //        gsn.SqlDbType = SqlDbType.VarChar;
          //        gsn.Value = n.VehicleRegNo;
          //        cmd.Parameters.Add(gsn);


                

          //        SqlParameter nActive = new SqlParameter("@Active", SqlDbType.Int);
          //        nActive.Value = n.Active;
          //        cmd.Parameters.Add(nActive);
          //        cmd.ExecuteScalar();
          //        conn.Close();
          //        // DataSet ds = new DataSet();
          //        //SqlDataAdapter db = new SqlDataAdapter(cmd);
          //        //db.Fill(ds);
          //        //Tbl = ds.Tables[0];
          //    }
          //    catch (Exception ex)
          //    {
          //        string str = ex.Message;
          //    }
          //    // int found = 0;
          //    return Tbl;

          //}

          [HttpGet]
          public DataSet VehicleConfiguration()
          {
              DataSet ds = new DataSet();
              LogTraceWriter traceWriter = new LogTraceWriter();
              traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "VehicleConfiguration credentials....");
              //connect to database
              SqlConnection conn = new SqlConnection();
              //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
              conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

              SqlCommand cmd = new SqlCommand();
              cmd.CommandType = CommandType.StoredProcedure;
              cmd.CommandText = "VehicleConfiguration";
              cmd.Connection = conn;

              SqlDataAdapter db = new SqlDataAdapter(cmd);

              db.Fill(ds);
              traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "VehicleConfiguration Credentials completed.");
              return ds;
          }



    }
}
