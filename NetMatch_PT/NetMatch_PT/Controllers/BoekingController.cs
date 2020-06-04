using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetMatch_PT.Models;
using NetMatch_PT.Repositories;

namespace NetMatch_PT.Controllers
{
    public class BoekingController : Controller
    {
        private readonly TravelRepo _TravelRepo;
        private readonly BoekingRepository _BoekingRepo;
        public IActionResult PDFBoeking(int id)
        {
            //int ja = _BoekingRepo.GetTravelbyId(id);
            return View();
        }


    }
}
