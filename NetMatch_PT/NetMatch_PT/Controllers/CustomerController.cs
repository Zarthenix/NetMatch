using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetMatch_PT.Models;
using NetMatch_PT.Repositories;
using NetMatch_PT.ViewModels;
using NetMatch_PT.ViewModels.Converters;

namespace NetMatch_PT.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CustomerRepository _customerRepo;
        public CustomerController(CustomerRepository custRepo)
        {
            _customerRepo = custRepo;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
