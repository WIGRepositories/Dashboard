﻿using BTPOSDashboardAPI.Models;
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
    public class FleetRoutesDetailsController : ApiController
    {
        [HttpGet]
        public DataSet getroutedetails(int routeid)
        {
            // DataTable Tbl = new DataTable();


            //connect to database
            SqlConnection conn = new SqlConnection();
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "getRouteDetails";
            cmd.Connection = conn;

            SqlParameter cid = new SqlParameter();
            cid.ParameterName = "@routeid";
            cid.SqlDbType = SqlDbType.Int;
            cid.Value = routeid;
            cmd.Parameters.Add(cid);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(ds);
            // Tbl = ds.Tables[0];

            // int found = 0;
            return ds;
        }



        [HttpPost]
        public HttpResponseMessage saveroutedetails(IEnumerable<RouteDetails> routestops)
        {
            SqlConnection conn = new SqlConnection();
            try
            {


            //connect to database
            
            //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsUpdDelRouteDetails";
            cmd.Connection = conn;
            conn.Open();

            foreach (RouteDetails s in routestops)
            {

                SqlParameter ba = new SqlParameter("@RouteId", SqlDbType.Int);
                ba.Value = s.RouteId;
                cmd.Parameters.Add(ba);

                SqlParameter bb = new SqlParameter("@StopId", SqlDbType.Int);
                bb.Value = s.stopId;
                cmd.Parameters.Add(bb);

                SqlParameter bd = new SqlParameter("@DistanceFromSource", SqlDbType.VarChar, 20);
                bd.Value = s.DistanceFromSource;
                cmd.Parameters.Add(bd);


                SqlParameter bf = new SqlParameter("@DistanceFromDestination", SqlDbType.VarChar, 20);
                bf.Value = s.DistanceFromDestination;
                cmd.Parameters.Add(bf);

                SqlParameter bh = new SqlParameter("@DistanceFromPreviousStop", SqlDbType.Int);
                bh.Value = s.DistanceFromPreviousStop;
                cmd.Parameters.Add(bh);

                SqlParameter ipconfig = new SqlParameter("@DistanceFromNextStop", SqlDbType.VarChar, 20);
                ipconfig.Value = s.DistanceFromNextStop;
                cmd.Parameters.Add(ipconfig);


                SqlParameter active = new SqlParameter("@PreviousStopId", SqlDbType.Int);
                active.Value = s.PreviousStopId;
                cmd.Parameters.Add(active);

                SqlParameter fo = new SqlParameter("@NextStopId", SqlDbType.Int);
                fo.Value = s.NextStopId;
                cmd.Parameters.Add(fo);

                SqlParameter sn = new SqlParameter("@StopNo", SqlDbType.Int);
                sn.Value = s.StopNo;
                cmd.Parameters.Add(sn);

                SqlParameter insupdflag = new SqlParameter("@insupddelflag", SqlDbType.VarChar, 10);
                insupdflag.Value = s.insupddelflag;
                cmd.Parameters.Add(insupdflag);

                cmd.ExecuteScalar();

                cmd.Parameters.Clear();

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
        public void Options() { }

    }
}
