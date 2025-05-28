using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Services
{
    public interface IEnderecoService
    {
        public Task<IEnumerable<Endereco>> ListaEnderecosPorPessoa(int pIdPessoa);
        public Task<Endereco> ConsultaPorId(int pId);
        public Task<Endereco> CriarEndereco(Endereco pEndereco);
        public Task<bool> AtualizarEndereco(Endereco pEndereco, int pUsuario);
        public Task<bool> DeletarEndereco(int pId);
    }
}
