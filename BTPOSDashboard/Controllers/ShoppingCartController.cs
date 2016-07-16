using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboard.Controllers
{
    public class ShoppingCartController : ApiController
    {
        [HttpGet]
        public DataTable GetItems()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getShoppingCart";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;

        }
        [HttpPost]
        [Route("api/ShoppingCart/SaveCartItems")]
        public HttpResponseMessage SaveCartItems(Shoppingcarts items1)
        {
          //  DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {


                //connect to database

                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelsalesorder";
                cmd.Connection = conn;

                conn.Open();
                SqlParameter Cid = new SqlParameter();
                Cid.ParameterName = "@Id";
                Cid.SqlDbType = SqlDbType.Int;
                Cid.Value = items1.Id;
                cmd.Parameters.Add(Cid);

                SqlParameter gsn = new SqlParameter();
                gsn.ParameterName = "@Item";
                gsn.SqlDbType = SqlDbType.Int;
                gsn.Value = items1.Item;
                cmd.Parameters.Add(gsn);

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@TransactionId";
                gs.SqlDbType = SqlDbType.Int;
                gs.Value = items1.TransactionId;
                cmd.Parameters.Add(gs);

                SqlParameter gn = new SqlParameter();
                gn.ParameterName = "@Status";
                gn.SqlDbType = SqlDbType.Int;
                gn.Value = items1.Status;
                cmd.Parameters.Add(gn);

                SqlParameter gsab = new SqlParameter();
                gsab.ParameterName = "@SalesOrderNum";
                gsab.SqlDbType = SqlDbType.NVarChar;
                gsab.Value = items1.SalesOrderNum;
                cmd.Parameters.Add(gsab);


                SqlParameter gg = new SqlParameter();
                gg.ParameterName = "@Quantity";
                gg.SqlDbType = SqlDbType.Decimal;
                gg.Value = items1.Quantity;
                cmd.Parameters.Add(gg);

                SqlParameter gg1 = new SqlParameter();
                gg1.ParameterName = "@Date";
                gg1.SqlDbType = SqlDbType.DateTime;
                gg1.Value = items1.Date;
                cmd.Parameters.Add(gg1);


                SqlParameter gsac = new SqlParameter("@amount", SqlDbType.Decimal);
                gsac.Value = items1.amount;
                cmd.Parameters.Add(gsac);



                cmd.ExecuteScalar();
               // cmd.Parameters.Clear();
               conn.Close();



                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsUpdDelPayments";
                cmd1.Connection = conn;

                // conn.Open();
                //SqlParameter Cid = new SqlParameter();
                //Cid.ParameterName = "@Id";
                //Cid.SqlDbType = SqlDbType.Int;
                //Cid.Value = f.Id; public List<itemslist> ilist { get; set; }
                //cmd.Parameters.Add(Cid);

                //SqlParameter gsn1 = new SqlParameter();
                //gsn1.ParameterName = "@Item";
                //gsn1.SqlDbType = SqlDbType.Int;
                //gsn1.Value = f.Item;
                //cmd.Parameters.Add(gsn1);
              //  conn.Open();
                List<itemslist> ilist = null;
                  if (items1.slist != null && items1.slist.Count > 0)
                {
                    ilist = items1.slist;
                }

                foreach (itemslist n in ilist)
                {

                    SqlParameter gsab1 = new SqlParameter();
                    gsab1.ParameterName = "@Transaction_Num";
                    gsab1.SqlDbType = SqlDbType.VarChar;
                    gsab1.Value = n.Transaction_Num;
                    cmd.Parameters.Add(gsab1);



                    SqlParameter gs1 = new SqlParameter();
                    gs1.ParameterName = "@amount";
                    gs1.SqlDbType = SqlDbType.Decimal;
                    gs1.Value = n.amount;
                    cmd.Parameters.Add(gs1);


                    SqlParameter gss = new SqlParameter();
                    gss.ParameterName = "@TransactionId";
                    gss.SqlDbType = SqlDbType.Int;
                    gss.Value = n.TransactionId;
                    cmd.Parameters.Add(gss);

                    SqlParameter g1 = new SqlParameter();
                    g1.ParameterName = "@PaymentMode";
                    g1.SqlDbType = SqlDbType.Int;
                    g1.Value = n.PaymentMode;
                    cmd.Parameters.Add(g1);

                    SqlParameter g12 = new SqlParameter();
                    g12.ParameterName = "@Date";
                    g12.SqlDbType = SqlDbType.DateTime;
                    g12.Value = n.Date;
                    cmd.Parameters.Add(g12);


                    SqlParameter ga = new SqlParameter();
                    ga.ParameterName = "@Transactionstatus";
                    ga.SqlDbType = SqlDbType.Int;
                    ga.Value = n.Transactionstatus;
                    cmd.Parameters.Add(ga);

                    SqlParameter sg1 = new SqlParameter();
                    sg1.ParameterName = "@Gateway_transId";
                    sg1.SqlDbType = SqlDbType.VarChar;
                    sg1.Value = n.Gateway_transId;
                    cmd.Parameters.Add(sg1);

                    cmd1.ExecuteScalar();
                    cmd1.Parameters.Clear();


                    //return new HttpResponseMessage(HttpStatusCode.OK);
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

        public void Options()
        {
        }

        }
    }



