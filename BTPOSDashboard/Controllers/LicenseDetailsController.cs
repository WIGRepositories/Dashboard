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
    public class LicenseDetailsController : ApiController
    {
        [HttpGet]
        public DataTable License()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetLicenseDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
   
        [HttpPost]
         public DataTable btpos(LicenseDetails b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelLicenseDetails";
            cmd.Connection = conn;
            conn.Open();
            SqlParameter Aid = new SqlParameter();
            Aid.ParameterName = "@Id";
            Aid.SqlDbType = SqlDbType.Int;
            Aid.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Aid);

            //  SqlParameter lid = new SqlParameter();
            //lid.ParameterName = "@LicenseCatId";
            //lid.SqlDbType = SqlDbType.Int;
            //lid.Value = Convert.ToString(b.LicenseCatId);
            //cmd.Parameters.Add(lid);

            //SqlParameter ss = new SqlParameter();
            //ss.ParameterName = "@LicenseCode ";
            //ss.SqlDbType = SqlDbType.VarChar;
            //ss.Value = b.LicenseCode ;
            //cmd.Parameters.Add(ss);

            //SqlParameter ii = new SqlParameter();
            //ii.ParameterName = "@LicenseName";
            //ii.SqlDbType = SqlDbType.VarChar;
            //ii.Value = b.LicenseName;
            //cmd.Parameters.Add(ii);
            //SqlParameter ll = new SqlParameter();
            //ll.ParameterName = "@Active";
            //ll.SqlDbType = SqlDbType.VarChar;
            //ll.Value = b.Active;
            //cmd.Parameters.Add(ll);
            SqlParameter nn = new SqlParameter();
            nn.ParameterName = "@FeatureName";
            nn.SqlDbType = SqlDbType.VarChar;
            nn.Value = b.FeatureName;
            cmd.Parameters.Add(nn);

             SqlParameter nm = new SqlParameter();
            nm.ParameterName = "@FeatureLabel";
            nm.SqlDbType = SqlDbType.VarChar;
            nm.Value = b.FeatureLabel;
            cmd.Parameters.Add(nm);

             SqlParameter mn = new SqlParameter();
            mn.ParameterName = "@FeatureValue";
            mn.SqlDbType = SqlDbType.VarChar;
            mn.Value = b.FeatureValue;
            cmd.Parameters.Add(mn);

            // SqlParameter ln = new SqlParameter();
            //ln.ParameterName = "@LabelClass";
            //ln.SqlDbType = SqlDbType.VarChar;
            //ln.Value = b.LabelClass;
            //cmd.Parameters.Add(ln);

            //  SqlParameter gsac = new SqlParameter("@fromDate", SqlDbType.DateTime);
            //gsac.Value = b.fromDate;
            //cmd.Parameters.Add(gsac);


            //SqlParameter gsacd = new SqlParameter("@toDate", SqlDbType.DateTime);
            //gsacd.Value = b.toDate;
            //cmd.Parameters.Add(gsacd);


            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
             //Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
             //int found = 0;
            return Tbl;
        }
        public void Options() { }
    }
}

