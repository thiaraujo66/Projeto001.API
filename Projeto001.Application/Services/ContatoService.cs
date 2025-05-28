using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Domain.Interfaces.Services;

namespace Projeto001.Application.Services
{
    public class ContatoService : IContatoService
    {
        private IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public async Task<bool> AtualizarContato(Contato pContato, int pUsuario)
        {
            Contato? ctt = await _contatoRepository.ConsultaPorId(pContato.Id);

            if (ctt is null)
                return false;

            ctt.Conteudo = string.IsNullOrWhiteSpace(pContato.Conteudo) ? ctt.Conteudo : pContato.Conteudo;
            ctt.Tipo = pContato.Tipo.HasValue ? ctt.Tipo : pContato.Tipo;
            ctt.UsuarioAlteracao = pUsuario;
            ctt.DataAlteracao = DateTime.Now;

            await _contatoRepository.AtualizarContato(ctt);

            return true;
        }

        public async Task<Contato?> ConsultaPorId(int pId)
        {
            Contato? ctt = await _contatoRepository.ConsultaPorId(pId);

            return ctt;
        }

        public async Task<Contato> CriarContato(Contato pContato)
        {
            await _contatoRepository.CriarContato(pContato);

            return pContato;
        }

        public async Task<bool> DeletarContato(int pId)
        {
            Contato? ctt = await _contatoRepository.ConsultaPorId(pId);

            if (ctt is null)
                return false;

            await _contatoRepository.DeletarContato(ctt);

            return true;
        }

        public async Task<IEnumerable<Contato>> ListaContatosPorPessoa(int pIdPessoa)
        {
            IEnumerable<Contato> contatos = await _contatoRepository.ListaContatosPorPessoa(pIdPessoa);

            return contatos;
        }
    }
}
