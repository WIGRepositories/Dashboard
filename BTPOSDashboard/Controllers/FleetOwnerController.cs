using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;

namespace BTPOSDashboard.Controllers
{
    public class FleetOwnerController : ApiController
    {
        [HttpGet]
        public DataTable getFleetOwner()//Main Method
        {


            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "getFleetOwner";
            cmd.Connection = conn;
            //SqlParameter empid = new SqlParameter("@EmpNo", SqlDbType.Int);
            //empid.Value = empid;
           // cmd.Parameters.Add(empid);
          

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }

    }
}
