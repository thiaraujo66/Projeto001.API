using Microsoft.EntityFrameworkCore;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Infraestrutura.Data;

namespace Projeto001.Infraestrutura.Repositories
{
    public class PessoaRepository : IPessoaRepository
    {

        private readonly Projeto001Context _context;

        public PessoaRepository(Projeto001Context context)
        {
            _context = context;
        }

        public async Task AtualizarPessoa(Pessoa pPessoa)
        {
            _context.Entry(pPessoa).State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task<Pessoa?> ConsultaPorCgc(string pCgc)
        {
            return await _context.Pessoas.Where(x => x.Cgc == pCgc).FirstOrDefaultAsync() ?? null;
        }

        public async Task<Pessoa?> ConsultaPorId(int pId)
        {
            return await _context.Pessoas.FindAsync(pId) ?? null;
        }

        public async Task CriarPessoa(Pessoa pPessoa)
        {
            _context.Pessoas.Add(pPessoa);

            await _context.SaveChangesAsync();
        }

        public async Task DeletarPessoa(Pessoa pPessoa)
        {
            _context.Pessoas.Remove(pPessoa);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pessoa>> ListaPessoas()
        {
            return await _context.Pessoas.ToListAsync();
        }
    }
}
