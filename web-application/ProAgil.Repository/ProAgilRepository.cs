using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository<T> : IProAgilRepository<T> where T : class
    {
        private readonly ProAgilContext _context;
        private readonly DbSet<T> _entity;
        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            _entity = _context.Set<T>();
            // desabilita globalmente mecanismo de rastreamento do entity framework que trava (tracking) recurso enquanto está em uso
            //  _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public void Add(T entity)
        {
            _entity.Add(entity);
        }

        public void Update(T entity)
        {
            _entity.Update(entity);
        }

        public async void Remove(int id)
        {
            _entity.Remove(await _entity.FindAsync(id));
        }
        public async void Remove(params object[] keyValues)
        {
            _entity.Remove(await _entity.FindAsync(keyValues));
        }

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> SaveChanges()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<int> GetMax(Expression<Func<T, int>> select)
        {
            return await _entity.Select(select).MaxAsync();
        }

        public async Task<int> GetMin(Expression<Func<T, int>> select)
        {
            return await _entity.Select(select).MinAsync();
        }

        public async Task<bool> Exists(int id)
        {
            return await _entity.AnyAsync<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _entity.FindAsync(id);
        }

        public async Task<T[]> GetAllAsync()
        {
            return await _entity.ToArrayAsync();
        }

        public Task<T[]> GetAllByNameAsync(string name)
        {
            //testar se nome da coluna existe filtrar os campos por elas.
            var result = _entity.FromSql("IF EXISTS( SELECT * FROM INFORMATION_SCHEMA.COLUMNS WHERE UPPER(TABLE_NAME) = UPPER(Eventos" +
               ")  AND  UPPER(COLUMN_NAME) IN ( 'NOME', 'TEMA'))");

            if (result.Any())
            {
                return null;
            }
             return null;
            //return await _entity.Where(p => p.Nome.ToLower().Contains(name.ToLower())).ToArrayAsync();
        }

        
    }
}
