using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts;
using NetMatch_PT.Models;

namespace NetMatch_PT.Contexts.IContext
{
    public interface ICustomerContext
    {
        List<Customer> GetAll();
        Customer GetById(int id);
        bool Update(Customer c);
    }
}
