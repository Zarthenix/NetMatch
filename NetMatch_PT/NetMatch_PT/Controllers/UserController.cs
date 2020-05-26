using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MySqlX.XDevAPI;
using NetMatch_PT.Containers.Interfaces;
using NetMatch_PT.Contexts.IContext;
using NetMatch_PT.Models;
using RestSharp;

namespace NetMatch_PT.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContainer _userContainer;
      
        string _connectionString = "Server=mssql.fhict.local;Database=dbi407655_netmatch;User Id=dbi407655_netmatch;Password=Netmatch;";
        public UserController(IUserContainer userContainer)
        {
            _userContainer = userContainer;
           
        }

        public ActionResult Index()
        {
            return View();
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
                    var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, user.Email)
                        };

                    var identity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var props = new AuthenticationProperties();
                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewData["Message"] = "Fout";
                }
                sqlconn.Close();
                return View();

            }
        }
    }
}