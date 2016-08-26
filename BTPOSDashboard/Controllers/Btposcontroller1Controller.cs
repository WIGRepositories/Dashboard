using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace BTPOSDashboard.Controllers
{
    public class Btposcontroller1Controller : ApiController
    {
        [HttpGet]

        public DataTable GetBTPOSDetails()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSDetails1";
            cmd.Connection = conn;

            //SqlParameter cmp = new SqlParameter("@cmpId", SqlDbType.Int);
            //cmp.Value = cmpId;
            //cmd.Parameters.Add(cmp);

            //SqlParameter fo = new SqlParameter("@fleetownerId", SqlDbType.Int);
            //fo.Value = fId;
            //cmd.Parameters.Add(fo);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);

            return Tbl;
        }
        [HttpGet]

        public DataSet Paging(int cmpId, int fId, int pageno, int pagesize)
        {

            DataSet Tbl = new DataSet();

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

            return Tbl;
        }
    }
}
