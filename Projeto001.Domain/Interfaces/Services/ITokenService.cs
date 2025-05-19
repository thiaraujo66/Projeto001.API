using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        public Task<string> GetToken(Usuario usuario);
    }
}
