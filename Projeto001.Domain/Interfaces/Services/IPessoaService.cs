using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Services
{
    public interface IPessoaService
    {
        public Task<IEnumerable<Pessoa>> ListaPessoas();
        public Task<Pessoa> ConsultaPorId(int pId);
        public Task<Pessoa> ConsultaPorCgc(string pCgc);
        public Task<Pessoa> CriarPessoa(Pessoa pPessoa);
        public Task<bool> AtualizarPessoa(Pessoa pPessoa, int pUsuario);
        public Task<bool> DeletarPessoa(int pId);
    }
}
