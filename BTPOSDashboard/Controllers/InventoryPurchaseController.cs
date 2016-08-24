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
    public class InventoryPurchaseController : ApiController
    {
        public DataTable GetInventoryPurchases()
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventoryPurchases credentials....");
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetInventoryPurchases";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetInventoryPurchases Credentials completed.");
            
            // int found = 0;
            return Tbl;
        }
        [HttpPost]

        public HttpResponseMessage SaveInventoryPurchases(IPurchases P)
        {

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveInventoryPurchases credentials....");
            SqlConnection conn = new SqlConnection();
            try
            {

            //connect to database
            
            
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsupdInventoryPurchases";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@Id";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = P.Id;
                cmd.Parameters.Add(gsn);

                SqlParameter guid = new SqlParameter();
                guid.ParameterName = "@ItemName";
                guid.SqlDbType = SqlDbType.VarChar;
                guid.Value = P.ItemName;
                cmd.Parameters.Add(guid);

                SqlParameter gida = new SqlParameter();
                gida.ParameterName = "@Quantity";
                gida.SqlDbType = SqlDbType.Int;
                gida.Value = P.Quantity;
                cmd.Parameters.Add(gida);

                SqlParameter gidb = new SqlParameter();
                gidb.ParameterName = "@PerUnitPrice";
                gidb.SqlDbType = SqlDbType.Int;
                gidb.Value = P.PerUnitPrice;
                cmd.Parameters.Add(gidb);

                SqlParameter gb = new SqlParameter();
                gb.ParameterName = "@PurchaseDate";
                gb.SqlDbType = SqlDbType.DateTime;
                gb.Value = P.PurchaseDate;
                cmd.Parameters.Add(gb);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@PurchaseOrderNumber";
                gid.SqlDbType = SqlDbType.VarChar;               
                gid.Value = P.PurchaseOrderNumber;
                cmd.Parameters.Add(gid);



                //SqlParameter ga = new SqlParameter();
                //ga.ParameterName = "@Active";
                //ga.SqlDbType = SqlDbType.Int;
                //ga.Value = Convert.ToString(n.Active);
                //cmd.Parameters.Add(ga);

                cmd.ExecuteScalar();

                //if the code is for btpos then insert the no. of bt pos needed

                #region create bt pos instances

                switch (P.subCategoryId)
                {
                    case 1:
                        for (int poscount = 0; poscount < P.Quantity; poscount++)
                        {
                            try
                            {
                                //connect to database
                                cmd = new SqlCommand();
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.CommandText = "InsUpdDelBTPOSDetails";
                                cmd.Connection = conn;

                                SqlParameter ba = new SqlParameter("@Id", SqlDbType.Int);
                                ba.Value = -1;
                                cmd.Parameters.Add(ba);

                                SqlParameter bb = new SqlParameter("@CompanyId", SqlDbType.Int);
                                bb.Value = 1;
                                cmd.Parameters.Add(bb);

                                SqlParameter bd = new SqlParameter("@IMEI", SqlDbType.VarChar, 20);
                                bd.Value = DBNull.Value;
                                cmd.Parameters.Add(bd);


                                SqlParameter bf = new SqlParameter("@POSID", SqlDbType.VarChar, 20);
                                bf.Value = "POS" + Guid.NewGuid().ToString().Replace("-", "");
                                cmd.Parameters.Add(bf);

                                SqlParameter bh = new SqlParameter("@StatusId", SqlDbType.Int);
                                bh.Value = 1;
                                cmd.Parameters.Add(bh);

                                SqlParameter ipconfig = new SqlParameter("@ipconfig", SqlDbType.VarChar, 20);
                                ipconfig.Value = "";
                                cmd.Parameters.Add(ipconfig);


                                SqlParameter active = new SqlParameter("@active", SqlDbType.Int);
                                active.Value = 1;
                                cmd.Parameters.Add(active);

                                //SqlParameter fo = new SqlParameter("@fleetownerid", SqlDbType.Int);
                                //fo.Value = 1;
                                //cmd.Parameters.Add(fo);

                                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                                insupdflag.Value = "I";
                                cmd.Parameters.Add(insupdflag);

                                cmd.ExecuteNonQuery();

                            }
                            catch (Exception ex)
                            {

                            }
                           
                        }

                        break;
                }
                #endregion create bt pos instances

                 
                conn.Close();

                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "SaveInventoryPurchases Credentials completed.");
            
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
