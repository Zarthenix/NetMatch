using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts.IContext;

namespace NetMatch_PT.Repositories
{
    public class TravelCompanyRepository
    {
        private ITravelCompanyContext _context;
        public TravelCompanyRepository(ITravelCompanyContext context)
        {
            _context = context;
        }
        public List<TravelCompany> GetAll()
        {
            return _context.GetAll();
        }
        public TravelCompany GetById(int id)
        {
            return _context.GetById(id);
        }
        public long Insert(TravelCompany tc)
        {
            return _context.Insert(tc);
        }
    }
}
