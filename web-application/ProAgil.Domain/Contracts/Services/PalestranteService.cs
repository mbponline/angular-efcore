using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ProAgil.Domain.Contracts.Repositories;
using ProAgil.Domain.Entities;

namespace ProAgil.Domain.Contracts.Services
{
    public class PalestranteService : IPalestranteRepository
    {
        void IPalestranteRepository.Add(Palestrante palestrante)
        {
            throw new NotImplementedException();
        }

        void IPalestranteRepository.Update(Palestrante palestrante)
        {
            throw new NotImplementedException();
        }

        void IPalestranteRepository.Remove(int id)
        {
            throw new NotImplementedException();
        }

        void IPalestranteRepository.Remove(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPalestranteRepository.SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task<int> IPalestranteRepository.GetMax(Expression<Func<Palestrante, int>> select)
        {
            throw new NotImplementedException();
        }

        Task<int> IPalestranteRepository.GetMin(Expression<Func<Palestrante, int>> select)
        {
            throw new NotImplementedException();
        }

        Task<bool> IPalestranteRepository.Exists(int id)
        {
            throw new NotImplementedException();
        }

        Task<Palestrante> IPalestranteRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Palestrante[]> IPalestranteRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Palestrante[]> IPalestranteRepository.GetAllByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}