using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Domain.Interfaces.Services;

namespace Projeto001.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<bool> AtualizarUsuario(Usuario pUsuario)
        {
            Usuario? usu = await _usuarioRepository.ConsultaPorId(pUsuario.Id);

            if (usu is null)
                return false;

            usu.Username = string.IsNullOrWhiteSpace(pUsuario.Username) ? usu.Username : pUsuario.Username;
            usu.Senha = string.IsNullOrWhiteSpace(pUsuario.Senha) ? usu.Senha : pUsuario.Senha;
            usu.Permissao = pUsuario.Permissao;
            usu.AltSenha = pUsuario.AltSenha;

            await _usuarioRepository.AtualizarUsuario(usu);

            return true;
        }

        public async Task<Usuario?> ConsultaPorId(int pId)
        {
            Usuario? usu = await _usuarioRepository.ConsultaPorId(pId);

            return usu;
        }

        public async Task<Usuario> CriarUsuario(Usuario pUsuario)
        {
            await _usuarioRepository.CriarUsuario(pUsuario);

            return pUsuario;
        }

        public async Task<bool> DeletarUsuario(int pId)
        {
            Usuario usu = await _usuarioRepository.ConsultaPorId(pId);

            if (usu is null)
                return false;

            await _usuarioRepository.DeletarUsuario(usu);

            return true;
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            IEnumerable<Usuario> usuarios = await _usuarioRepository.ListarUsuarios();

            return usuarios;
        }

        public async Task<Usuario?> Login(string pUsuario, string pSenha)
        {
            Usuario? usuario = await _usuarioRepository.Login(pUsuario, pSenha);

            return usuario;
        }
    }
}
