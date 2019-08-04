
namespace ProAgil.Domain.Entities

{
    public class RedeSocial
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string URL { get; set; }
        public int? EventoId { get; set; } //chave estrangeira convenção EntityFramework
        public Evento Evento { get; } //campo readonly
        public int? PalestranteId { get; set; } //chave estrangeira convenção EntityFramework
        public Palestrante Palestrante { get; } //campo readonly
    }
}