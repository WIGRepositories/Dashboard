using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BTPOSDashboardAPI.Models;

namespace BTPOSDashboardAPI.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        public DataTable GetUsers(int cmpId)//Main Method
        {
            DataTable Tbl = new DataTable();
            //connect to database
            SqlConnection conn = new SqlConnection();            
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();            
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetUsers";
            cmd.Connection = conn;

            SqlParameter cmpid = new SqlParameter("@cmpId", SqlDbType.Int);
            cmpid.Value = cmpId;
            cmd.Parameters.Add(cmpid);

            //SqlParameter empid= new SqlParameter("@EmpNo", SqlDbType.Int);
            //cmpid.Value = empid;
            //cmd.Parameters.Add(empid);
          
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(Tbl);
            
            return Tbl;
        }


        [HttpPost]
        public DataTable SaveUsers(Users U)
        {
            DataTable Tbl = new DataTable();
              SqlConnection conn = new SqlConnection();
            try
            {

                //connect to database
              
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdUsers";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter UId = new SqlParameter("@userid", SqlDbType.Int);
                UId.Value = U.Id;
                cmd.Parameters.Add(UId);

                SqlParameter UFirstName = new SqlParameter("@FirstName",SqlDbType.VarChar,50);
                UFirstName.Value = U.FirstName;
                cmd.Parameters.Add(UFirstName);

                SqlParameter LastName = new SqlParameter("@LastName",SqlDbType.VarChar,50);
                LastName.Value = U.LastName;
                cmd.Parameters.Add(LastName);

                SqlParameter MiddleName = new SqlParameter("@MiddleName",SqlDbType.VarChar,50);
                MiddleName.Value = U.MiddleName;
                cmd.Parameters.Add(MiddleName);

                SqlParameter UUserType = new SqlParameter("@cmpId", SqlDbType.Int);
                UUserType.Value = U.companyId;
                cmd.Parameters.Add(UUserType);

                SqlParameter uEmpNo = new SqlParameter("@EmpNo",SqlDbType.VarChar,15);
                uEmpNo.Value = U.EmpNo;
                cmd.Parameters.Add(uEmpNo);

                SqlParameter UEmail = new SqlParameter("@Email",SqlDbType.VarChar,15);
                UEmail.Value = U.Email;
                cmd.Parameters.Add(UEmail);

                SqlParameter UAdressId = new SqlParameter("@AdressId",SqlDbType.Int);
                UAdressId.Value = U.AdressId;
                cmd.Parameters.Add(UAdressId);

                SqlParameter UMobileNo = new SqlParameter("@MobileNo",SqlDbType.VarChar, 15);
                UMobileNo.Value = U.MobileNo;
                cmd.Parameters.Add(UMobileNo);

                SqlParameter URole1 = new SqlParameter("@RoleId",SqlDbType.Int);
                URole1.Value = U.RoleId;
                cmd.Parameters.Add(URole1);

                SqlParameter UActive = new SqlParameter("@Active",SqlDbType.Int);
                UActive.Value = U.Active;
                cmd.Parameters.Add(UActive);

                SqlParameter UUserName = new SqlParameter("@UserName",SqlDbType.VarChar,15);
                UUserName.Value = U.UserName;
                cmd.Parameters.Add(UUserName);
                
                SqlParameter UPassword = new SqlParameter("@Password",SqlDbType.VarChar,15);
                UPassword.Value = U.Password;
                cmd.Parameters.Add(UPassword);

                SqlParameter MgrId = new SqlParameter("@ManagerId", SqlDbType.Int);
                MgrId.Value = U.mgrId;
                cmd.Parameters.Add(MgrId);

                SqlParameter insupdflag = new SqlParameter("@insupdflag", SqlDbType.VarChar, 10);
                insupdflag.Value = U.insupdflag;
                cmd.Parameters.Add(insupdflag);

                                
                cmd.ExecuteScalar();
                
                conn.Close();
                
            }
            catch (Exception ex)
            {
                conn.Close();
                string str = ex.Message;
            }
            // int found = 0;
            return Tbl;
        }

        [HttpGet]
        [Route("api/Users/GetUserRoles")]
        public DataTable GetUserRoles(int cmpId) {
            DataTable tbl = new DataTable();

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;//Stored Procedure
            cmd.CommandText = "GetUserRoles";
            cmd.Connection = conn;

            SqlParameter UUserType = new SqlParameter("@companyId", SqlDbType.Int);
            UUserType.Value = cmpId;
            cmd.Parameters.Add(UUserType);

            DataSet ds = new DataSet();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(tbl);
            
            return tbl;
        }

        [HttpPost]
        [Route("api/Users/SaveUserRoles")]
        public DataTable SaveUserRoles(userroles U)
        {
            DataTable Tbl = new DataTable();
            SqlConnection conn = new SqlConnection();
            try
            {
                //connetionString="Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password"
                conn.ConnectionString = System.Configuration.ConfigurationManager.ConnectionStrings["btposdb"].ToString();
                //conn.ConnectionString = "Data Source=localhost;Initial Catalog=MyAlerts;integrated security=sspi;";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "InsUpdDelUserRoles";
                cmd.Connection = conn;
                conn.Open();


                SqlParameter UId = new SqlParameter("@Id", SqlDbType.Int);
                UId.Value = U.Id;
                cmd.Parameters.Add(UId);              
               
                SqlParameter URole = new SqlParameter("@UserId", SqlDbType.Int);
                URole.Value = U.UserId;
                cmd.Parameters.Add(URole);

                SqlParameter UUser = new SqlParameter("@roleid", SqlDbType.Int);
                UUser.Value = U.RoleId;
                cmd.Parameters.Add(UUser);

                SqlParameter UCmp = new SqlParameter("@CompanyId", SqlDbType.Int);
                UCmp.Value = U.CompanyId;
                cmd.Parameters.Add(UCmp);

                cmd.ExecuteScalar();

                conn.Close();

            }
            catch (Exception ex)
            {
                conn.Close();
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
