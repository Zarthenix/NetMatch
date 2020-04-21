using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Models;

namespace NetMatch_PT.Contexts.Interfaces
{
    public interface IAccommodationContext
    {
        Accommodation GetById(int id);
        List<Accommodation> GetAll();
        List<Accommodation> Search(string SearchTerm);
    }
}
