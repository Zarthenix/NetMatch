using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts;

namespace NetMatch_PT.Contexts.IContext
{
    public interface ITravelCompanyContext
    {
        List<TravelCompany> GetAll();
        TravelCompany GetById(int id);
        long Insert(TravelCompany tc);
    }
}
