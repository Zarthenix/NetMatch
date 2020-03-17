using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;

namespace NetMatch_PT.Repositories
{
    public class AccommodationRepo
    {
        private IAccommodationContext _context;

        public AccommodationRepo(IAccommodationContext context)
        {
            _context = context;
        }

        public Accommodation GetById(int id)
        {
            return _context.GetById(id);
        }
    }
}
