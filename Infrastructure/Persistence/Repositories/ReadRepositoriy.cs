using HepsiAPI.Application.Interfaces.Repositories;
using HepsiAPI.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ReadRepositoriy<T> : IReadRepository<T> where T : class, IEntityBase, new() // 
    {
        private readonly DbContext _dbContext;

        public ReadRepositoriy(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private DbSet<T> Table { get => _dbContext.Set<T>(); }
        // db setimi belirtip private metot oluşturduk bunude db contexde set etmesini sağladık

        public async Task<IList<T>> GetAllAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>?> orderBy = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            // entity framework core da bizim sorgularımızı takip ediyor mesela update işlemi gerçekleştiriyoruz id yi buldum entity'nin ondan sonra bu alana geldikten sonra update ediceğimzi yeri belittik buradaya kadar tüm işlemlerimizi asnotracking işleme giriyor sorguyu yaptığımız entity'yi takip ederek üzerinde işlem yaptık mı yapmadıkmı kontrol ediyor.
            if (include != null) queryable = include(queryable);
            if (predicate is not null) queryable.Where(predicate);// queryable sen bu işlem dahilinde sen where sorgusu yap ve predicate me bak diyoruz
            if (orderBy is not null)
                return await orderBy(queryable).ToListAsync();// eğer sıralama mevcutsa ozaman burada retun olarak tolist şeklinde getir

            return await queryable.ToListAsync(); // direk querablemi list edicek

        }

        public async Task<IList<T>> GetAllByPagingAsync(Expression<Func<T, bool>>? predicate = null, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, Func<IQueryable<T>, IOrderedQueryable<T>?> orderBy = null, bool enableTracking = false, int currentPage = 1, int pageSize = 3)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);
            if (predicate is not null) queryable.Where(predicate);
            if (orderBy is not null)
                return await orderBy(queryable).Skip(currentPage - 1 * pageSize).Take(pageSize).ToListAsync();

            return await queryable.Skip(currentPage - 1 * pageSize).Take(pageSize).ToListAsync();

        }
        public async Task<T> GetAsync(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool enableTracking = false)
        {
            IQueryable<T> queryable = Table;
            if (!enableTracking) queryable = queryable.AsNoTracking();
            if (include != null) queryable = include(queryable);

            //queryable.Where(predicate);

            return await queryable.FirstOrDefaultAsync(predicate);
        }
        public async Task<int> CountAysnc(Expression<Func<T, bool>>? predicate = null)
        {
            Table.AsNoTracking();
            if(predicate is not null) Table.Where(predicate);

            return  await Table.CountAsync();
        }

        public  IQueryable<T> Find(Expression<Func<T, bool>> predicate, bool enableTracking = false)
        {
            if (!enableTracking) Table.AsNoTracking();
            return  Table.Where(predicate);
        }





    }
}
