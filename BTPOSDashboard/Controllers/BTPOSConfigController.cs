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
using System.Web.Http.Tracing;


namespace BTPOSDashboard.Controllers
{
    public class BTPOSConfigController : ApiController
    {       

        [HttpGet]
        public DataTable GetBTPosDetails(int POSID, int Id)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "GetBTPOSConfig....");
 

            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetBTPOSRecords";
            cmd.Connection = conn;
            
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            // Tbl = ds.Tables[0];

            //prepare a file
            StringBuilder str = new StringBuilder();
            //  str.Append("Filename,Id,Description,Lastdownloadtime");


            str.Append(string.Format("test\n{0}", POSID.ToString()));

         
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

            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "Validate Credentials completed.");
            
            // Show(str1);

            // int found = 0;
            return Tbl;
        }

        [HttpPost]
        public DataTable saveFleetBTPOS(BtposRecords b1)
        {
            DataTable Tbl = new DataTable();

            LogTraceWriter traceWriter = new LogTraceWriter();
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFleetBTPOS....");
 
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
            traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "saveFleetBTPOS Credentials completed.");
            
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
                strBldr.Append(dr1[0].ToString()+",");
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
                   int rCount = 0;
                    foreach (DataRow dr1 in dt.Rows)
                    {
                        strBldr.AppendLine(string.Format("{0}<{1},{2},{3}>", dr1[0].ToString(), ++rCount, dr1[1].ToString(), dr1[2].ToString()));
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
                        strBldr.AppendLine(string.Format("{0}<{1},{2},{3}>", dr1[0].ToString(), dr1[1].ToString(), dr1[2].ToString(), dr1[3].ToString()));
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
            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetFare";
            cmd.Connection = conn;

        
            cmd.Parameters.Add("@srcId", SqlDbType.Int).Value = srcId;            
            cmd.Parameters.Add("@destId", SqlDbType.Int).Value = destId;
            cmd.Parameters.Add("@routeid", SqlDbType.Int).Value = routeid;
            cmd.Parameters.Add("@btposid", SqlDbType.VarChar).Value = BTPOSId;

            DataTable Tbl = new DataTable();

            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);


            DataTable indexTbl = new DataTable();

            indexTbl.Columns.Add("GetFare");
            DataRow dr = indexTbl.NewRow();

            StringBuilder strBldr = new StringBuilder();
            strBldr.Append("~");
            
            strBldr.AppendLine((Tbl.Rows.Count >0) ? Tbl.Rows[0][0].ToString(): "0.00") ;
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

            try
            {
                SqlConnection conn = new SqlConnection();
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd1 = new SqlCommand();
                cmd1.CommandType = CommandType.StoredProcedure;
                cmd1.CommandText = "InsUpdDelBTPOSTrans";
                cmd1.Connection = conn;

                SqlParameter cid = new SqlParameter();
                cid.ParameterName = "@BTPOSId";
                cid.SqlDbType = SqlDbType.VarChar;
                cid.Value = BTPOSId;
                cmd1.Parameters.Add(cid);

                //cash
                //SqlParameter fid1 = new SqlParameter();
                //fid1.ParameterName = "@PaymentTypeId";
                //fid1.SqlDbType = SqlDbType.Int;
                //fid1.Value = 25;
                //cmd1.Parameters.Add(fid1);

                SqlParameter fid11 = new SqlParameter();
                fid11.ParameterName = "@PaymentTypeId";
                fid11.SqlDbType = SqlDbType.Int;
                fid11.Value = 25;
                cmd1.Parameters.Add(fid11);

                //success
                SqlParameter fid12 = new SqlParameter();
                fid12.ParameterName = "@TransStatusId";
                fid12.SqlDbType = SqlDbType.Int;
                fid12.Value = 30;
                cmd1.Parameters.Add(fid12);

                SqlParameter fi = new SqlParameter();
                fi.ParameterName = "@AmountPaid";
                fi.SqlDbType = SqlDbType.Decimal;
                fi.Value = amt;
                cmd1.Parameters.Add(fi);

                SqlParameter f = new SqlParameter();
                f.ParameterName = "@date";
                f.SqlDbType = SqlDbType.VarChar;
                f.Value = DateTime.Now;
                cmd1.Parameters.Add(f);

                SqlParameter f1 = new SqlParameter();
                f1.ParameterName = "@GatewayTransId";
                f1.SqlDbType = SqlDbType.VarChar;
                f1.Value = gatewayId;
                cmd1.Parameters.Add(f1);

                SqlParameter ff = new SqlParameter();
                ff.ParameterName = "@srcId";
                ff.SqlDbType = SqlDbType.VarChar;
                ff.Value = srcId;
                cmd1.Parameters.Add(ff);

                SqlParameter fid2 = new SqlParameter();
                fid2.ParameterName = "@destId";
                fid2.SqlDbType = SqlDbType.VarChar;
                fid2.Value = destId;
                cmd1.Parameters.Add(fid2);

                SqlParameter flag = new SqlParameter();
                flag.ParameterName = "@insupdflag";
                flag.SqlDbType = SqlDbType.VarChar;
                flag.Value = "I";
                //llid.Value = b.Active;
                cmd1.Parameters.Add(flag);

                SqlParameter tid = new SqlParameter();
                tid.ParameterName = "@posTransId";
                tid.SqlDbType = SqlDbType.Int;
                tid.Direction = ParameterDirection.Output;
                cmd1.Parameters.Add(tid);



                //insert into db
                conn.Open();
                object btposTransId = cmd1.ExecuteScalar();
                conn.Close();

                DataRow dr = indexTbl.NewRow();
                dr[0] = 1;
                //if (Convert.IsDBNull(btposTransId))
                //{
                //    //make paypal payment
                //    //update the paypal payment id back
                //    dr[0] = 0;

                //}
                //else
                //{
                //    if(Convert.ToInt32(btposTransId) > 0)
                //        dr[0] = 1;
                //}

                indexTbl.Rows.Add(dr);

                return indexTbl;
            }
            catch{
                  DataRow dr = indexTbl.NewRow();
                dr[0] = 0;
                    indexTbl.Rows.Add(dr);

                return indexTbl;
            }
        }

        [HttpGet]
        [Route("api/RegisterBTPOS")]
        public DataTable RegisterBTPOS(string posSN)
        {

            DataTable Tbl = new DataTable();
            LogTraceWriter traceWriter = new LogTraceWriter();
            //connect to database
            SqlConnection conn = new SqlConnection();
            try
            {
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "RegisterBTPOS....");

                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "RegisterBTPOS";
                cmd.Connection = conn;

                SqlParameter cid = new SqlParameter();
                cid.ParameterName = "@posSN";
                cid.SqlDbType = SqlDbType.VarChar;
                cid.Value = posSN;
                cmd.Parameters.Add(cid);

                SqlDataAdapter db = new SqlDataAdapter(cmd);
                db.Fill(Tbl);
                traceWriter.Trace(Request, "0", TraceLevel.Info, "{0}", "End RegisterBTPOS....");
                return Tbl;
            }
            catch (Exception ex) {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                string str = ex.Message;
                traceWriter.Trace(Request, "1", TraceLevel.Info, "{0}", "Error in RegisterBTPOS:" + ex.Message);
                //return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                return Tbl;
            }
        }
    }
}
