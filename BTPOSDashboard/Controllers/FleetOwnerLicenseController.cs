using DAshboard.Models;

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
    public class FleetOwnerLicenseController : ApiController
    {
        [HttpGet]
        public DataTable FleetOwner()//Main Method
        {
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI";
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetFleetOwnerLicense";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
        [HttpPost]
        public DataTable FleetOL(FleetOL B)
        {
            DataTable Tbl = new DataTable();
            try
            {

                //connect to database
                SqlConnection conn = new SqlConnection();
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;Integrated Security=SSPI";
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insFleetOwnerLicense";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter FId = new SqlParameter();
                FId.ParameterName = "@Id";
                FId.SqlDbType = SqlDbType.Int;
                FId.Value = Convert.ToString(B.Id);
                cmd.Parameters.Add(FId);
                SqlParameter FFleetOwnerId = new SqlParameter();
                FFleetOwnerId.ParameterName = "@FleetOwnerId";
                FFleetOwnerId.SqlDbType = SqlDbType.Int;
                FFleetOwnerId.Value = Convert.ToString(B.FleetOwnerId);
                cmd.Parameters.Add(FFleetOwnerId);
                SqlParameter FlicenseId = new SqlParameter();
                FlicenseId.ParameterName = "@LicenseId";
                FlicenseId.SqlDbType = SqlDbType.Int;
                FlicenseId.Value = B.LicenseId;
                cmd.Parameters.Add(FlicenseId);
                SqlParameter FCode = new SqlParameter();
                FCode.ParameterName = "@Code";
                FCode.SqlDbType = SqlDbType.Int;
                FCode.Value =Convert.ToString( B.Code);
                cmd.Parameters.Add(FCode);
                SqlParameter FOFromDate = new SqlParameter();
                FOFromDate.ParameterName = "@FromDate";
                FOFromDate.SqlDbType = SqlDbType.DateTime;
                FOFromDate.Value = B.FromDate;
                cmd.Parameters.Add(FOFromDate);
                SqlParameter FOEndDate = new SqlParameter();
                FOEndDate.ParameterName = "@EndDate";
                FOEndDate.SqlDbType = SqlDbType.DateTime;
                FOEndDate.Value = B.EndDate;
                cmd.Parameters.Add(FOEndDate);
                SqlParameter FONotificationDate = new SqlParameter();
                FONotificationDate.ParameterName = "@NotificationDate";
                FONotificationDate.SqlDbType = SqlDbType.DateTime;
                FONotificationDate.Value = B.NotificationDate;
                cmd.Parameters.Add(FONotificationDate);
                SqlParameter FTransactionId = new SqlParameter();
                FTransactionId.ParameterName = "@TransactionId";
                FTransactionId.SqlDbType = SqlDbType.Int;
                FTransactionId.Value = Convert.ToString(B.TransactionId);
                cmd.Parameters.Add(FTransactionId);
                SqlParameter FRenewedOn = new SqlParameter();
                FRenewedOn.ParameterName = "@RenewedOn ";
                FRenewedOn.SqlDbType = SqlDbType.DateTime;
                FRenewedOn.Value = B.RenewedOn;
                cmd.Parameters.Add(FRenewedOn);

                cmd.ExecuteScalar();
                conn.Close();

                //DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                // db.Fill(ds);
                // Tbl = ds.Tables[0];
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
