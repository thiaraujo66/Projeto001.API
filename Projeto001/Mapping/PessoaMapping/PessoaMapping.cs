using AutoMapper;
using Projeto001.Domain.Entities;
using Projeto001.Models.Request.PessoaRequest;
using Projeto001.Models.Response.PessoaResponse;

namespace Projeto001.Mapping.PessoaMapping
{
    public class PessoaMapping : Profile
    {
        public PessoaMapping()
        {
            CreateMap<CriarPessoaRequest, Pessoa>()
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cgc, opt => opt.MapFrom(src => src.Cgc))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Rg, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Rg) ? null : src.Rg))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Mae, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Mae) ? null : src.Mae))
                .ForMember(dest => dest.Pai, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Pai) ? null : src.Pai));

            CreateMap<AtualizarPessoaRequest, Pessoa>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cgc, opt => opt.MapFrom(src => src.Cgc))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.DataNascimento, opt => opt.MapFrom(src => src.DataNascimento))
                .ForMember(dest => dest.Rg, opt => opt.MapFrom(src => src.Rg))
                .ForMember(dest => dest.Genero, opt => opt.MapFrom(src => src.Genero))
                .ForMember(dest => dest.Mae, opt => opt.MapFrom(src => src.Mae))
                .ForMember(dest => dest.Pai, opt => opt.MapFrom(src => src.Pai));

            CreateMap<Pessoa, ListarPessoaResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Nome, opt => opt.MapFrom(src => src.Nome))
                .ForMember(dest => dest.Cgc, opt => opt.MapFrom(src => src.Cgc))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email));
        }
    }
}
