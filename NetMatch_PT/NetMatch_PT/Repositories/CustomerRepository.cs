using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMatch_PT.Contexts.IContext;
using NetMatch_PT.Models;

namespace NetMatch_PT.Repositories
{
    public class CustomerRepository
    {
        protected readonly ICustomerContext _context;

        public CustomerRepository(ICustomerContext context)
        {
            _context = context;
        }
        public List<Customer> GetAll()
        {
            return _context.GetAll();
        }
        public Customer GetById(int id)
        {
            return _context.GetById(id);
        }
        public bool Update(Customer c)
        {
            return _context.Update(c);
        }
    }
}
