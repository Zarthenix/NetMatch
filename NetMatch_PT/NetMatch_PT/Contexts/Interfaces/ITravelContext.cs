using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts;
using NetMatch_PT.Models;

namespace NetMatch_PT.Contexts
{
    public interface ITravelContext
    {
        
        Travel GetById(int id);
        List<Travel> GetAll();
        long insert(Travel t);
    }
}
