using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts.IContext;

namespace NetMatch_PT.Repositories
{
    public class TravelAgentRepository
    {
        private ITravelAgentContext _context;
        
        public TravelAgentRepository(ITravelAgentContext context)
        {
            _context = context;
        }
        public TravelAgent GetById(int id)
        {
            return _context.GetById(id);
        }
        public List<TravelAgent> GetAll()
        {
            return _context.GetAll();
        }
    }
}
