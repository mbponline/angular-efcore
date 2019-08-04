using System;

namespace ProAgil.Domain.Entities
{
    public class Lote
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; } //chave estrangeira conven��o EntityFramework
        public Evento Evento { get; } //campo readonly

    }
}