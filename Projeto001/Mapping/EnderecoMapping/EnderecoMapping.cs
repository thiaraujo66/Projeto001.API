using AutoMapper;
using Projeto001.Domain.Entities;
using Projeto001.Models.Request.EnderecoRequest;
using Projeto001.Models.Response.EnderecoResponse;

namespace Projeto001.Mapping.EnderecoMapping
{
    public class EnderecoMapping : Profile
    {
        public EnderecoMapping()
        {
            CreateMap<CriarEnderecoRequest, Endereco>()
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Numero) ? null : src.Numero))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => string.IsNullOrWhiteSpace(src.Complemento) ? null : src.Complemento))
                .ForMember(dest => dest.IdPessoa, opt => opt.MapFrom(src => src.IdPessoa));

            CreateMap<AtualizarEnderecoRequest, Endereco>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento));

            CreateMap<Endereco, ListarEnderecoResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Logradouro, opt => opt.MapFrom(src => src.Logradouro))
                .ForMember(dest => dest.Bairro, opt => opt.MapFrom(src => src.Bairro))
                .ForMember(dest => dest.Numero, opt => opt.MapFrom(src => src.Numero))
                .ForMember(dest => dest.Cep, opt => opt.MapFrom(src => src.Cep))
                .ForMember(dest => dest.Cidade, opt => opt.MapFrom(src => src.Cidade))
                .ForMember(dest => dest.Uf, opt => opt.MapFrom(src => src.Uf))
                .ForMember(dest => dest.Complemento, opt => opt.MapFrom(src => src.Complemento))
                .ForMember(dest => dest.IdPessoa, opt => opt.MapFrom(src => src.IdPessoa));
        }
    }
}
