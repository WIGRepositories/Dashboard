using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using System.Data.SqlClient;

namespace BTPOSDashboard.Controllers
{
    public class VehicleLayoutController : ApiController
    {

        [HttpPost]
        public DataSet saveVehicleLayout(VehicleLayout vc)
        {
            //DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelVehicleLayout";
            cmd.Connection = conn;

            SqlParameter gsaa = new SqlParameter();                    
	        gsaa.ParameterName = "@Id";
            gsaa.SqlDbType = SqlDbType.Int;         
            cmd.Parameters.Add(gsaa);

            SqlParameter gsab = new SqlParameter();
            gsab.ParameterName = "@VehicleLayoutTypeId";
            gsab.SqlDbType = SqlDbType.Int;           
            cmd.Parameters.Add(gsab);

            SqlParameter gsac = new SqlParameter();
            gsac.ParameterName = "@RowNo";
            gsac.SqlDbType = SqlDbType.Int;         
            cmd.Parameters.Add(gsac);

            SqlParameter nvr = new SqlParameter();
            nvr.ParameterName = "@ColNo";
            nvr.SqlDbType = SqlDbType.Int;          
            cmd.Parameters.Add(nvr);

            SqlParameter gsk = new SqlParameter();
            gsk.ParameterName = "@VehicleTypeId";
            gsk.SqlDbType = SqlDbType.Int;          
            cmd.Parameters.Add(gsk);

            //@needHireVehicle
            SqlParameter nhv = new SqlParameter();
            nhv.ParameterName = "@label";
            nhv.SqlDbType = SqlDbType.VarChar;          
            cmd.Parameters.Add(nhv);


            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            // Tbl = ds.Tables[0];

            // int found = 0;
             return ds;

        }
    }
}
