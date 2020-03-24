using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;
using NetMatch_PT.Contexts;

namespace NetMatch_PT.Contexts.IContext
{
    public interface ITravelAgentContext
    {
        List<TravelAgent> GetAll();
        TravelAgent GetById(int id);
    }
}
