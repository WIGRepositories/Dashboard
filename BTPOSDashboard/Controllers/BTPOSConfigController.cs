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
            DataTable dt = GetFileContentFormDB("INDEXFILE",null);

            DataTable indexTbl = new DataTable();
            indexTbl.Columns.Add("IndexFile");          
            DataRow dr = indexTbl.NewRow();

            StringBuilder strBldr = new StringBuilder();
            strBldr.Append("~");
            foreach (DataRow dr1 in dt.Rows)
            {
                strBldr.AppendLine(dr1[0].ToString());
            }           
            strBldr.Append("~");
            dr[0] = strBldr.ToString();
            indexTbl.Rows.Add(dr);

            return indexTbl;
        }
                
        [HttpGet]
        [Route("api/GetFileContent")]
        public DataTable GetFileContent(string filename, string BTPOSId)
        {
            DataTable dt = new DataTable();
            DataTable indexTbl = new DataTable();
            DataRow dr = indexTbl.NewRow();
            StringBuilder strBldr = new StringBuilder();

            switch (filename.ToUpper())
            {
                case "MENUFILE":

                     dt = GetFileContentFormDB("MENUFILE", BTPOSId);

                    indexTbl.Columns.Add(filename);
                    //strBldr.AppendLine("menuitem<id,pid,active>");
                    strBldr.Append("~");
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        strBldr.AppendLine(string.Format("{0}<{1},{2},{3}>",dr1[0].ToString(),dr1[1].ToString(),dr1[2].ToString(),dr1[3].ToString()));
                    } 
                   
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);
                    break;
                case "ROUTESFILE":

                     dt = GetFileContentFormDB("ROUTESFILE", BTPOSId);
                    
                    indexTbl.Columns.Add(filename);
                    //strBldr.AppendLine("Route1<s.no,id,active>");
                    strBldr.Append("~");

                    foreach (DataRow dr1 in dt.Rows)
                    {
                        strBldr.AppendLine(string.Format("{0}<{1},{2}>", dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString()));
                    } 
                 
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);
                    break;

                case "STOPSFILE":

                    dt = GetFileContentFormDB("STOPSFILE", BTPOSId);

                    indexTbl.Columns.Add(filename);
                    //strBldr.AppendLine("Stage 01<id,routeid,active>");
                    //Route1
                    strBldr.Append("~");
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        strBldr.AppendLine(string.Format("{0}<{1},{2},{3}>", dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString(), dr1[3].ToString()));
                    }                    
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);

                    break;

                case "ROUTEFARE":

                    dt = GetFileContentFormDB("ROUTEFARE", BTPOSId);

                    indexTbl.Columns.Add(filename);

                    //strBldr.AppendLine("Route|Src|tgt<fare>");
                    //Route1
                    strBldr.Append("~");
                    
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        strBldr.AppendLine(string.Format("{0}|{1}|{2}<{3}>", dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString(), dr1[3].ToString()));
                    } 

                    
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);

                    break;

                case "AUTHFILE":

                    dt = GetFileContentFormDB("AUTHFILE", BTPOSId);

                    indexTbl.Columns.Add(filename);
                    strBldr.Append("~");

                    //strBldr.AppendLine("userid<password,userid,active>");

                    foreach (DataRow dr1 in dt.Rows)
                    {
                        strBldr.AppendLine(string.Format("{0}<{1},{2}<{3}>", dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString(), dr1[3].ToString()));
                    } 
                   
                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);

                    break;

                case "CURRENCYFILE":

                   // dt = GetFileContentFormDB("CURRENCYFILE", BTPOSId);

                    indexTbl.Columns.Add(filename);
                    strBldr.Append("~");
                    strBldr.AppendLine("USD<0.2>");
                    strBldr.AppendLine("FRA<0.5>");
                    strBldr.AppendLine("PND<0.3>");
                    strBldr.AppendLine("EUR<0.4>");

                    //strBldr.AppendLine("userid<password,userid,active>");

                    //foreach (DataRow dr1 in dt.Rows)
                    //{
                    //    strBldr.AppendLine(string.Format("{0}<{1},{2}<{3}>", dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString(), dr1[3].ToString()));
                    //}

                    strBldr.Append("~");
                    dr[0] = strBldr.ToString();
                    indexTbl.Rows.Add(dr);

                    break;

            }
            return indexTbl;
        }

        public DataTable GetFileContentFormDB(string filename, string BTPOSId)
        {
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFileContent";
            cmd.Connection = conn;

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@btposid";
            cid.SqlDbType = SqlDbType.VarChar;
            cid.Value = BTPOSId;
            cmd.Parameters.Add(cid);

            SqlParameter fid1 = new SqlParameter();
            fid1.ParameterName = "@filename";
            fid1.SqlDbType = SqlDbType.VarChar;
            fid1.Value = filename;
            cmd.Parameters.Add(fid1);
            
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            return Tbl;
        }


        [HttpGet]
        [Route("api/GetFare")]
        public DataTable GetFare(string BTPOSId, int routeid, int srcId, int destId,int pssgnr, int childs, int luggage)
        {
           // DataTable dt = GetFileContentFormDB("INDEXFILE", null);

            DataTable indexTbl = new DataTable();
            indexTbl.Columns.Add("GetFare");
            DataRow dr = indexTbl.NewRow();

            StringBuilder strBldr = new StringBuilder();
            strBldr.Append("~");
            strBldr.AppendLine("0.12");
            //foreach (DataRow dr1 in dt.Rows)
            //{
            //    strBldr.AppendLine(dr1[0].ToString());
            //}
            strBldr.Append("~");
            dr[0] = strBldr.ToString();
            indexTbl.Rows.Add(dr);

            return indexTbl;
        }

        [HttpGet]
        [Route("api/ResetPassword")]
        public DataTable ResetPassword(string BTPOSId, string userid, string oldPwd, string newPwd)
        {
            DataTable indexTbl = new DataTable();
            indexTbl.Columns.Add("Status");
            indexTbl.Columns.Add("Details");
            DataRow dr = indexTbl.NewRow();
            dr[0] = (oldPwd == "1111" || oldPwd == "2222") ? 1 : 0;
            dr[1] = (oldPwd == "1111" || oldPwd == "2222") ? "Changed successfully" : "invalid userid";
            indexTbl.Rows.Add(dr);

            return indexTbl;
        }

        [HttpGet]
        [Route("api/SaveTrans")]
        public DataTable SaveTrans(string BTPOSId, int transTypeId, decimal amt, string gatewayId, string datetime, string srcId, string destId)
        {
            DataTable indexTbl = new DataTable();
            indexTbl.Columns.Add("Status");
            
            DataRow dr = indexTbl.NewRow();
            dr[0] =  1;
            
            indexTbl.Rows.Add(dr);

            return indexTbl;
        }
    }
}
