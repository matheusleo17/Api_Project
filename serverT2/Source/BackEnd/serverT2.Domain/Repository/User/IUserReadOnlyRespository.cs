using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api2._0.Domain.Repository.User
{
    public interface IUserReadOnlyRespository
    {
        public  Task<bool> ExistsActiveUserEmail(string Email);
    }
}
