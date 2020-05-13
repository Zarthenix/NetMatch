using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetMatch_PT.Containers.Interfaces;
using NetMatch_PT.Models;

namespace NetMatch_PT.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserContainer _userContainer;
        public UserController(IUserContainer userContainer)
        {
            _userContainer = userContainer;
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            User result = _userContainer.Users.FirstOrDefault(u => u.Email == user.Email);

            if (result != null && result.ValidatePassword(user.Password))
            {
                return RedirectToAction("Index", "User");
            }
            else
            {
                return RedirectToAction("Login", "User");
            }
        }
    }
}