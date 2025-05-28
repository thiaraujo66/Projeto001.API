using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Repositories;
using Projeto001.Domain.Interfaces.Services;

namespace Projeto001.Application.Services
{
    public class PessoaService : IPessoaService
    {
        private IPessoaRepository _pessoaRepository;

        public PessoaService(IPessoaRepository pessoaRepository)
        {
            _pessoaRepository = pessoaRepository;
        }

        public async Task<bool> AtualizarPessoa(Pessoa pPessoa, int pUsuario)
        {
            Pessoa? pessoa = await _pessoaRepository.ConsultaPorId(pPessoa.Id);

            if (pessoa is null)
                return false;

            pessoa.Nome = string.IsNullOrEmpty(pPessoa.Nome) ? pessoa.Nome : pPessoa.Nome;
            pessoa.Cgc = string.IsNullOrWhiteSpace(pPessoa.Cgc) ? pessoa.Cgc : pPessoa.Cgc;
            pessoa.DataNascimento = pPessoa.DataNascimento == DateTime.MinValue ? pessoa.DataNascimento : pPessoa.DataNascimento;
            pessoa.Email = string.IsNullOrEmpty(pPessoa.Email) ? pessoa.Email : pPessoa.Email;
            pessoa.Genero = string.IsNullOrEmpty(pPessoa.Genero) ? pessoa.Genero : pPessoa.Genero;
            pessoa.Pai = string.IsNullOrEmpty(pPessoa.Pai) ? pessoa.Pai : pPessoa.Pai;
            pessoa.Mae = string.IsNullOrEmpty(pPessoa.Mae) ? pessoa.Mae : pPessoa.Mae;
            pessoa.Rg = string.IsNullOrEmpty(pPessoa.Rg) ? pessoa.Rg : pPessoa.Rg;
            pessoa.UsuarioAlteracao = pUsuario;
            pessoa.DataAlteracao = DateTime.Now;

            await _pessoaRepository.AtualizarPessoa(pessoa);

            return true;
        }

        public async Task<Pessoa> ConsultaPorCgc(string pCgc)
        {
            Pessoa? pessoa = await _pessoaRepository.ConsultaPorCgc(pCgc);

            return pessoa;
        }

        public async Task<Pessoa?> ConsultaPorId(int pId)
        {
            Pessoa? pessoa = await _pessoaRepository.ConsultaPorId(pId);

            return pessoa;
        }

        public async Task<Pessoa> CriarPessoa(Pessoa pPessoa)
        {
            await _pessoaRepository.CriarPessoa(pPessoa);

            return pPessoa;
        }

        public async Task<bool> DeletarPessoa(int pId)
        {
            Pessoa? pessoa = await _pessoaRepository.ConsultaPorId(pId);

            if (pessoa is null)
                return false;

            await _pessoaRepository.DeletarPessoa(pessoa);

            return true;
        }

        public async Task<IEnumerable<Pessoa>> ListaPessoas()
        {
            IEnumerable<Pessoa> pessoas = await _pessoaRepository.ListaPessoas();

            return pessoas;
        }
    }
}
