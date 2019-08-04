using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Contracts.Repositories;
using ProAgil.Domain.Entities;

namespace ProAgil.Data.Repositories
{
    public class RedeSocialRepository : IRedeSocialRepository
    {
        private readonly ProAgilContext _context;
        public RedeSocialRepository(ProAgilContext context)
        {
            _context = context;
        }
        public void Add(RedeSocial redeSocial)
        {
            _context.RedeSociais.Add(redeSocial);
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
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