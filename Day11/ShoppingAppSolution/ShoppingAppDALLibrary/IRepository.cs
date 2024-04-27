using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingAppDALLibrary
{
    public interface IRepository<K, T>
    {
        Task<T> Add(T item);
        Task<T> GetByKey(K key);
        Task<T> Update(T item);
        Task<T> Delete(K key);
        Task<List<T>> GetAll();
    }
}
