using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Contexts.Interfaces
{
    public interface IBoekingContext
    {
        public Travel GetTravelbyId(int id);
        public List<Boeking> GetAll();
        public long insert(Boeking b);
    }
}
