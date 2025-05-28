using Microsoft.EntityFrameworkCore;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Infraestrutura.Data;

namespace Projeto001.Infraestrutura.Repositories
{
    public class ContatoRepository : IContatoRepository
    {
        private readonly Projeto001Context _context;

        public ContatoRepository(Projeto001Context context)
        {
            _context = context;
        }

        public async Task AtualizarContato(Contato pContato)
        {
            _context.Entry(pContato).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Contato?> ConsultaPorId(int pId)
        {
            return await _context.Contatos.FindAsync(pId) ?? null;
        }

        public async Task CriarContato(Contato pContato)
        {
            _context.Contatos.Add(pContato);

            await _context.SaveChangesAsync();
        }

        public async Task DeletarContato(Contato pContato)
        {
            _context.Contatos.Remove(pContato);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Contato>> ListaContatosPorPessoa(int pIdPessoa)
        {
            return await _context.Contatos.Where(x => x.IdPessoa == pIdPessoa).ToListAsync();
        }
    }
}
