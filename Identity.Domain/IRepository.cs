using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain
{
    public interface IRepository<T> where T : class
    {
        Task<int> Create(T entity);

        Task<T> ReadAsync(int id);

        Task<IEnumerable<T>> ReadAsync(Expression<Func<T, bool>> predicate);

        Task<T> UpdateAsync(string entityName, T entity);

        Task DeleteAsync(string entityName, int id);

        Task<IEnumerable<T>> ReadAsync();
    }
}
