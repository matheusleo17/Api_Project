using serverT2.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverT2.Domain.Repository.User
{
    public interface IUserReadOnlyRespository
    {
        public  Task<bool> ExistsActiveUserEmail(string Email);

        public Task<Entities.User?> GetbyEmailAndPassword(string email, string password);
    }
}
