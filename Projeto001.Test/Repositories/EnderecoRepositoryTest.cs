using Projeto001.Application.Services;
using Projeto001.Domain.Entities;
using Projeto001.Infraestrutura.Repositories;

namespace Projeto001.Test.Repositories
{
    public class EnderecoRepositoryTest : IClassFixture<DatabaseFixture>
    {
        #region [ Constantes ]

        private readonly DatabaseFixture _fixture;

        #endregion

        #region [ Construtores ]

        public EnderecoRepositoryTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region [ Testes ]

        [Fact]
        public async Task BuscarPorId_DeveRetornarEndereco()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new EnderecoRepository(context);
                var enderecoService = new EnderecoService(repository);

                var enderecoId = 1;

                var resultado = await enderecoService.ConsultaPorId(enderecoId);

                Assert.NotNull(resultado);
                Assert.Equal(enderecoId, resultado.Id);
            }
        }

        [Fact]
        public async Task AtualizarEndereco_DeveAtualizarEndereco()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new EnderecoRepository(context);
                var enderecoService = new EnderecoService(repository);

                Endereco endereco = new Endereco()
                {
                    Cep = "41635-390",
                    Logradouro = "Rua Beijupirá",
                    Numero = "882",
                    Bairro = "Itapuã",
                    Cidade = "Salvador",
                    Uf = "BA",
                    IdPessoa = 1,
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await enderecoService.CriarEndereco(endereco);

                Assert.NotNull(resultado);

                resultado.Complemento = "Teste";

                var retorno = await enderecoService.AtualizarEndereco(resultado, 1);

                Assert.True(retorno);

                var compara = await enderecoService.ConsultaPorId(resultado.Id);

                Assert.Equal("Teste", compara.Complemento);
            }
        }

        [Fact]
        public async Task AtualizarEndereco_DeveRetornarFalseSeNaoExistir()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new EnderecoRepository(context);
                var enderecoService = new EnderecoService(repository);

                Endereco endereco = new Endereco()
                {
                    Id = 1951233219
                };

                var resultado = await enderecoService.AtualizarEndereco(endereco, 1);

                Assert.False(resultado);
            }
        }

        [Fact]
        public async Task CriarEndereco_DeveCriarEndereco()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new EnderecoRepository(context);
                var enderecoService = new EnderecoService(repository);

                Endereco endereco = new Endereco()
                {
                    Cep = "41635-390",
                    Logradouro = "Rua Beijupirá",
                    Numero = "882",
                    Bairro = "Itapuã",
                    Cidade = "Salvador",
                    Uf = "BA",
                    IdPessoa = 1,
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await enderecoService.CriarEndereco(endereco);

                Assert.NotNull(resultado);
                Assert.True(resultado.Id > 0, $"Esperado que Id > 0, mas foi {resultado.Id}");
            }
        }

        [Fact]
        public async Task DeletarEndereco_DeveDeletarEndereco()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new EnderecoRepository(context);
                var enderecoService = new EnderecoService(repository);

                Endereco endereco = new Endereco()
                {
                    Cep = "41635-390",
                    Logradouro = "Rua Beijupirá",
                    Numero = "882",
                    Bairro = "Itapuã",
                    Cidade = "Salvador",
                    Uf = "BA",
                    IdPessoa = 1,
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await enderecoService.CriarEndereco(endereco);

                var retorno = await enderecoService.DeletarEndereco(resultado.Id);

                Assert.True(retorno);
            }
        }

        [Fact]
        public async Task ListaEnderecosPorPessoa_DeveRetornarEnderecos()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new EnderecoRepository(context);
                var enderecoService = new EnderecoService(repository);

                var result = await enderecoService.ListaEnderecosPorPessoa(1);

                Assert.NotEmpty(result);
            }
        }

        #endregion
    }
}
