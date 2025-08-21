using serverT2.Domain.Entities;
using serverT2.Domain.Repository.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace serverT2.Infrascruture.DataAccess.Repository
{
    public class UserRepository : IUserReadOnlyRespository, IUserWriteOnlyRespository
    {
        private readonly AppDbContext _appDbContext;

        public UserRepository (AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }   

        public async Task Add(User user)
        {
            await _appDbContext.Users.AddAsync(user);
        }
        public async Task<bool> ExistsActiveUserEmail (string Email)
        {
            return await _appDbContext.Users.AnyAsync(x => x.Email.Equals(Email) && x.Active);
        }
    }
}
