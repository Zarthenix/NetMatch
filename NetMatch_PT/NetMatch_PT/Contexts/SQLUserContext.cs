using Microsoft.Extensions.Configuration;
using NetMatch_PT.Contexts.Interfaces;
using NetMatch_PT.Models;
using Org.BouncyCastle.Crypto.Tls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Contexts
{
    public class SQLUserContext : SQLBaseContext, IUserContext
    {
        public SQLUserContext(IConfiguration configuration) : base(configuration)
        {

        }

        public IReadOnlyList<User> Users => throw new NotImplementedException();

        public void Create(string email, string password)
        {
        
        }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public void GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
