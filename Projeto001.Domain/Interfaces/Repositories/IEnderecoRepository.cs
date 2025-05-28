using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Repositories
{
    public interface IEnderecoRepository
    {
        public Task<IEnumerable<Endereco>> ListaEnderecosPorPessoa(int pIdPessoa);
        public Task<Endereco?> ConsultaPorId(int pId);
        public Task CriarEndereco(Endereco pEndereco);
        public Task AtualizarEndereco(Endereco pEndereco);
        public Task DeletarEndereco(Endereco pEndereco);
    }
}
