using AutoMapper;
using Projeto001.Domain.Entities;
using Projeto001.Models.Request.ContatoRequest;
using Projeto001.Models.Response.ContatoResponse;

namespace Projeto001.Mapping.ContatoMapping
{
    public class ContatoMapping : Profile
    {
        public ContatoMapping()
        {
            CreateMap<Contato, ListarContatosResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Conteudo, opt => opt.MapFrom(src => src.Conteudo))
                .ReverseMap();

            CreateMap<CriarContatoRequest, Contato>()
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Conteudo, opt => opt.MapFrom(src => src.Conteudo))
                .ForMember(dest => dest.IdPessoa, opt => opt.MapFrom(src => src.IdPessoa))
                .ReverseMap();

            CreateMap<AtualizarContatoRequest, Contato>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Tipo, opt => opt.MapFrom(src => src.Tipo))
                .ForMember(dest => dest.Conteudo, opt => opt.MapFrom(src => src.Conteudo))
                .ReverseMap();
        }
    }
}
