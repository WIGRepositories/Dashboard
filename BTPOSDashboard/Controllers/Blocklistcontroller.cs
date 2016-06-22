using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using BTPOSDashboardAPI.Models;

namespace blocklist1.Controllers
{
    public class Blocklistcontroller : ApiController
    {
        [HttpGet]

        public DataTable POSDashboard1()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBlockList";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }


        [HttpPost]
        public HttpResponseMessage pos(Blocklist b)
        {
           


            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            { 
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelELBlockList";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.VarChar;
            Aid.Value = b.Id;
            cmd.Parameters.Add(Aid);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@ItemId";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = b.ItemId;
            Gid.Value = Convert.ToString(b.ItemId);
            cmd.Parameters.Add(Gid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@ItemTypeId";
            lid.SqlDbType = SqlDbType.VarChar;
            lid.Value = b.ItemTypeId;
            cmd.Parameters.Add(lid);
           

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@Formdate ";
            pid.SqlDbType = SqlDbType.VarChar;
            pid.Value =b.Formdate;
            cmd.Parameters.Add(pid);
          
            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@Todate";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.Todate;
            cmd.Parameters.Add(ss);
            

            SqlParameter ii = new SqlParameter();
            ii.ParameterName = "@Active";
            ii.SqlDbType = SqlDbType.VarChar;
            ii.Value = b.Active;
            cmd.Parameters.Add(ii);
          

            SqlParameter vv = new SqlParameter();
            vv.ParameterName = "@Desc ";
            vv.SqlDbType = SqlDbType.VarChar;
            vv.Value =b.Desc;
            cmd.Parameters.Add(vv);



SqlParameter mm = new SqlParameter();
            mm.ParameterName = "@Reason ";
            mm.SqlDbType = SqlDbType.VarChar;
            mm.Value = b.Reason ;
            cmd.Parameters.Add(mm);


SqlParameter nn = new SqlParameter();
            nn.ParameterName = "@Blockedby";
            nn.SqlDbType = SqlDbType.VarChar;
            nn.Value =Convert.ToString(b.Blockedby);
            cmd.Parameters.Add(nn);
            


SqlParameter pp= new SqlParameter();
            pp.ParameterName = "@UnBlockedby ";
            pp.SqlDbType = SqlDbType.VarChar;
            pp.Value = b.UnBlockedby;
            cmd.Parameters.Add(pp);

SqlParameter kk= new SqlParameter();
            kk.ParameterName = "@Blockedon";
            kk.SqlDbType = SqlDbType.VarChar;
            kk.Value =Convert.ToString(b.Blockedon);
            cmd.Parameters.Add(kk);
SqlParameter yy= new SqlParameter();
            yy.ParameterName = "@UnBlockedon";
            yy.SqlDbType = SqlDbType.VarChar;
            yy.Value =Convert.ToString(b.UnBlockedon);
            cmd.Parameters.Add(yy);
            



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





   

