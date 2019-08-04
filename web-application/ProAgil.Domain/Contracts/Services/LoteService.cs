using System;
using System.Threading.Tasks;
using System.Linq.Expressions;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Contracts.Repositories;

namespace ProAgil.Domain.Contracts.Services

{
    public class LoteService: ILoteRepository 
    {       
        void ILoteRepository.Add(Lote lote)
        {
            throw new NotImplementedException();
        }

        void ILoteRepository.Update(Lote lote)
        {
            throw new NotImplementedException();
        }

        void ILoteRepository.Remove(int id)
        {
            throw new NotImplementedException();
        }

        void ILoteRepository.Remove(params object[] keyValues)
        {
            throw new NotImplementedException();
        }

        Task<bool> ILoteRepository.SaveChanges()
        {
            throw new NotImplementedException();
        }

        Task<int> ILoteRepository.GetMax(Expression<Func<Lote, int>> select)
        {
            throw new NotImplementedException();
        }

        Task<int> ILoteRepository.GetMin(Expression<Func<Lote, int>> select)
        {
            throw new NotImplementedException();
        }

        Task<bool> ILoteRepository.Exists(int id)
        {
            throw new NotImplementedException();
        }

        Task<Lote> ILoteRepository.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<Lote[]> ILoteRepository.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Lote[]> ILoteRepository.GetAllByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}