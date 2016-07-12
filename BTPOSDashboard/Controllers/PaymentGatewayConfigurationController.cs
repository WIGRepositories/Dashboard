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
    public class PaymentGatewayConfigurationController : ApiController
    {
        [HttpGet]

        public DataTable GetPaymentGateway()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getPaymentGatewaySettings";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
         [HttpPost]
        public HttpResponseMessage SavePaymentGatewaySettings(PaymentGatewaySettings b)
        {
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelPaymentGatewaySettings";
            cmd.Connection = conn;
            conn.Open();

            //SqlParameter Aid = new SqlParameter();
            //Aid.ParameterName = "@";
            //Aid.SqlDbType = SqlDbType.VarChar;
            //Aid.Value = b.Id;
            //Aid.Value = Convert.ToString(b.Id);
            //cmd.Parameters.Add(Aid);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@providername";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.providername;
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@enddate";
            lid.SqlDbType = SqlDbType.Date;
            lid.Value = b.enddate;
            cmd.Parameters.Add(lid);
           

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@hashkey";
            pid.SqlDbType = SqlDbType.Date;
            pid.Value =b.hashkey;
            cmd.Parameters.Add(pid);
          
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@PaymentGatewayTypeId";
            ss.SqlDbType = SqlDbType.Int;
            ss.Value = b.PaymentGatewayTypeId;           
            cmd.Parameters.Add(ss);
            

            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@pwd";
            ii.SqlDbType = SqlDbType.VarChar;
            ii.Value = b.pwd;
            cmd.Parameters.Add(ii);
          

            SqlParameter vv = new SqlParameter();
            vv.ParameterName = "@saltkey";
            vv.SqlDbType = SqlDbType.Date;
            vv.Value =b.saltkey;
            cmd.Parameters.Add(vv);

            SqlParameter vvi = new SqlParameter();
            vvi.ParameterName = "@startdate";
            vvi.SqlDbType = SqlDbType.Date;
            vvi.Value =b.startdate;
            cmd.Parameters.Add(vvi);

            SqlParameter vvu = new SqlParameter();
            vvu.ParameterName = "@username";
            vvu.SqlDbType = SqlDbType.VarChar;
            vvu.Value = b.username;
            cmd.Parameters.Add(vvu);

            SqlParameter vcl = new SqlParameter();
            vcl.ParameterName = "@ClientId";
            vcl.SqlDbType = SqlDbType.VarChar;
            vcl.Value = b.ClientId;
            cmd.Parameters.Add(vcl);

            SqlParameter vsl = new SqlParameter();
            vsl.ParameterName = "@SelectId";
            vsl.SqlDbType = SqlDbType.VarChar;
            vsl.Value = b.SelectId;
            cmd.Parameters.Add(vsl);



            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
           // Tbl = Tables[0];
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
        public void Options() { }

    }
     

 }
    

