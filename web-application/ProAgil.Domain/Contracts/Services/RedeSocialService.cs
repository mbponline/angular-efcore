using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Contracts.Repositories;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Contracts.Services
{
    public class RedeSocialService : IRedeSocialRepository
    {
        public void Add(RedeSocial redeSocial)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<RedeSocial[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RedeSocial[]> GetAllByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<RedeSocial> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMax(Expression<Func<RedeSocial, int>> select)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMin(Expression<Func<RedeSocial, int>> select)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(RedeSocial redeSocial)
        {
            throw new NotImplementedException();
        }
    }
}