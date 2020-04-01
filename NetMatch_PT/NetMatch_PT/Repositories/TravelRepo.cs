using NetMatch_PT.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts.IContext;
using NetMatch_PT.Models;
using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts.Interfaces;

namespace NetMatch_PT.Repositories
{
    public class TravelRepo
    {
        private ITravelContext _context;

        public TravelRepo(ITravelContext context)
        {
            _context = context;
        }
        public List<Travel> GetAll()
        {
            return _context.GetAll();
        }
        public Travel GetById(int id)
        {
            return _context.GetById(id);
        }
       
}
