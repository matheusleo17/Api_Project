using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace serverT2.Domain.Repository.User
{
    public interface IUserWriteOnlyRespository
    {
        public Task Add(Entities.User user);

    }
}
