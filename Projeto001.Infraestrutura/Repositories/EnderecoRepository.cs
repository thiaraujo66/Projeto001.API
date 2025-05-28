using Microsoft.EntityFrameworkCore;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Infraestrutura.Data;

namespace Projeto001.Infraestrutura.Repositories
{
    public class EnderecoRepository : IEnderecoRepository
    {

        private readonly Projeto001Context _context;

        public EnderecoRepository(Projeto001Context context)
        {
            _context = context;
        }

        public async Task AtualizarEndereco(Endereco pEndereco)
        {
            _context.Entry(pEndereco).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Endereco?> ConsultaPorId(int pId)
        {
            return await _context.Enderecos.FindAsync(pId) ?? null;
        }

        public async Task CriarEndereco(Endereco pEndereco)
        {
            _context.Enderecos.Add(pEndereco);

            await _context.SaveChangesAsync();
        }

        public async Task DeletarEndereco(Endereco pEndereco)
        {
            _context.Enderecos.Remove(pEndereco);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Endereco>> ListaEnderecosPorPessoa(int pIdPessoa)
        {
            return await _context.Enderecos.Where(x => x.IdPessoa == pIdPessoa).ToListAsync();
        }
    }
}
