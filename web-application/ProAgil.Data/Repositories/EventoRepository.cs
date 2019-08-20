using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Contracts.Repositories;
using ProAgil.Domain.Entities;

namespace ProAgil.Data.Repositories
{
    public class EventoRepository : IEventoRepository
    {

        private readonly ProAgilContext _context;

        public EventoRepository(ProAgilContext context)
        {
            _context = context;
        }

        public void Add(Evento evento)
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

        public async Task<Evento[]> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Evento[]> GetAllByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<Evento> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMax(Expression<Func<Evento, int>> select)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetMin(Expression<Func<Evento, int>> select)
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

        public void Update(Evento evento)
        {
            throw new NotImplementedException();
        }
    }
}