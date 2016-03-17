using POSDBAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace POSDBAccess.Controllers
{
    public class TroubleTicketingDetailsController : ApiController
    {
        [HttpGet]
        [Route("api/GetTroubleTicketingDetails")]
        public DataTable getTroubleTicketingDetails()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getTroubleTicketingDetails";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }

        [HttpPost]

        public DataTable saveTroubleTicketingDetails(TroubleTicketingDetails n)
        {
            DataTable Tbl = new DataTable();

            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelTroubleTicketingDetails";
                cmd.Connection = conn;

                conn.Open();

                SqlParameter gs = new SqlParameter();
                gs.ParameterName = "@addInfo";
                gs.SqlDbType = SqlDbType.VarChar;
                gs.Value = n.addInfo;
                cmd.Parameters.Add(gs);

                SqlParameter gss = new SqlParameter();
                gss.ParameterName = "@createdBy";
                gss.SqlDbType = SqlDbType.VarChar;
                gss.Value = n.createdBy;
                cmd.Parameters.Add(gss);

                SqlParameter gsa = new SqlParameter();
                gsa.ParameterName = "@createdOn";
                gsa.SqlDbType = SqlDbType.Int;
                gsa.Value = Convert.ToString(n.createdOn);
                cmd.Parameters.Add(gsa);

                SqlParameter gsaz = new SqlParameter();
                gsaz.ParameterName = "@Id";
                gsaz.SqlDbType = SqlDbType.Int;
                gsaz.Value = Convert.ToString(n.Id);
                cmd.Parameters.Add(gsaz);

                SqlParameter gssa = new SqlParameter();
                gssa.ParameterName = "@raisedBy";
                gssa.SqlDbType = SqlDbType.VarChar;
                gssa.Value = n.raisedBy;
                cmd.Parameters.Add(gssa);

                SqlParameter gsad = new SqlParameter();
                gsad.ParameterName = "@status";
                gsad.SqlDbType = SqlDbType.VarChar;
                gsad.Value = n.status;
                cmd.Parameters.Add(gsad);

                SqlParameter gid = new SqlParameter();
                gid.ParameterName = "@ticketinfo";
                gid.SqlDbType = SqlDbType.VarChar;
                gid.Value = n.ticketinfo;
                cmd.Parameters.Add(gid);

                SqlParameter gsae = new SqlParameter();
                gsae.ParameterName = "@ticketTypeId";
                gsae.SqlDbType = SqlDbType.Int;
                gsae.Value = Convert.ToString(n.ticketTypeId);
                cmd.Parameters.Add(gsae);

                SqlParameter gsac = new SqlParameter();
                gsac.ParameterName = "@TTId";
                gsac.SqlDbType = SqlDbType.Int;
                gsac.Value = Convert.ToString(n.TTId);
                cmd.Parameters.Add(gsac);

                //SqlParameter ga = new SqlParameter();
                //ga.ParameterName = "@Active";
                //ga.SqlDbType = SqlDbType.Int;
                //ga.Value = Convert.ToString(n.Active);
                //cmd.Parameters.Add(ga);

                cmd.ExecuteScalar();
                conn.Close();
                DataSet ds = new DataSet();
                //SqlDataAdapter db = new SqlDataAdapter(cmd);
                //db.Fill(ds);
                //Tbl = ds.Tables[0];
            }
            catch (Exception ex)
            {
                string str = ex.Message;
            }
            // int found = 0;
            return Tbl;

        }
        public void Options()
        {
        }

    }
}
