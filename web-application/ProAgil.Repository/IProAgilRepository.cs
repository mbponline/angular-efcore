using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository<T> where T : class
    {
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
         void Remove(params object[] keyValues);
        void Dispose();       
        Task<bool> SaveChanges();
        Task<int> GetMax(Expression<Func<T, int>> select);
        Task<int> GetMin(Expression<Func<T, int>> select);
        Task<bool> Exists(int id);
        Task<T> GetByIdAsync(int id);
        Task<T[]> GetAllAsync();
        Task<T[]> GetAllByNameAsync(string name);
    }
}