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
    public class LicenseController : ApiController
    {
       [HttpGet]
        public DataTable getlicense()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getLicensedetails";
            cmd.Connection = conn;

           

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }



        [HttpPost]
       public DataTable SaveLicense(LicenseDetails b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "insupdDelLicensedetails";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Cid = new SqlParameter();
            Cid.ParameterName = "@Id";
            Cid.SqlDbType = SqlDbType.Int;
            Cid.Value =Convert.ToInt32(b.Id);
            cmd.Parameters.Add(Cid);

            SqlParameter lid = new SqlParameter();
            lid.ParameterName = "@LicenseTypeId";
            lid.SqlDbType = SqlDbType.Int;
            lid.Value = Convert.ToInt32(b.LicenseTypeId);
            cmd.Parameters.Add(lid);

            SqlParameter pname = new SqlParameter();
            pname.ParameterName = "@FeatureName";
            pname.SqlDbType = SqlDbType.VarChar;
            pname.Value = b.FeatureName;
            cmd.Parameters.Add(pname);

            SqlParameter pfeat = new SqlParameter();
            pfeat.ParameterName = "@FeatureValue";
            pfeat.SqlDbType = SqlDbType.VarChar;
            pfeat.Value = b.FeatureValue;
            cmd.Parameters.Add(pfeat);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@FeatureType";
            Gid.SqlDbType = SqlDbType.Int;
            Gid.Value = Convert.ToInt32(b.FeatureType);
            cmd.Parameters.Add(Gid);
            
            SqlParameter pDesc = new SqlParameter();
            pDesc.ParameterName = "@Description";
            pDesc.SqlDbType = SqlDbType.VarChar;
            pDesc.Value = b.Description;
            cmd.Parameters.Add(pDesc);

            SqlParameter pesc = new SqlParameter();
            pesc.ParameterName = "@effectiveFrom ";
            pesc.SqlDbType = SqlDbType.DateTime;
            pesc.Value =null;
            cmd.Parameters.Add(pesc);
            SqlParameter pesci = new SqlParameter();
            pesci.ParameterName = "@effectiveTill ";
            pesci.SqlDbType = SqlDbType.DateTime;
            pesci.Value = null;
            cmd.Parameters.Add(pesci);
            SqlParameter plab = new SqlParameter();
            plab.ParameterName = "@Label";
            plab.SqlDbType = SqlDbType.VarChar;
            plab.Value = b.Label;
            cmd.Parameters.Add(plab);

            SqlParameter plabcl = new SqlParameter();
            plabcl.ParameterName = "@labelclass";
            plabcl.SqlDbType = SqlDbType.VarChar;
            plabcl.Value = b.labelclass;
            cmd.Parameters.Add(plabcl);
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
        public void Options() { 
        }

    }
    }

