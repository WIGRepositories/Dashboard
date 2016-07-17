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
        [Route("api/GetBTPOSId")]
        public DataTable GetBTPOSId(string imeiNo, string foCode)
        {

            DataTable Tbl = new DataTable();

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSId";
            cmd.Connection = conn;

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@imei";
            cid.SqlDbType = SqlDbType.VarChar;
            cid.Value = imeiNo;
            cmd.Parameters.Add(cid);

            SqlParameter fid1 = new SqlParameter();
            fid1.ParameterName = "@fleetownerCode";
            fid1.SqlDbType = SqlDbType.VarChar;
            fid1.Value = foCode;
            cmd.Parameters.Add(fid1);

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            return Tbl;
        }

        [HttpGet]
        [Route("api/GetIndexFile")]
        public DataTable GetIndexFile()
        {
            DataTable indexTbl = new DataTable();
            indexTbl.Columns.Add("IndexFile");          
            DataRow dr = indexTbl.NewRow();

            StringBuilder strBldr = new StringBuilder();
            strBldr.Append("~");
            strBldr.AppendLine("ROUTESFILE");
            strBldr.AppendLine("STOPSFILE");
            strBldr.AppendLine("ROUTEFARE");
            strBldr.AppendLine("AUTHFILE");
            strBldr.Append("~");
            dr[0] = strBldr.ToString();
            indexTbl.Rows.Add(dr);

            return indexTbl;
        }
                
        [HttpGet]
        [Route("api/GetFileContent")]
        public DataTable GetFileContent(string filename, string BTPOSId)
        {
            //DataTable Tbl = new DataTable();
            ////connect to database
            //SqlConnection conn = new SqlConnection();
            ////connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            //conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.CommandText = "GetFileContentStops";
            //cmd.Connection = conn;
            //DataSet ds = new DataSet();
            //SqlDataAdapter db = new SqlDataAdapter(cmd);
            //db.Fill(ds);
            //Tbl = ds.Tables[0]; 
           
            DataTable indexTbl = new DataTable();
            DataRow dr = indexTbl.NewRow();
            StringBuilder strBldr = new StringBuilder();

            switch (filename.ToUpper())
            {
                case "MENUFILE":
                    indexTbl.Columns.Add(filename);
                    //strBldr.AppendLine("Route1<s.no,id,active>");
                    strBldr.Append("~");
                    strBldr.AppendLine("Ticketing<1,0,1>");
                    strBldr.AppendLine("Validate ticket<2,0,1>");
                    strBldr.AppendLine("Set Route<3,0,1>");
                    strBldr.AppendLine("Server comm<4,0,1>");
                    strBldr.AppendLine("Print trans<5,0,1>");
                    strBldr.AppendLine("POS Config<6,0,1>");
                    strBldr.AppendLine("Misc Expense<7,1,1>");
                    strBldr.AppendLine("Payment Options<8,1,1>");
                    strBldr.AppendLine("Cash<9,8,1>");
                    strBldr.AppendLine("Card<10,8,1>");
                    strBldr.AppendLine("Mobile Money<11,8,1>");
                    strBldr.AppendLine("Ping Server<12,4,1>");
                    strBldr.AppendLine("Download files<13,4,1>");
                    strBldr.AppendLine("Reset Password<14,6,1>");
                    strBldr.AppendLine("Show Co-ords<15,6,1>");
                    strBldr.AppendLine("Renewal Frequency<16,6,1>");
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);
                    break;
                case "ROUTESFILE":
                    indexTbl.Columns.Add(filename);
                    //strBldr.AppendLine("Route1<s.no,id,active>");
                    strBldr.Append("~");
                    strBldr.AppendLine("Route1<1,1,1>");
                    strBldr.AppendLine("Route2<2,2,1>");
                    strBldr.AppendLine("Route3<3,3,1>");
                    strBldr.AppendLine("Route4<4,4,1>");
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);
                    break;

                case "STOPSFILE":

                    indexTbl.Columns.Add(filename);
                    //strBldr.AppendLine("Stage 01<id,routeid,active>");
                    //Route1
                    strBldr.Append("~");
                    strBldr.AppendLine("Stage 01<1,1,1>");
                    strBldr.AppendLine("Stage 02<2,1,1>");
                    strBldr.AppendLine("Stage 03<3,1,1>");
                    strBldr.AppendLine("Stage 04<4,1,1>");
                    strBldr.AppendLine("Stage 05<5,1,1>");

                    //Route2
                    strBldr.AppendLine("Stage 05<5,2,1>");
                    strBldr.AppendLine("Stage 04<4,2,1>");
                    strBldr.AppendLine("Stage 03<3,2,1>");
                    strBldr.AppendLine("Stage 02<2,2,1>");
                    strBldr.AppendLine("Stage 01<1,2,1>");

                    //Route3
                    strBldr.AppendLine("Stage 06<6,3,1>");
                    strBldr.AppendLine("Stage 07<7,3,1>");
                    strBldr.AppendLine("Stage 08<8,3,1>");
                    strBldr.AppendLine("Stage 09<9,3,1>");
                    strBldr.AppendLine("Stage 10<10,3,1>");

                    //Route4
                    strBldr.AppendLine("Stage 10<10,4,1>");
                    strBldr.AppendLine("Stage 09<9,4,1>");
                    strBldr.AppendLine("Stage 08<8,4,1>");
                    strBldr.AppendLine("Stage 07<7,4,1>");
                    strBldr.AppendLine("Stage 06<6,4,1>");
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);

                    break;

                case "ROUTEFARE":

                    indexTbl.Columns.Add(filename);

                    //strBldr.AppendLine("Route|Src|tgt<fare>");
                    //Route1
                    strBldr.Append("~");
                    strBldr.AppendLine("Route1|Stage 01|Stage 02<0.15>");
                    strBldr.AppendLine("Route1|Stage 01|Stage 03<0.25>");
                    strBldr.AppendLine("Route1|Stage 01|Stage 04<0.35>");
                    strBldr.AppendLine("Route1|Stage 01|Stage 05<0.45>");

                    strBldr.AppendLine("Route1|Stage 02|Stage 03<0.10>");
                    strBldr.AppendLine("Route1|Stage 02|Stage 04<0.15>");
                    strBldr.AppendLine("Route1|Stage 02|Stage 05<0.20>");

                    strBldr.AppendLine("Route1|Stage 03|Stage 04<0.10>");
                    strBldr.AppendLine("Route1|Stage 03|Stage 05<0.15>");

                    strBldr.AppendLine("Route1|Stage 04|Stage 05<0.20>");

                    //Route2
                    strBldr.AppendLine("Route2|Stage 05|Stage 04<0.15>");
                    strBldr.AppendLine("Route2|Stage 05|Stage 03<0.25>");
                    strBldr.AppendLine("Route2|Stage 05|Stage 02<0.35>");
                    strBldr.AppendLine("Route2|Stage 05|Stage 01<0.45>");

                    strBldr.AppendLine("Route2|Stage 04|Stage 03<0.10>");
                    strBldr.AppendLine("Route2|Stage 04|Stage 02<0.15>");
                    strBldr.AppendLine("Route2|Stage 04|Stage 01<0.20>");

                    strBldr.AppendLine("Route2|Stage 03|Stage 02<0.10>");
                    strBldr.AppendLine("Route2|Stage 03|Stage 01<0.15>");

                    strBldr.AppendLine("Route2|Stage 02|Stage 01<0.20>");


                    //Route1
                    strBldr.AppendLine("Route3|Stage 06|Stage 07<0.15>");
                    strBldr.AppendLine("Route3|Stage 06|Stage 08<0.25>");
                    strBldr.AppendLine("Route3|Stage 06|Stage 09<0.35>");
                    strBldr.AppendLine("Route3|Stage 06|Stage 10<0.45>");

                    strBldr.AppendLine("Route3|Stage 07|Stage 08<0.10>");
                    strBldr.AppendLine("Route3|Stage 07|Stage 09<0.15>");
                    strBldr.AppendLine("Route3|Stage 07|Stage 10<0.20>");

                    strBldr.AppendLine("Route3|Stage 08|Stage 09<0.10>");
                    strBldr.AppendLine("Route3|Stage 08|Stage 10<0.15>");

                    strBldr.AppendLine("Route3|Stage 09|Stage 10<0.20>");


                    //Route1
                    strBldr.AppendLine("Route4|Stage 10|Stage 09<0.15>");
                    strBldr.AppendLine("Route4|Stage 10|Stage 08<0.25>");
                    strBldr.AppendLine("Route4|Stage 10|Stage 07<0.35>");
                    strBldr.AppendLine("Route4|Stage 10|Stage 06<0.45>");

                    strBldr.AppendLine("Route4|Stage 09|Stage 08<0.10>");
                    strBldr.AppendLine("Route4|Stage 09|Stage 07<0.15>");
                    strBldr.AppendLine("Route4|Stage 09|Stage 06<0.20>");

                    strBldr.AppendLine("Route4|Stage 08|Stage 07<0.10>");
                    strBldr.AppendLine("Route4|Stage 08|Stage 06<0.15>");

                    strBldr.AppendLine("Route4|Stage 07|Stage 06<0.20>");
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);

                    break;

                case "AUTHFILE":

                    indexTbl.Columns.Add(filename);
                    strBldr.Append("~");
                    //strBldr.AppendLine("userid<password,userid,active>");
                    strBldr.AppendLine("user1<1111,4,1>");
                    strBldr.AppendLine("user2<2222,5,1>");
                    strBldr.AppendLine("user3<3333,6,1>");
                    strBldr.AppendLine("user4<4444,7,1>");
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);

                    break;

            }
            return indexTbl;
        }

    }
}
