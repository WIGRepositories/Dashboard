using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboard.Controllers
{
    public class faqsController : ApiController
    {
       
        public DataTable Getlist()
        {
            DataTable dt = new DataTable();

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=localhost;initial catalog= POSDashboard;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "getfaqs";
            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            return dt;
        }
        [HttpGet]
        public int SavefaqsDetails(string flag
            , int id, int question, string answer, string createdon, string createdby,string updatedon,string updatedby,int active,int category )
        {
            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=localhost;initial catalog= POSDashboard;integrated security=sspi;";

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "InsUpdDelfaqs";
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = flag;
            cmd.Parameters.Add(f);

            SqlParameter p = new SqlParameter("@Id", SqlDbType.Int);
            p.Value = id;
            cmd.Parameters.Add(p);

            SqlParameter q = new SqlParameter("@question", SqlDbType.VarChar,250);
            q.Value = question;
            cmd.Parameters.Add(q);

            SqlParameter a = new SqlParameter("@answer", SqlDbType.VarChar, 1000);
            a.Value = answer;
            cmd.Parameters.Add(a);

            SqlParameter c = new SqlParameter("@createdon", SqlDbType.VarChar);
            c.Value = createdon;
            cmd.Parameters.Add(c);

            SqlParameter b = new SqlParameter("@createdby", SqlDbType.VarChar);
            b.Value = createdby;
            cmd.Parameters.Add(b);

            SqlParameter fi = new SqlParameter("@updatedon", SqlDbType.VarChar);
            fi.Value = updatedon;
            cmd.Parameters.Add(fi);

            SqlParameter h = new SqlParameter("@updatedby", SqlDbType.VarChar);
            h.Value = updatedby;
            cmd.Parameters.Add(h);


            SqlParameter g = new SqlParameter("@active", SqlDbType.Int);
            g.Value = active;
            cmd.Parameters.Add(g);

            SqlParameter gi = new SqlParameter("@category", SqlDbType.Int);
            gi.Value = category;
            cmd.Parameters.Add(gi);

          
           





            conn.Open();

            int status = cmd.ExecuteNonQuery();

            conn.Close();
            return status;
        }



        [HttpPost]

        [Route("api/faqs/SavefaqsdetailsUsingpost")]
        public int SavefaqsdetailsUsingpost(faqs fi)
        {

            SqlConnection conn = new SqlConnection();

            conn.ConnectionString = "Data Source=localhost;Initial Catalog=POSDashboard;integrated security=sspi;";



            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            cmd.CommandText = "InsUpdDelfaqs";
            cmd.CommandType = CommandType.StoredProcedure;


            SqlParameter f = new SqlParameter("@flag", SqlDbType.VarChar);
            f.Value = fi.flag;
            cmd.Parameters.Add(f);

            SqlParameter id = new SqlParameter("@Id", SqlDbType.Int);
            id.Value = fi.id;
            cmd.Parameters.Add(id);

            SqlParameter q = new SqlParameter("@question", SqlDbType.VarChar,250);
            q.Value = fi.question;
            cmd.Parameters.Add(q);

            SqlParameter i = new SqlParameter("@answer", SqlDbType.VarChar, 1000);
            i.Value = fi.answer;
            cmd.Parameters.Add(i);

            SqlParameter w = new SqlParameter("@createdon", SqlDbType.DateTime);
            w.Value = fi.createdon;
            cmd.Parameters.Add(w);

            SqlParameter wi = new SqlParameter("@createdby", SqlDbType.VarChar, 50);
            wi.Value = fi.createdby;
            cmd.Parameters.Add(wi);

            SqlParameter u = new SqlParameter("@updatedon", SqlDbType.DateTime);
            u.Value = fi.updatedon;
            cmd.Parameters.Add(u);

            SqlParameter ui = new SqlParameter("@updatedby", SqlDbType.VarChar, 50);
            ui.Value = fi.updatedby;
            cmd.Parameters.Add(ui);

            SqlParameter a = new SqlParameter("@active", SqlDbType.Int);
            a.Value = fi.active;
            cmd.Parameters.Add(a);

            SqlParameter c = new SqlParameter("@category", SqlDbType.Int);
            c.Value = fi.category;
            cmd.Parameters.Add(c);


            conn.Open();

            int status = cmd.ExecuteNonQuery();




            conn.Close();

            return status;
        }
    }
}
         
