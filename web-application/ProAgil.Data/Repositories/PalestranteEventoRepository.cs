using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Contracts.Repositories;

namespace ProAgil.Data.Repositories
{
    public class PalestranteEventoRepository : IPalestranteEventoRepository
    {
        public void Add(PalestranteEvento palestranteEvento)
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

        public Task<PalestranteEvento[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<PalestranteEvento[]> GetAllByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<PalestranteEvento> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMax(Expression<Func<PalestranteEvento, int>> select)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMin(Expression<Func<PalestranteEvento, int>> select)
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

        public void Update(PalestranteEvento palestranteEvento)
        {
            throw new NotImplementedException();
        }
    }
}