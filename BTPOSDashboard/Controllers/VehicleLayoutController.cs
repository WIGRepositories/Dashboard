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
        [Route("api/VehicleLayout/saveVehicleLayout")]
        public DataSet saveVehicleLayout(IEnumerable<VehicleLayout> vcList)
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
            conn.Open();

            //  SqlParameter gsaa = new SqlParameter();                    
            //  gsaa.ParameterName = "@Id";
            //  gsaa.SqlDbType = SqlDbType.Int;         
            //  cmd.Parameters.Add(gsaa);
            try
            {
                foreach (VehicleLayout vc in vcList)
                {
                    SqlParameter gsab = new SqlParameter();
                    gsab.ParameterName = "@VehicleLayoutTypeId";
                    gsab.SqlDbType = SqlDbType.Int;
                    gsab.Value = vc.VehicleLayoutTypeId;
                    cmd.Parameters.Add(gsab);

                    SqlParameter gsac = new SqlParameter();
                    gsac.ParameterName = "@RowNo";
                    gsac.SqlDbType = SqlDbType.Int;
                    gsac.Value = vc.RowNo;
                    cmd.Parameters.Add(gsac);

                    SqlParameter nvr = new SqlParameter();
                    nvr.ParameterName = "@ColNo";
                    nvr.SqlDbType = SqlDbType.Int;
                    nvr.Value = vc.ColNo;
                    cmd.Parameters.Add(nvr);

                    SqlParameter gsk = new SqlParameter();
                    gsk.ParameterName = "@VehicleTypeId";
                    gsk.SqlDbType = SqlDbType.Int;
                    gsk.Value = vc.VehicleTypeId;
                    cmd.Parameters.Add(gsk);

                    //@needHireVehicle
                    SqlParameter nhv = new SqlParameter();
                    nhv.ParameterName = "@label";
                    nhv.SqlDbType = SqlDbType.VarChar;
                    nhv.Value = vc.label;
                    cmd.Parameters.Add(nhv);




                    cmd.ExecuteScalar();

                    cmd.Parameters.Clear();
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            // int found = 0;

            return null;
        }
    }
}
