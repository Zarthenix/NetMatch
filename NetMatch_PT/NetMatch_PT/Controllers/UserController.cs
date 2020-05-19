using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using MySqlX.XDevAPI;
using NetMatch_PT.Containers.Interfaces;
using NetMatch_PT.Models;

namespace NetMatch_PT.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContainer _userContainer;
        SqlConnection con = new SqlConnection();
        SqlCommand com = new SqlCommand();
        SqlDataReader dr;
        string _connectionString = "Server=mssql.fhict.local;Database=dbi407655_netmatch;User Id=dbi407655_netmatch;Password=Netmatch;";
        public UserController(IUserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        public ActionResult Index()
        {
            return View();
        }

        void connectionString()
        {
            con.ConnectionString = "Server=mssql.fhict.local;Database=dbi407655_netmatch;User Id=dbi407655_netmatch;Password=Netmatch;";
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {
            using(SqlConnection sqlconn = new SqlConnection(_connectionString))
            {
                sqlconn.Open();
                string sqlquery = "SELECT Email,Password FROM [dbo].[Users] WHERE Email=@email and Password=@password";
                SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
                sqlcomm.Parameters.AddWithValue("@email", user.Email);
                sqlcomm.Parameters.AddWithValue("@password", user.Password);
                SqlDataReader sdr = sqlcomm.ExecuteReader();
                if (sdr.Read())
                {
                    ViewData["Message"] = "Goed";
                   
                }
                else
                {
                    ViewData["Message"] = "Fout";
                }
                sqlconn.Close();
                return View();

            }
        }

        public ActionResult verify()
        {
            return View();
        }
    }
}



//con.Open();
//com.Connection = con;
//com.CommandText = "SELECT * FROM Users WHERE Email ='"+user.Email+"' and Password= '"+user.Password+"'";
//dr = com.ExecuteReader();

//if (dr.Read())
//{
//    con.Close();
//    return View("Verify");
//}
//else
//{
//    con.Close();
//    return View("Error");
//}
//con.Close();

//User result = _userContainer.Users.FirstOrDefault(u => u.Email == user.Email);

//if (result != null && result.ValidatePassword(user.Password))
//{
//    return RedirectToAction("Index", "Home");
//}
//else
//{
//    return RedirectToAction("Login", "User");
//}