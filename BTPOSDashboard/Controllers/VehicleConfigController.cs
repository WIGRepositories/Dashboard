using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Configuration;

namespace BTPOSDashboardAPI.Controllers
{
    public class VehicleConfigController : ApiController
    {
    
        [HttpPost]

        public DataTable VConfig(VehicleConfig vc)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "VehicleConfiguration";
            cmd.Connection = conn;
                    

            SqlParameter gsaa = new SqlParameter();
            gsaa.ParameterName = "@needRoutes";
            gsaa.SqlDbType = SqlDbType.Int;
            gsaa.Value = (vc.needRoutes == null) ? 0 : 1;
            cmd.Parameters.Add(gsaa);

            SqlParameter gsab = new SqlParameter();
            gsab.ParameterName = "@needRoles";
            gsab.SqlDbType = SqlDbType.Int;
            gsab.Value = (vc.needRoles == null) ? 0 : 1;
            cmd.Parameters.Add(gsab);

           SqlParameter gsac = new SqlParameter();
            gsac.ParameterName = "@needfleetowners";
            gsac.SqlDbType = SqlDbType.Int;
            gsac.Value = (vc.needfleetowners == null) ? 0 : 1; 
            cmd.Parameters.Add(gsac);

            SqlParameter nvr = new SqlParameter();
            nvr.ParameterName = "@needvehicleRegno";
            nvr.SqlDbType = SqlDbType.Int;
            nvr.Value = (vc.needvehicleRegno == null) ? 0 : 1;
            cmd.Parameters.Add(nvr); 

            SqlParameter nvl = new SqlParameter();
            nvl.ParameterName = "@needVehicleLayout";
            nvl.SqlDbType = SqlDbType.Int;
            nvl.Value = (vc.needVehicleLayout == null) ? 0 : 1;
            cmd.Parameters.Add(nvl);

            SqlParameter nst = new SqlParameter();
            nst.ParameterName = "@needServiceType";
            nst.SqlDbType = SqlDbType.Int;
            nst.Value = (vc.needServiceType == null) ? 0 : 1;
            cmd.Parameters.Add(nst); 

            SqlParameter ncn = new SqlParameter();
            ncn.ParameterName = "@needCompanyName";
            ncn.SqlDbType = SqlDbType.Int;
            ncn.Value = (vc.needCompanyName == null) ? 0 : 1;
            cmd.Parameters.Add(ncn);

            SqlParameter gsk = new SqlParameter();
            gsk.ParameterName = "@needvehicleType";
            gsk.SqlDbType = SqlDbType.Int;
            gsk.Value = (vc.needvehicleType == null) ? 0 : 1; 
            cmd.Parameters.Add(gsk);               

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;		

        }

        //[HttpPost]
        //public DataTable sBTPOSList(BTPOSDetails[] poslist)
        //{
        //    DataTable Tbl = new DataTable();

        //     try
        //    {
        //         //foreach(BTPOSDetails pos in poslist)
        //         //{
        //         //    string str = pos.IMEI;

        //         //}

        //    }
        //     catch (Exception ex)
        //     {
        //         string str = ex.Message;
        //     }
        //    return Tbl;
        //}

   
        public void Options()
        {
        }

    }
}
