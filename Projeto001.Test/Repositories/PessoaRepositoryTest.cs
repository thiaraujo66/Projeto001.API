using Projeto001.Application.Services;
using Projeto001.Domain.Entities;
using Projeto001.Infraestrutura.Repositories;

namespace Projeto001.Test.Repositories
{
    public class PessoaRepositoryTest : IClassFixture<DatabaseFixture>
    {
        #region [ Constantes ]

        private readonly DatabaseFixture _fixture;

        #endregion

        #region [ Construtores ]

        public PessoaRepositoryTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region [ Testes ]

        [Fact]
        public async Task BuscarPorId_DeveRetornarPessoa()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new PessoaRepository(context);
                var pessoaService = new PessoaService(repository);

                var pessoaId = 1;

                var resultado = await pessoaService.ConsultaPorId(pessoaId);

                Assert.NotNull(resultado);
                Assert.Equal(pessoaId, resultado.Id);
            }
        }

        [Fact]
        public async Task BuscarPorCgc_DeveRetornarPessoa()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new PessoaRepository(context);
                var pessoaService = new PessoaService(repository);

                Pessoa pessoa = new Pessoa()
                {
                    Nome = "Bruna Manuela da Cruz",
                    Cgc = "986.540.195-90",
                    Rg = "37.515.581-8",
                    DataNascimento = Convert.ToDateTime("20/01/1986"),
                    Genero = "F",
                    Mae = "Clarice Sophia",
                    Pai = "Joaquim Emanuel da Cruz",
                    Email = "brunamanueladacruz@bighost.com.br",
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await pessoaService.CriarPessoa(pessoa);

                Assert.NotNull(resultado);

                var retorno = await pessoaService.ConsultaPorCgc(pessoa.Cgc);

                Assert.NotNull(resultado);
                Assert.Equal(pessoa.Cgc, retorno.Cgc);
            }
        }

        [Fact]
        public async Task AtualizarPessoa_DeveAtualizarPessoa()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new PessoaRepository(context);
                var pessoaService = new PessoaService(repository);

                Pessoa pessoa = new Pessoa()
                {
                    Nome = "Bruna Manuela da Cruz",
                    Cgc = "986.540.195-90",
                    Rg = "37.515.581-8",
                    DataNascimento = Convert.ToDateTime("20/01/1986"),
                    Genero = "F",
                    Mae = "Clarice Sophia",
                    Pai = "Joaquim Emanuel da Cruz",
                    Email = "brunamanueladacruz@bighost.com.br",
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await pessoaService.CriarPessoa(pessoa);

                Assert.NotNull(resultado);

                resultado.Mae = "Clarice Sophia da Cruz";

                var retorno = await pessoaService.AtualizarPessoa(resultado, 1);

                Assert.True(retorno);

                var compara = await pessoaService.ConsultaPorId(resultado.Id);

                Assert.Equal("Clarice Sophia da Cruz", compara.Mae);
            }
        }

        [Fact]
        public async Task AtualizarPessoa_DeveRetornarFalseSeNaoExistir()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new PessoaRepository(context);
                var pessoaService = new PessoaService(repository);

                Pessoa pessoa = new Pessoa()
                {
                    Id = 1951233219
                };

                var resultado = await pessoaService.AtualizarPessoa(pessoa, 1);

                Assert.False(resultado);
            }
        }

        [Fact]
        public async Task CriarPessoa_DeveCriarPessoa()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new PessoaRepository(context);
                var pessoaService = new PessoaService(repository);

                Pessoa pessoa = new Pessoa()
                {
                    Nome = "Bruna Manuela da Cruz",
                    Cgc = "986.540.195-90",
                    Rg = "37.515.581-8",
                    DataNascimento = Convert.ToDateTime("20/01/1986"),
                    Genero = "F",
                    Mae = "Clarice Sophia",
                    Pai = "Joaquim Emanuel da Cruz",
                    Email = "brunamanueladacruz@bighost.com.br",
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await pessoaService.CriarPessoa(pessoa);

                Assert.NotNull(resultado);
                Assert.True(resultado.Id > 0, $"Esperado que Id > 0, mas foi {resultado.Id}");
            }
        }

        [Fact]
        public async Task DeletarPessoa_DeveDeletarPessoa()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new PessoaRepository(context);
                var pessoaService = new PessoaService(repository);

                Pessoa pessoa = new Pessoa()
                {
                    Nome = "Bruna Manuela da Cruz",
                    Cgc = "986.540.195-90",
                    Rg = "37.515.581-8",
                    DataNascimento = Convert.ToDateTime("20/01/1986"),
                    Genero = "F",
                    Mae = "Clarice Sophia",
                    Pai = "Joaquim Emanuel da Cruz",
                    Email = "brunamanueladacruz@bighost.com.br",
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await pessoaService.CriarPessoa(pessoa);

                var retorno = await pessoaService.DeletarPessoa(resultado.Id);

                Assert.True(retorno);
            }
        }

        [Fact]
        public async Task ListaPessoasPorPessoa_DeveRetornarPessoas()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new PessoaRepository(context);
                var pessoaService = new PessoaService(repository);

                var result = await pessoaService.ListaPessoas();

                Assert.NotEmpty(result);
            }
        }

        #endregion
    }
}
