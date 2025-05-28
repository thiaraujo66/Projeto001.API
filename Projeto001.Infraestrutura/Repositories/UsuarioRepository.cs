using Microsoft.EntityFrameworkCore;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Infraestrutura.Data;

namespace Projeto001.Infraestrutura.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Projeto001Context _context;

        public UsuarioRepository(Projeto001Context context)
        {
            _context = context;
        }

        public async Task AtualizarUsuario(Usuario pUsuario)
        {
            _context.Entry(pUsuario).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Usuario?> ConsultaPorId(int pId)
        {
            return await _context.Usuarios.FindAsync(pId);
        }

        public async Task CriarUsuario(Usuario pUsuario)
        {
            _context.Usuarios.Add(pUsuario);

            await _context.SaveChangesAsync();
        }

        public async Task DeletarUsuario(Usuario pUsuario)
        {
            _context.Usuarios.Remove(pUsuario);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Usuario>> ListarUsuarios()
        {
            return await _context.Usuarios.ToListAsync();
        }

        public async Task<Usuario?> Login(string pUsuario, string pSenha)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(x => x.Username == pUsuario && x.Senha == pSenha);
        }
    }
}
