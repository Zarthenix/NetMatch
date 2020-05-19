using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts.IContext;
using NetMatch_PT.ViewModels;

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
        public List<Accommodation> Search(string searchTerm)
        {
            return _context.Search(searchTerm);
        }

        public List<Accommodation> QuickSearch(SearchVm search)
        {
            return _context.QuickSearch(search);
        }

        public List<Accommodation> GetAll()
        {
            return _context.GetAll();
        }
    }
}
