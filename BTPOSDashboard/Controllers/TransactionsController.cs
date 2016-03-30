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
    public class TransactionsController : ApiController
    {
        [HttpGet]
        public DataTable getTransactions()
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getTransactions";
            cmd.Connection = conn;


            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            // int found = 0;
            return Tbl;
        }
    
             [HttpPost]
          public  DataTable saveTransactions(Transactions b)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
          
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelTransactions";
            cmd.Connection = conn;
            conn.Open();
         

           

            SqlParameter Gim = new SqlParameter();
            Gim.ParameterName = "@Id";
            Gim.SqlDbType = SqlDbType.Int;
            Gim.Value = Convert.ToString(b.Id);
            cmd.Parameters.Add(Gim);

            SqlParameter Gid = new SqlParameter();
            Gid.ParameterName = "@barcode";
            Gid.SqlDbType = SqlDbType.VarChar;
            Gid.Value = b.barcode;
            cmd.Parameters.Add(Gid);

            SqlParameter pid = new SqlParameter();
            pid.ParameterName = "@BTPOSid";
            pid.SqlDbType = SqlDbType.Int;
            pid.Value =Convert.ToInt32(b.BTPOSid);
            cmd.Parameters.Add(pid);

            SqlParameter Gin = new SqlParameter();
            Gin.ParameterName = "@busNumber";
            Gin.SqlDbType = SqlDbType.VarChar;
            Gin.Value = b.busNumber;
            cmd.Parameters.Add(Gin);

            SqlParameter Gil = new SqlParameter();
            Gil.ParameterName = "@busId";
            Gil.SqlDbType = SqlDbType.Int;
            Gil.Value = Convert.ToString(b.busId);
            cmd.Parameters.Add(Gil);


            SqlParameter Gic = new SqlParameter();
            Gic.ParameterName = "@change";
            Gic.SqlDbType = SqlDbType.VarChar;
            Gic.Value = b.change;
            cmd.Parameters.Add(Gic);

            SqlParameter Gik = new SqlParameter();
            Gik.ParameterName = "@company";
            Gik.SqlDbType = SqlDbType.VarChar;
            Gik.Value = b.company;
            cmd.Parameters.Add(Gik);

            SqlParameter Gij = new SqlParameter();
            Gij.ParameterName = "@companyId";
            Gij.SqlDbType = SqlDbType.VarChar;
            Gij.Value = b.companyId;
            cmd.Parameters.Add(Gij);

            SqlParameter Gis = new SqlParameter();
            Gis.ParameterName = "@ConductorId";
            Gis.SqlDbType = SqlDbType.VarChar;
            Gis.Value = b.ConductorId;
            cmd.Parameters.Add(Gis);

            SqlParameter Gii = new SqlParameter();
            Gii.ParameterName = "@ConductorName";
            Gii.SqlDbType = SqlDbType.VarChar;
            Gii.Value = b.ConductorName;
            cmd.Parameters.Add(Gii);


            SqlParameter Gia = new SqlParameter();
            Gia.ParameterName = "@Date";
            Gia.SqlDbType = SqlDbType.DateTime;
            Gia.Value = b.Date;
            cmd.Parameters.Add(Gia);

            SqlParameter Gie = new SqlParameter();
            Gie.ParameterName = "@destination";
            Gie.SqlDbType = SqlDbType.VarChar;
            Gie.Value = b.destination;
            cmd.Parameters.Add(Gie);

            SqlParameter Gif = new SqlParameter();
            Gif.ParameterName = "@fare";
            Gif.SqlDbType = SqlDbType.VarChar;
            Gif.Value = b.fare;
            cmd.Parameters.Add(Gif);

            SqlParameter Gg = new SqlParameter();
            Gg.ParameterName = "@greetingMessage";
            Gg.SqlDbType = SqlDbType.VarChar;
            Gg.Value = b.greetingMessage;
            cmd.Parameters.Add(Gg);
            SqlParameter Gr = new SqlParameter();
            Gr.ParameterName = "@luggageType";
            Gr.SqlDbType = SqlDbType.VarChar;
            Gr.Value = b.luggageType;
            cmd.Parameters.Add(Gr);

            SqlParameter Gra = new SqlParameter();
            Gra.ParameterName = "@passengerId";
            Gra.SqlDbType = SqlDbType.VarChar;
            Gra.Value = b.passengerId;
            cmd.Parameters.Add(Gra);
            SqlParameter Grs = new SqlParameter();
            Grs.ParameterName = "@paymentId";
            Grs.SqlDbType = SqlDbType.VarChar;
            Grs.Value = b.paymentId;
            cmd.Parameters.Add(Grs);

            SqlParameter Grp = new SqlParameter();
            Grp.ParameterName = "@printdataId";
            Grp.SqlDbType = SqlDbType.VarChar;
            Grp.Value = b.printdataId;
            cmd.Parameters.Add(Grp);

            SqlParameter rp = new SqlParameter();
            rp.ParameterName = "@route";
            rp.SqlDbType = SqlDbType.VarChar;
            rp.Value = b.route;
            cmd.Parameters.Add(rp);

            SqlParameter rps = new SqlParameter();
            rps.ParameterName = "@routecode";
            rps.SqlDbType = SqlDbType.VarChar;
            rps.Value = b.routecode;
            cmd.Parameters.Add(rps);

            SqlParameter ps = new SqlParameter();
            ps.ParameterName = "@routeId";
            ps.SqlDbType = SqlDbType.VarChar;
            ps.Value = b.routeId;
            cmd.Parameters.Add(ps);

            SqlParameter ss = new SqlParameter();
            ss.ParameterName = "@source";
            ss.SqlDbType = SqlDbType.VarChar;
            ss.Value = b.source;
            cmd.Parameters.Add(ss);

            SqlParameter ssa = new SqlParameter();
            ssa.ParameterName = "@time";
            ssa.SqlDbType = SqlDbType.DateTime;
            ssa.Value = b.time;
            cmd.Parameters.Add(ssa);
            SqlParameter sas = new SqlParameter();
            sas.ParameterName = "@ticketHolderId";
            sas.SqlDbType = SqlDbType.VarChar;
            sas.Value = b.ticketHolderId;
            cmd.Parameters.Add(sas);
            SqlParameter aas = new SqlParameter();
            aas.ParameterName = "@ticketHolderName";
            aas.SqlDbType = SqlDbType.VarChar;
            aas.Value = b.ticketHolderName;
            cmd.Parameters.Add(aas);
            SqlParameter bas = new SqlParameter();
            bas.ParameterName = "@TicketNumber";
            bas.SqlDbType = SqlDbType.VarChar;
            bas.Value = b.TicketNumber;
            cmd.Parameters.Add(bas);
            SqlParameter nas = new SqlParameter();
            nas.ParameterName = "@ticketValidityPeriod ";
            nas.SqlDbType = SqlDbType.VarChar;
            nas.Value = b.ticketValidityPeriod;
            cmd.Parameters.Add(nas);
            SqlParameter vas = new SqlParameter();
            vas.ParameterName = "@totalamount";
            vas.SqlDbType = SqlDbType.Int;
            vas.Value = Convert.ToInt32(b.totalamount);
            cmd.Parameters.Add(vas);

            SqlParameter das = new SqlParameter();
            das.ParameterName = "@amountpaid";
            das.SqlDbType = SqlDbType.Int;
            das.Value =Convert.ToInt32(b.amountpaid);
            cmd.Parameters.Add(das);
            SqlParameter dd = new SqlParameter();
            dd.ParameterName = "@TransactionCode";
            dd.SqlDbType = SqlDbType.VarChar;
            dd.Value =b.TransactionCode;
            cmd.Parameters.Add(dd);
            SqlParameter aa = new SqlParameter();
            aa.ParameterName = "@TransactionId";
            aa.SqlDbType = SqlDbType.VarChar;
            aa.Value = b.TransactionId;
            cmd.Parameters.Add(aa);
            SqlParameter ca = new SqlParameter();
            ca.ParameterName = "@TransactionId";
            ca.SqlDbType = SqlDbType.VarChar;
            ca.Value = b.TransactionId;
            cmd.Parameters.Add(ca);
            SqlParameter cas = new SqlParameter();
            cas.ParameterName = "@transactionType";
            cas.SqlDbType = SqlDbType.VarChar;
            cas.Value = b.transactionType;
            cmd.Parameters.Add(cas);
            SqlParameter xas = new SqlParameter();
            xas.ParameterName = "@userid";
            xas.SqlDbType = SqlDbType.Int;
            xas.Value = Convert.ToInt32(b.userid);
            cmd.Parameters.Add(xas);
            SqlParameter ras = new SqlParameter();
            ras.ParameterName = "@ChangeRendered";
            ras.SqlDbType = SqlDbType.VarChar;
            ras.Value = b.ChangeRendered;
            cmd.Parameters.Add(ras);    


       
           
          
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
           // Tbl = Tables[0];
            cmd.ExecuteScalar();
            conn.Close();
            // int found = 0;
            return Tbl;
        }
        public void Options() { }

    }
}
