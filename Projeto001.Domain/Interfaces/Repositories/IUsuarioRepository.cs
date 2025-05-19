using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository
    {
        public Task<IEnumerable<Usuario>> ListarUsuarios();
        public Task<Usuario> ConsultaPorId(int pId);
        public Task<Usuario?> Login(string pUsuario, string pSenha);
        public Task CriarUsuario(Usuario pUsuario);
        public Task AtualizarUsuario(Usuario pUsuario);
        public Task DeletarUsuario(Usuario pUsuario);
    }
}
