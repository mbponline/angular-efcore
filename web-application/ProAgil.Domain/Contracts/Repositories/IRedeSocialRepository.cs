using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Contracts.Repositories
{
    public interface IRedeSocialRepository : IDisposable
    {
        void Add(RedeSocial redeSocial);
        void Update(RedeSocial redeSocial);
        void Remove(int id);
        void Remove(params object[] keyValues);
        Task<bool> SaveChanges();
        Task<int> GetMax(Expression<Func<RedeSocial, int>> select);
        Task<int> GetMin(Expression<Func<RedeSocial, int>> select);
      
        Task<RedeSocial> GetByIdAsync(int id);
        Task<RedeSocial[]> GetAllAsync();
        Task<RedeSocial[]> GetAllByNameAsync(string name);
    }
}