using System.Collections.Generic;
using System;
namespace ProAgil.WebAPI.Dtos
{
    public class EventoDto
    {
        public int Id { get; private set; }
        public string Local { get; private set; }
        public string DataEvento { get; private set; }
        public string Tema { get; private set; }
        public int QtdPessoas { get; private set; }
        public string ImagemURL { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public List<LoteDto> Lotes { get; set; }
        public List<RedeSocialDto> RedesSociais { get; set; }
        public List<PalestranteDto> Palestrantes { get;   set; }
    }
}