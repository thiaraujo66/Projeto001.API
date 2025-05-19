using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Services
{
    public interface IUsuarioService
    {
        public Task<IEnumerable<Usuario>> ListarUsuarios();
        public Task<Usuario> ConsultaPorId(int pId);
        public Task<Usuario> Login(string pUsuario, string pSenha);
        public Task<Usuario> CriarUsuario(Usuario pUsuario);
        public Task<bool> AtualizarUsuario(Usuario pUsuario);
        public Task<bool> DeletarUsuario(int pId);
    }
}
