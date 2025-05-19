using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Enums;
using Projeto001.Domain.Interfaces.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Projeto001.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IUsuarioService _usuarioService;

        public TokenService(IConfiguration configuration, IUsuarioService usuarioService)
        {
            _configuration = configuration;
            _usuarioService = usuarioService;
        }

        public async Task<string> GetToken(Usuario usuario)
        {
            Usuario usuarioExiste = await _usuarioService.Login(usuario.Username, usuario.Senha);

            if (usuarioExiste is null)
                return string.Empty;

            var tokenHandler = new JwtSecurityTokenHandler();

            var chaveCriptografia = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretJWT"));

            var tokenPropriedades = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioExiste.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuarioExiste.Username),
                    new Claim(ClaimTypes.Role, ((TipoPermissaoSistema)usuarioExiste.Permissao).ToString()),
                }),

                Expires = DateTime.UtcNow.AddHours(8),

                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(chaveCriptografia),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenPropriedades);
            return tokenHandler.WriteToken(token);

        }

    }
}
