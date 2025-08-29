using serverT2.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace serverT2.Infrastructure.DataAccess
{
    public class UnityOfWork : IUnityOfWork
    {
        private readonly AppDbContext _appDbContext;

        public UnityOfWork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task Commit()
        {
            await _appDbContext.SaveChangesAsync();
        }
    }
}
