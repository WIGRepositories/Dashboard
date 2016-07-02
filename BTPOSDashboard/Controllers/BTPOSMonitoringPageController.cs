using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.Sql;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTPOSDashboard.Controllers
{
    public class BTPOSMonitoringPageController : ApiController
    {
        [HttpGet]
        public DataTable getBTPOSMonitoring()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSMonitoring";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;

        }
        [HttpPost]
        public DataTable SaveBTPOSMonitoring(BTPOSMoitoringPage BP)
        {
             DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelBTPOSMoitoringPage";
                cmd.Connection = conn;
                conn.Open();
      
                SqlParameter BTPOSId = new SqlParameter("@BTPOSId", SqlDbType.Int);
                BTPOSId.Value = BP.BTPOSId;
                cmd.Parameters.Add(BTPOSId);

                SqlParameter Xcoordinate = new SqlParameter("@Xcoordinate", SqlDbType.Float);
                Xcoordinate.Value = BP.Xcoordinate;
                cmd.Parameters.Add(Xcoordinate);

                SqlParameter Ycoordinate = new SqlParameter("@Ycoordinate", SqlDbType.Float);
                Ycoordinate.Value = BP.Ycoordinate;
                cmd.Parameters.Add(Ycoordinate);

                SqlParameter LocationName = new SqlParameter("@LocationName", SqlDbType.VarChar, 50);
                LocationName.Value = BP.LocationName;
                cmd.Parameters.Add(LocationName);

                SqlParameter SNo = new SqlParameter("@SNo", SqlDbType.Int);
                SNo.Value = BP.SNo;
                cmd.Parameters.Add(SNo);

                SqlParameter DateTime = new SqlParameter("@DateTime", SqlDbType.DateTime);
                DateTime.Value = BP.DateTime;
                cmd.Parameters.Add(DateTime);

                cmd.ExecuteScalar();

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
                string str = ex.Message;
            }
            // int found = 0;
            return Tbl;
        }
    }


}


