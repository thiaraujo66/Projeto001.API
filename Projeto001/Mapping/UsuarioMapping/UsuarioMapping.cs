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
        }
    }
}
