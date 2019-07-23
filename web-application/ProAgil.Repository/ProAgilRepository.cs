using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProAgil.Domain;

namespace ProAgil.Repository
{
    public class ProAgilRepository : IProAgilRepository
    {
        private readonly ProAgilContext _context;

        public ProAgilRepository(ProAgilContext context)
        {
            _context = context;
            // desabilita globalmente mecanismo de rastreamento do entity framework que trava (tracking) recurso enquanto está em uso
            _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        //GERAIS
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public void DeleteRange<T>(T[] entityArray) where T : class
        {
            _context.RemoveRange(entityArray);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        //EVENTO
        public async Task<Evento[]> GetAllEventoAsync(bool includePalestrantes = false)
        {
            // resposta dos eventos com os lotes e as redes sociais
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);
            // inclui os palestrantes do evento se for solicitado
            // opção para economia de recursos: lotes e redessociais poderiam ser feitos assim também
            if (includePalestrantes)
            { //referencia muitos para muitos 
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }
            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Evento[]> GetAllEventoAsyncByTema(string tema, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .OrderByDescending(c => c.DataEvento)
                        .Where(c => c.Tema.ToLower().Contains(tema.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Evento> GetEventoAsyncById(int eventoId, bool includePalestrantes)
        {
            IQueryable<Evento> query = _context.Eventos
                .Include(c => c.Lotes)
                .Include(c => c.RedesSociais);

            if (includePalestrantes)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(p => p.Palestrante);
            }

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .OrderBy(c => c.Id)
                        .Where(c => c.Id == eventoId);

            return await query.FirstOrDefaultAsync();
        }

        //PALESTRANTE
        public async Task<Palestrante> GetPalestranteAsyncById(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                    .OrderBy(p => p.Nome)
                    .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsyncByName(string name, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
                .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = _context.Palestrantes
              .Include(c => c.RedesSociais);

            if (includeEventos)
            {
                query = query
                    .Include(pe => pe.PalestrantesEventos)
                    .ThenInclude(e => e.Evento);
            }

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        // LOTE
        public async Task<Lote> GetLoteAsyncById(int loteId)
        {
            IQueryable<Lote> query = _context.Lotes;

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                    .Where(p => p.Id == loteId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Lote[]> GetAllLotesAsyncByName(string name)
        {
            IQueryable<Lote> query = _context.Lotes;

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }
        public async Task<Lote[]> GetAllLotesAsync()
        {
            IQueryable<Lote> query = _context.Lotes;

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

        // REDE SOCIAL
        public async Task<RedeSocial> GetRedeSocialAsyncById(int redeSocialId)
        {
            IQueryable<RedeSocial> query = _context.RedeSociais;

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                    .Where(p => p.Id == redeSocialId);

            return await query.FirstOrDefaultAsync();
        }

        public async Task<RedeSocial[]> GetAllRedesSociaisAsyncByName(string name)
        {
            IQueryable<RedeSocial> query = _context.RedeSociais;

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .Where(p => p.Nome.ToLower().Contains(name.ToLower()));

            return await query.ToArrayAsync();
        }

        public async Task<RedeSocial[]> GetAllRedesSociaisAsync()
        {
            IQueryable<RedeSocial> query = _context.RedeSociais;

            //não travar recurso para retornar consulta
            query = query.AsNoTracking()
                        .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }

    }
}
