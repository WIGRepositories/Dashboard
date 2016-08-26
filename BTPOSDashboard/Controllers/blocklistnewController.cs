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
    public class blocklistnewController : ApiController
    {
        //[HttpGet]

        //public DataTable Getblocklist(int selectedId)
        //{
        //    DataTable Tbl = new DataTable();


        //    //connect to database
        //    SqlConnection conn = new SqlConnection();
        //    //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
        //    conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "GetBlockListNew";
        //    cmd.Connection = conn;

        //    SqlParameter gid = new SqlParameter();
        //    gid.ParameterName = "@selectedId";
        //    gid.SqlDbType = SqlDbType.Int;
        //    gid.Value = selectedId;
        //    cmd.Parameters.Add(gid);

        //    DataSet ds = new DataSet();
        //    SqlDataAdapter db = new SqlDataAdapter(cmd);
        //    db.Fill(ds);
        //    Tbl = ds.Tables[0];

        //    // int found = 0;
        //    return Tbl;
        //}

        [HttpGet]
        [Route("api/blocklistnew/GetBlockDetails")]
        public DataTable GetBlockDetails(int selectedId)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBlockListNew";
            cmd.Connection = conn;

            SqlParameter gid = new SqlParameter();
            gid.ParameterName = "@selectedId";
            gid.SqlDbType = SqlDbType.Int;
            gid.Value = selectedId;
            cmd.Parameters.Add(gid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;

        }


        [HttpPost]

        public HttpResponseMessage saveBocklist(IEnumerable<Sblocklist> Blist)
        {
            SqlConnection conn = new SqlConnection();
            try
            {


                //connect to database

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelBlocklist";
                cmd.Connection = conn;
                conn.Open();

                foreach (Sblocklist b in Blist)
                {

                    SqlParameter rid = new SqlParameter();
                    rid.ParameterName = "@ItemName";
                    rid.SqlDbType = SqlDbType.Int;
                    rid.Value = b.ItemName;
                    cmd.Parameters.Add(rid);

                    SqlParameter sid = new SqlParameter();
                    sid.ParameterName = "@Reason";
                    sid.SqlDbType = SqlDbType.VarChar;
                    sid.Value = b.Reason;
                    cmd.Parameters.Add(sid);

                    //SqlParameter cmpid = new SqlParameter();
                    //cmpid.ParameterName = "@cmpId";
                    //cmpid.SqlDbType = SqlDbType.Int;
                    //cmpid.Value = b.CompanyId;
                    //cmd.Parameters.Add(cmpid);


                    //SqlParameter fid = new SqlParameter();
                    //fid.ParameterName = "@fleetOwnerId";
                    //fid.SqlDbType = SqlDbType.Int;
                    //fid.Value = b.FleetOwnerId;
                    //cmd.Parameters.Add(fid);




                    SqlParameter flag = new SqlParameter();
                    flag.ParameterName = "@insupddelflag";
                    flag.SqlDbType = SqlDbType.VarChar;
                    flag.Value = b.insupddelflag;
                    cmd.Parameters.Add(flag);

                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }

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
    }
}
      
 
   
