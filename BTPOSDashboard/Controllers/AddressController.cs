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
    public class AddressController : ApiController
    {
        [HttpGet]
        public DataTable Addrs()//Main Method
        {
           // System.Configuration.ConnectionStringSettings connString;
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            
            
            //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetAddress";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
          [HttpPost]
        public HttpResponseMessage Addres(Address A)
        {
            SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database
                
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "insAddress";
                cmd.Connection = conn;
                conn.Open();
                SqlParameter AId = new SqlParameter();
                AId.ParameterName = "@Id";
                AId.SqlDbType = SqlDbType.Int;
                AId.Value = Convert.ToString(A.Id);
                cmd.Parameters.Add(AId);
                SqlParameter Acityid  = new SqlParameter();
                Acityid.ParameterName = "@cityid";
                Acityid.SqlDbType = SqlDbType.Int;
                Acityid.Value = Convert.ToString(A.cityid);
                cmd.Parameters.Add(Acityid);
                SqlParameter Astateid = new SqlParameter();
                Astateid.ParameterName = "@stateid";
                Astateid.SqlDbType = SqlDbType.Int;
                Astateid.Value = Convert.ToString(A.stateid);
                cmd.Parameters.Add(Astateid);
                SqlParameter Acountryid = new SqlParameter();
                Acountryid.ParameterName = "@countryid ";
                Acountryid.SqlDbType = SqlDbType.Int;
                Acountryid.Value = Convert.ToString(A.countryid);
                cmd.Parameters.Add(Acountryid);
                SqlParameter Astreet1 = new SqlParameter();
                Astreet1.ParameterName = "@street1";
                Astreet1.SqlDbType = SqlDbType.VarChar;
                Astreet1.Value = A.street1;
                cmd.Parameters.Add(Astreet1);
                SqlParameter Astreet2= new SqlParameter();
                Astreet2.ParameterName = "@street2";
                Astreet2.SqlDbType = SqlDbType.VarChar;
                Astreet2.Value =A.street2;
                cmd.Parameters.Add(Astreet2);
                SqlParameter Azipcodeid = new SqlParameter();
                Azipcodeid.ParameterName = "@zipcodeid";
                Azipcodeid.SqlDbType = SqlDbType.Int;
                Azipcodeid.Value = Convert.ToString(A.zipcodeid);
                cmd.Parameters.Add(Azipcodeid);
                cmd.ExecuteScalar();
                conn.Close();

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

        public DataTable Tbl { get; set; }
        
    }
}
