using System.Threading.Tasks;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public interface IProAgilRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteRange<T>(T[] entity) where T : class;

        Task<bool> SaveChangesAsync();

        //EVENTOS
        Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes);
        Task<Evento[]> GetAllEventoAsync(bool includePalestrantes);
        Task<Evento> GetEventoAsyncById(int eventoId, bool includePalestrantes);

        //PALESTRANTE
        Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos);
        Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos);
        Task<Palestrante> GetPalestranteAsyncById(int palestranteId, bool includeEventos);

        // Lotes
        Task<Lote[]> GetAllLotesAsync();
        Task<Lote[]> GetAllLotesAsyncByName(string loteName);
        Task<Lote> GetLoteAsyncById(int loteId);

        // REDE SOCIAL
        Task<RedeSocial[]> GetAllRedesSociaisAsync();
        Task<RedeSocial[]> GetAllRedesSociaisAsyncByName(string loteName);
        Task<RedeSocial> GetRedeSocialAsyncById(int loteId);

    }
}