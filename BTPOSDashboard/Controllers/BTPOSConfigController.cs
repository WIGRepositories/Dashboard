using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Text;
using System.IO;
using BTPOSDashboardAPI.Models;


namespace BTPOSDashboard.Controllers
{
    public class BTPOSConfigController : ApiController
    {

        [HttpGet]
        public DataTable GetFleeBTPosRecords(int POSID, int Id)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSRecords";
            cmd.Connection = conn;

            //SqlParameter cid1 = new SqlParameter();
            //cid1.ParameterName = "@Id";
            //cid1.SqlDbType = SqlDbType.Int;
            //cid1.Value = Id;
            //cmd.Parameters.Add(cid1);

            //SqlParameter cid = new SqlParameter();
            //cid.ParameterName = "@POSID";
            //cid.SqlDbType = SqlDbType.Int;
            //cid.Value = POSID;
            //cmd.Parameters.Add(cid);

            //SqlParameter fid1 = new SqlParameter();
            //fid1.ParameterName = "@FileName";
            //fid1.SqlDbType = SqlDbType.VarChar;
            //fid1.Value = FileName;
            //cmd.Parameters.Add(fid1);

            //SqlParameter fid2 = new SqlParameter();
            //fid2.ParameterName = "@Description";
            //fid2.SqlDbType = SqlDbType.VarChar;
            //fid2.Value = Description;
            //cmd.Parameters.Add(fid2);


            //SqlParameter fid3 = new SqlParameter();
            //fid3.ParameterName = "@LastDownloadtime";
            //fid3.SqlDbType = SqlDbType.VarChar;
            //fid3.Value = LastDownloadtime;
            //cmd.Parameters.Add(fid3);


            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            // Tbl = ds.Tables[0];

            //prepare a file
            StringBuilder str = new StringBuilder();
            //  str.Append("Filename,Id,Description,Lastdownloadtime");


            str.Append(string.Format("test\n{0}", POSID.ToString()));

            //  str.Append("Id,filename,Description,LastModifiedtime");

            //  str.Append(string.Format("test\n{1}", FileName.ToString()));


            //    str.Append(string.Format("test\n{2}", Description.ToString()));

            //   str.Append(string.Format("test\n{3}", LastDownloadtime.ToString()));



            for (int i = 0; i < Tbl.Rows.Count; i++)
            {
                // str.Append(Tbl.Rows[i]["POSID"].ToString()+",");

                str.Append(Tbl.Rows[i]["FileName"].ToString() + ",");

                str.Append(Tbl.Rows[i]["Description"].ToString() + ",");

                str.Append(Tbl.Rows[i]["LastDownloadtime"].ToString());

                str.Append(Environment.NewLine);
            }
            String str1 = str.ToString();

            System.IO.StreamWriter file = new System.IO.StreamWriter(@"D:\Welcome.txt");

            file.WriteLine(str.ToString());
            file.Flush();
            file.Close();
            // Show(str1);

            // int found = 0;
            return Tbl;
        }

        [HttpPost]
        public DataTable saveFleetBTPOS(BtposRecords b1)
        {
            DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd1 = new SqlCommand();
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = "InsUpdDelBTPOSRecords";
            cmd1.Connection = conn;


            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@POSID";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = b1.POSID;
            cmd1.Parameters.Add(cid);

            SqlParameter fid1 = new SqlParameter();
            fid1.ParameterName = "@FileName";
            fid1.SqlDbType = SqlDbType.VarChar;
            fid1.Value = b1.FileName;
            cmd1.Parameters.Add(fid1);

            SqlParameter fid2 = new SqlParameter();
            fid2.ParameterName = "@Description";
            fid2.SqlDbType = SqlDbType.VarChar;
            fid2.Value = b1.Description;
            cmd1.Parameters.Add(fid2);


            SqlParameter fid3 = new SqlParameter();
            fid3.ParameterName = "@LastDownloadtime";
            fid3.SqlDbType = SqlDbType.VarChar;
            fid3.Value = b1.LastDownloadtime;
            cmd1.Parameters.Add(fid3);


            SqlDataAdapter db = new SqlDataAdapter(cmd1);
            db.Fill(Tbl);
            return Tbl;
        }

        [HttpGet]
        [Route("api/GetIndexFile")]
        public DataTable GetIndexFile(string posid)
        {
            DataTable indexTbl = new DataTable();

            indexTbl.Columns.Add("IndexFile");
            indexTbl.Columns.Add("IndexFileData");

            DataRow dr = indexTbl.NewRow();
            dr[0] = "IndexFile";
            dr[1] = "RoutesFile\nStopsfile\nroutefare\nauthfile\nblocklist\n";

            indexTbl.Rows.Add(dr);

            return indexTbl;
        }

        [HttpGet]
        [Route("api/GetFileContentRoutes")]
        public DataTable GetFileContentRoute(string filename)
        {
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFileContentRoutes";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0];

            DataTable indexTbl = new DataTable();
            indexTbl = Tbl;

            DataRow dr = indexTbl.NewRow();
            return indexTbl;
        
        }
         [HttpGet]
        [Route("api/GetFileContentStops")]
        public DataTable GetFileContent1(string filename)
        {
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFileContentStops";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0]; 
           
            DataTable indexTbl = new DataTable();
            indexTbl = Tbl;

            DataRow dr = indexTbl.NewRow();
          
        

            switch (filename.ToUpper())
            {
                case "RouteFile":
                    indexTbl.Columns.Add("IndexFile");
                    indexTbl.Columns.Add("IndexFileData");


                    dr[0] = "INDEXFILE";
                    dr[1] = "R1,R2,R3,R4";

                    indexTbl.Rows.Add(dr);
                    break;
                    indexTbl.Columns.Add("IndexFile");
                    indexTbl.Columns.Add("IndexFileData");


                    dr[0] = "IndexFile";
                    dr[1] = "Stop1,Stop2";

                    indexTbl.Rows.Add(dr);
                case "STOPSFILE":
                    break;
                    indexTbl.Columns.Add("IndexFile");
                    indexTbl.Columns.Add("IndexFileData");


                    dr[0] = "IndexFile";
                    dr[1] = "RoutesFile\nStopsfile\nroutefare\nauthfile\nblocklist\n";

                    indexTbl.Rows.Add(dr);
                case "ROUTEFARE":
                    break;

                case "AUTHFILE":
                    indexTbl.Columns.Add("IndexFile");
                    indexTbl.Columns.Add("IndexFileData");


                    dr[0] = "INDEXFILE";
                    dr[1] = "RoutesFile\nStopsfile\nroutefare\nauthfile\nblocklist\n";

                    indexTbl.Rows.Add(dr);
                    break;


            }
          




            return indexTbl;
        }

         [HttpGet]
        [Route("api/GetFileContentRouteFare")]
         public DataTable GetFileContentRouteFare(string filename)
        {
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFileContentRouteFare";
            cmd.Connection = conn;
            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            Tbl = ds.Tables[0]; 
           
            DataTable indexTbl = new DataTable();
            indexTbl = Tbl;

            DataRow dr = indexTbl.NewRow();


            return indexTbl;
        }

         [HttpGet]
         [Route("api/GetFileContentAuthen")]
         public DataTable GetFileContentAuthen(string filename)
         {
             DataTable Tbl = new DataTable();
             //connect to database
             SqlConnection conn = new SqlConnection();
             //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
             conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "GetFileContentAuthentication";
             cmd.Connection = conn;
             DataSet ds = new DataSet();
             SqlDataAdapter db = new SqlDataAdapter(cmd);
             db.Fill(ds);
             Tbl = ds.Tables[0];

             DataTable indexTbl = new DataTable();
             indexTbl = Tbl;

             DataRow dr = indexTbl.NewRow();


             return indexTbl;
         }
         [HttpGet]
         [Route("api/GetFileContentIndex")]
         public DataTable GetFileContentIndex(string filename)
         {
             DataTable Tbl = new DataTable();
             //connect to database
             SqlConnection conn = new SqlConnection();
             //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
             conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "GetFileContentIndex";
             cmd.Connection = conn;
             DataSet ds = new DataSet();
             SqlDataAdapter db = new SqlDataAdapter(cmd);
             db.Fill(ds);
             Tbl = ds.Tables[0];

             DataTable indexTbl = new DataTable();
             indexTbl = Tbl;

             DataRow dr = indexTbl.NewRow();


             return indexTbl;
         }
         [HttpGet]
         [Route("api/GetFileContentBTPOSD")]
         public DataTable GetFileContentBTPOSD(string POSID)
         {
             DataTable Tbl = new DataTable();
             //connect to database
             SqlConnection conn = new SqlConnection();
             //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
             conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
             SqlCommand cmd = new SqlCommand();
             cmd.CommandType = CommandType.StoredProcedure;
             cmd.CommandText = "GetFileContentBTPOSDetails";
             cmd.Connection = conn;
             DataSet ds = new DataSet();
             SqlDataAdapter db = new SqlDataAdapter(cmd);
             db.Fill(ds);
             Tbl = ds.Tables[0];

             DataTable indexTbl = new DataTable();
             indexTbl = Tbl;

             DataRow dr = indexTbl.NewRow();


             return indexTbl;
         }

    }
}
