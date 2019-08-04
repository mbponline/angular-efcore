using AutoMapper;
using ProAgil.Domain.Entities;
using ProAgil.Domain.Entities.Identity;
using ProAgil.WebAPI.Dtos;
using System.Linq;

namespace ProAgil.WebAPI.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            //relacionamento n para n
            //origem é Evento
            //destinatario é EventoDto
            //para cada palestranteEventos do destino pega o palestrante da origem
            CreateMap<Evento, EventoDto>()
            .ForMember(destino => destino.Palestrantes, opt =>
            {
                opt.MapFrom(origem => origem.PalestrantesEventos.Select(x => x.Palestrante).ToList());
            }).ReverseMap();

            //origem é Evento
            //destinatario é EventoDto
            //para cada PalestranteEventos do destino pega o evento da origem
            CreateMap<Palestrante, PalestranteDto>()
            .ForMember(destino => destino.Eventos, opt =>
            {
                opt.MapFrom(origem => origem.PalestrantesEventos.Select(x => x.Evento).ToList());
            }).ReverseMap();
            //mapeamento invertido
            CreateMap<Lote, LoteDto>().ReverseMap();
            CreateMap<RedeSocial, RedeSocialDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserLoginDto>().ReverseMap();
        }
    }
}