using HepsiAPI.Application.Interfaces.Repositories;
using HepsiAPI.Application.Interfaces.UnitOfWorks;
using Persistence.Context;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbcontext;
        public UnitOfWork(AppDbContext dbcontext)
        {

            this.dbcontext = dbcontext;

        }
        public async ValueTask DisposeAsync() => await dbcontext.DisposeAsync();


        public int Save() => dbcontext.SaveChanges();

        public async Task<int> SaveAsync() => await dbcontext.SaveChangesAsync();

        IReadRepository<T> IUnitOfWork.GetReadRepository<T>() => new ReadRepositoriy<T>(dbcontext);


        IWriteRepository<T> IUnitOfWork.GetWriteRepository<T>() => new WriteRepository<T>(dbcontext);


    }
}
