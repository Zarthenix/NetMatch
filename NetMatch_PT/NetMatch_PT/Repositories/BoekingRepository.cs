using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Repositories
{
    public class BoekingRepository
    {
        private IBoekingContext _context;
        public BoekingRepository( IBoekingContext context)
        {
            _context = context;
        }

        public Travel GetTravelbyId(int id)
        {
            return _context.GetTravelbyId(id);
        }
        public List<Boeking> GetAll()
        {
            return _context.GetAll();
        }
        public long insert(Boeking b)
        {
            return _context.insert(b);
        }
    }
}
