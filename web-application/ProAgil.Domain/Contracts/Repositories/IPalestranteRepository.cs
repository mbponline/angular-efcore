using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Contracts.Repositories
{
    public interface IPalestranteRepository : IDisposable
    {
       void Add(Palestrante palestrante);
        void Update(Palestrante palestrante);
        void Remove(int id);
        void Remove(params object[] keyValues);
        Task<bool> SaveChanges();
        Task<int> GetMax(Expression<Func<Palestrante, int>> select);
        Task<int> GetMin(Expression<Func<Palestrante, int>> select);
        Task<bool> Exists(int id);
        Task<Palestrante> GetByIdAsync(int id);
        Task<Palestrante[]> GetAllAsync();
        Task<Palestrante[]> GetAllByNameAsync(string name);
    }
}