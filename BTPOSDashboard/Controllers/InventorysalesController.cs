using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Controllers;

namespace BTPOSDashboard.Controllers
{
    public class InventorySalesController : ApiController
    {
         public DataTable GetInventorySales()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInventorySales";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
         [HttpPost]

         public HttpResponseMessage SaveInventorySales(ISales S)
          {
            SqlConnection conn = new SqlConnection();
            try
            {
             //connect to database
            
                 // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                 conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                 SqlCommand cmd = new SqlCommand();
                 cmd.CommandType = CommandType.StoredProcedure;
                 cmd.CommandText = "InsupddelInventorySales";
                 cmd.Connection = conn;

                 conn.Open();
                 SqlParameter gsn = new SqlParameter();
                 gsn.ParameterName = "@Id";
                 gsn.SqlDbType = SqlDbType.Int;
                 gsn.Value = S.Id;
                 cmd.Parameters.Add(gsn);

                 SqlParameter guid = new SqlParameter();
                 guid.ParameterName = "@ItemName";
                 guid.SqlDbType = SqlDbType.VarChar;
                 guid.Value = S.ItemName;
                 cmd.Parameters.Add(guid);

                 SqlParameter gida = new SqlParameter();
                 gida.ParameterName = "@Quantity";
                 gida.SqlDbType = SqlDbType.Int;
                 gida.Value = S.Quantity;
                 cmd.Parameters.Add(gida);

                 SqlParameter gidb = new SqlParameter();
                 gidb.ParameterName = "@PerUnitPrice";
                 gidb.SqlDbType = SqlDbType.Int;
                 gidb.Value = S.PerUnitPrice;
                 cmd.Parameters.Add(gidb);

                 SqlParameter gb = new SqlParameter();
                 gb.ParameterName = "@PurchaseDate";
                 gb.SqlDbType = SqlDbType.VarChar;
                 gb.Value = S.PurchaseDate;
                 cmd.Parameters.Add(gb);

                 SqlParameter gid = new SqlParameter();
                 gid.ParameterName = "@InVoiceNumber";
                 gid.SqlDbType = SqlDbType.Int;
                 gid.Value = S.InVoiceNumber;
                 cmd.Parameters.Add(gid);

               

                 //SqlParameter ga = new SqlParameter();
                 //ga.ParameterName = "@Active";
                 //ga.SqlDbType = SqlDbType.Int;
                 //ga.Value = Convert.ToString(n.Active);
                 //cmd.Parameters.Add(ga);

                 cmd.ExecuteScalar();

                 //if it is bt pos then insert the records as per the quantity 
                #region enter BT POS records

                 BTPOSDetailsController btposctrl = new BTPOSDetailsController();

                 List<BTPOSDetails> btposlist = new List<BTPOSDetails>();

                 for (int count = 0; count < S.Quantity; count++ )
                 {
                     BTPOSDetails btposunit = new BTPOSDetails();
                     btposunit.active = 0;
                     btposunit.fleetownerid = -1;
                     btposunit.Id = -1;
                     btposunit.CompanyId = "-1";
                     btposunit.IMEI = "";
                     btposunit.ipconfig = "";
                     btposunit.POSID = "";
                     btposunit.insupdflag = "I";
                     btposunit.StatusId = -1;
                     btposunit.active = 1;
                     btposlist.Add(btposunit);
                     
                 }

                 btposctrl.SaveBTPOSDetails(btposlist);

                #endregion

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

         public void Options()
         {
         }
       
    }
}
