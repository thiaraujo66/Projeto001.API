using AutoMapper;
using Projeto001.Domain.Entities;
using Projeto001.Models.Request.UsuarioRequest;
using Projeto001.Models.Response.UsuarioResponse;

namespace Projeto001.Mapping.UsuarioMapping
{
    public class UsuarioMapping : Profile
    {
        public UsuarioMapping()
        {
            CreateMap<LoginModel, Usuario>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha));

            CreateMap<Usuario, LoginResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Permissao, opt => opt.MapFrom(src => src.Permissao));

            CreateMap<CriarUsuarioModel, Usuario>()
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => src.Senha))
                .ForMember(dest => dest.Permissao, opt => opt.MapFrom(src => src.Permissao))
                .ForMember(dest => dest.IdPessoa, opt => opt.MapFrom(src => src.IdPessoa));

            CreateMap<Usuario, ListaUsuarioResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Permissao, opt => opt.MapFrom(src => src.Permissao));

            CreateMap<Usuario, ConsultaUsuarioResponse>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Permissao, opt => opt.MapFrom(src => src.Permissao))
                .ForMember(dest => dest.AltSenha, opt => opt.MapFrom(src => src.AltSenha))
                .ForMember(dest => dest.IdPessoa, opt => opt.MapFrom(src => src.IdPessoa));

            CreateMap<AlterarUsuario, Usuario>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Username, opt => opt.MapFrom(src => src.Username))
                .ForMember(dest => dest.Permissao, opt => opt.MapFrom(src => src.Permissao))
                .ForMember(dest => dest.AltSenha, opt => opt.MapFrom(src => src.AltSenha));


        }
    }
}
