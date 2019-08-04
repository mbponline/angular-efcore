using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Contracts.Repositories
{
    public interface IPalestranteEventoRepository : IDisposable
    {
        void Add(PalestranteEvento palestranteEvento);
        void Update(PalestranteEvento palestranteEvento);
        void Remove(int id);
        void Remove(params object[] keyValues);
        Task<bool> SaveChanges();
        Task<int> GetMax(Expression<Func<PalestranteEvento, int>> select);
        Task<int> GetMin(Expression<Func<PalestranteEvento, int>> select);
        Task<bool> Exists(int id);
        Task<PalestranteEvento> GetByIdAsync(int id);
        Task<PalestranteEvento[]> GetAllAsync();
        Task<PalestranteEvento[]> GetAllByNameAsync(string name);




    }
}