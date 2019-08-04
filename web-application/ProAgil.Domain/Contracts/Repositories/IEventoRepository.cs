using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Contracts.Repositories
{
    public interface IEventoRepository : IDisposable
    {
        void Add(Evento evento);
        void Update(Evento evento);
        void Remove(int id);
        void Remove(params object[] keyValues);
        Task<bool> SaveChanges();
        Task<int> GetMax(Expression<Func<Evento, int>> select);
        Task<int> GetMin(Expression<Func<Evento, int>> select);
        Task<bool> Exists(int id);
        Task<Evento> GetByIdAsync(int id);
        Task<Evento[]> GetAllAsync();
        Task<Evento[]> GetAllByNameAsync(string name);
    }
}