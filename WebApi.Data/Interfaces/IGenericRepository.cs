using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.Data.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IList<T>> GetAll(params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetAllTake(int take, int skip, params Expression<Func<T, object>>[] navigationProperties);
        Task<IList<T>> GetList(Expression<Func<T, bool>> where, params Expression<Func<T, object>>[] navigationProperties);
        Task<int> GetCount();
        Task<int> GetCount(Expression<Func<T, bool>> where);
        Task Add(params T[] items);
        Task Update(params T[] items);
        Task Remove(params T[] items);
      
    }
}
