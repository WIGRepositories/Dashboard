using BTPOSDashboardAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BTPOSDashboardAPI.Controllers
{
    public class BTPOSDetailsController : ApiController
    {
        [HttpGet]
   
        public DataTable BTPOSDetails()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getBTPOSDetails";
            cmd.Connection = conn;
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

        [HttpPost]

        public DataTable SaveBTPOSDetails(IEnumerable<BTPOSDetails> posList)
        {
            DataTable Tbl = new DataTable();

           // BTPOSDetails n = new BTPOSDetails();
            try
            {
                //connect to database
                SqlConnection conn = new SqlConnection();
                // connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelBTPOSDetails";
                cmd.Connection = conn;

                conn.Open();

                foreach (BTPOSDetails n in posList)
                {
                    SqlParameter ba = new SqlParameter("@Id", SqlDbType.Int);
                    ba.Value = n.Id;
                    cmd.Parameters.Add(ba);

                    SqlParameter bb = new SqlParameter("@GroupId", SqlDbType.Int);
                    bb.Value = n.GroupId;
                    cmd.Parameters.Add(bb);

                    SqlParameter bd = new SqlParameter("@IMEI", SqlDbType.VarChar, 20);
                    bd.Value = n.IMEI;
                    cmd.Parameters.Add(bd);


                    SqlParameter bf = new SqlParameter("@POSID", SqlDbType.VarChar, 20);
                    bf.Value = (n.insupdflag == "I") ? "POS" + Guid.NewGuid().ToString().Replace("-", "") : n.POSID;
                    cmd.Parameters.Add(bf);

                    SqlParameter bh = new SqlParameter("@StatusId", SqlDbType.Int);
                    bh.Value = n.StatusId;
                    cmd.Parameters.Add(bh);

                    SqlParameter ipconfig = new SqlParameter("@ipconfig", SqlDbType.VarChar, 20);
                    ipconfig.Value = n.ipconfig;
                    cmd.Parameters.Add(ipconfig);


                    SqlParameter active = new SqlParameter("@active", SqlDbType.Int);
                    active.Value = 1;
                    cmd.Parameters.Add(active);

                    SqlParameter fo = new SqlParameter("@fleetownerid", SqlDbType.Int);
                    fo.Value = n.fleetownerid;
                    cmd.Parameters.Add(fo);

                    SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                    insupdflag.Value = n.insupdflag;
                    cmd.Parameters.Add(insupdflag);

                    cmd.ExecuteScalar();
                }
                conn.Close();
              
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
