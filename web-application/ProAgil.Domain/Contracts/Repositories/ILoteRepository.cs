using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Contracts.Repositories

{
    public interface ILoteRepository : IDisposable
    {
        void Add(Lote lote);
        void Update(Lote lote);
        void Remove(int id);
        void Remove(params object[] keyValues);
        Task<bool> SaveChanges();
        Task<int> GetMax(Expression<Func<Lote, int>> select);
        Task<int> GetMin(Expression<Func<Lote, int>> select);
        Task<bool> Exists(int id);
        Task<Lote> GetByIdAsync(int id);
        Task<Lote[]> GetAllAsync();
        Task<Lote[]> GetAllByNameAsync(string name);

    }
}