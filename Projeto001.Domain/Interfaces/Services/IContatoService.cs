using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Services
{
    public interface IContatoService
    {
        public Task<IEnumerable<Contato>> ListaContatosPorPessoa(int pIdPessoa);
        public Task<Contato?> ConsultaPorId(int pId);
        public Task<Contato> CriarContato(Contato pContato);
        public Task<bool> AtualizarContato(Contato pContato, int pUsuario);
        public Task<bool> DeletarContato(int pId);
    }
}
