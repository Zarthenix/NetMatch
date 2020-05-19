using NetMatch_PT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMatch_PT.Containers.Interfaces
{
    public interface IUserContainer
    {
        public IReadOnlyList<User> Users { get; }
        public void GetAll();
        public void Create(string email, string password);
        public void Delete(User user);
    }
}
