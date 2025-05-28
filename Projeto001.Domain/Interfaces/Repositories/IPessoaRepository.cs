using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Repositories
{
    public interface IPessoaRepository
    {
        public Task<IEnumerable<Pessoa>> ListaPessoas();
        public Task<Pessoa?> ConsultaPorId(int pId);
        public Task<Pessoa?> ConsultaPorCgc(string pCgc);
        public Task CriarPessoa(Pessoa pPessoa);
        public Task AtualizarPessoa(Pessoa pPessoa);
        public Task DeletarPessoa(Pessoa pPessoa);
    }
}
