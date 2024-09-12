using HepsiAPI.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HepsiAPI.Application.Interfaces.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        Task AddRangeAsync(IList<T> entities);
        Task<T> UpdateAsync(T entity); // update ettiğimi geri döndürebilmek için bu metodu kullanacağız
        Task HardDeleteAsync(T entity);  // (int id) bilerek almadık belki id si int olmayan da olabileceğinden  // bide burda direk silme işlemi fakat %99 olarak bunu kullanmayız

    }
}
