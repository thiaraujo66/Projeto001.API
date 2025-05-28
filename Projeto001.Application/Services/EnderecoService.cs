using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Domain.Interfaces.Services;

namespace Projeto001.Application.Services
{
    public class EnderecoService : IEnderecoService
    {
        private IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public async Task<bool> AtualizarEndereco(Endereco pEndereco, int pUsuario)
        {
            Endereco? endereco = await _enderecoRepository.ConsultaPorId(pEndereco.Id);

            if (endereco is null)
                return false;

            endereco.Logradouro = string.IsNullOrWhiteSpace(pEndereco.Logradouro) ? endereco.Logradouro : pEndereco.Logradouro;
            endereco.Bairro = string.IsNullOrWhiteSpace(pEndereco.Bairro) ? endereco.Bairro : pEndereco.Bairro;
            endereco.Numero = string.IsNullOrWhiteSpace(pEndereco.Numero) ? endereco.Numero : pEndereco.Numero;
            endereco.Uf = string.IsNullOrWhiteSpace(pEndereco.Uf) ? endereco.Uf : pEndereco.Uf;
            endereco.Cep = string.IsNullOrWhiteSpace(pEndereco.Cep) ? endereco.Cep : pEndereco.Cep;
            endereco.Complemento = string.IsNullOrWhiteSpace(pEndereco.Complemento) ? endereco.Complemento : pEndereco.Complemento;
            endereco.UsuarioAlteracao = pUsuario;
            endereco.DataAlteracao = DateTime.Now;

            await _enderecoRepository.AtualizarEndereco(endereco);

            return true;
        }

        public async Task<Endereco?> ConsultaPorId(int pId)
        {
            Endereco? endereco = await _enderecoRepository.ConsultaPorId(pId);

            return endereco;
        }

        public async Task<Endereco> CriarEndereco(Endereco pEndereco)
        {
            await _enderecoRepository.CriarEndereco(pEndereco);

            return pEndereco;
        }

        public async Task<bool> DeletarEndereco(int pId)
        {
            Endereco? endereco = await _enderecoRepository.ConsultaPorId(pId);

            if (endereco is null)
                return false;

            await _enderecoRepository.DeletarEndereco(endereco);

            return true;
        }

        public async Task<IEnumerable<Endereco>> ListaEnderecosPorPessoa(int pIdPessoa)
        {
            IEnumerable<Endereco> enderecos = await _enderecoRepository.ListaEnderecosPorPessoa(pIdPessoa);

            return enderecos;
        }
    }
}
