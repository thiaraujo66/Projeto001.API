using Projeto001.Domain.Entities;

namespace Projeto001.Domain.Interfaces.Repositories
{
    public interface IContatoRepository
    {
        public Task<IEnumerable<Contato>> ListaContatosPorPessoa(int pIdPessoa);
        public Task<Contato> ConsultaPorId(int pId);
        public Task CriarContato(Contato pContato);
        public Task AtualizarContato(Contato pContato);
        public Task DeletarUsuario(Contato pContato);
    }
}
