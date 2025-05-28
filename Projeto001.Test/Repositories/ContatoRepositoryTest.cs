using Projeto001.Application.Services;
using Projeto001.Domain.Entities;
using Projeto001.Infraestrutura.Repositories;

namespace Projeto001.Test.Repositories
{
    public class ContatoRepositoryTest : IClassFixture<DatabaseFixture>
    {
        #region [ Constantes ]

        private readonly DatabaseFixture _fixture;

        #endregion

        #region [ Construtores ]

        public ContatoRepositoryTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region [ Testes ]

        [Fact]
        public async Task BuscarPorId_DeveRetornarContato() 
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new ContatoRepository(context);
                var contatoService = new ContatoService(repository);

                var contatoId = 1;

                var resultado = await contatoService.ConsultaPorId(contatoId);

                Assert.NotNull(resultado);
                Assert.Equal(contatoId, resultado.Id);
            }
        }

        [Fact]
        public async Task AtualizarContato_DeveAtualizarContato()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new ContatoRepository(context);
                var contatoService = new ContatoService(repository);

                var contatoId = 1;

                var contato = await contatoService.ConsultaPorId(contatoId);

                Assert.NotNull(contato);

                contato.Tipo = 6;

                var retorno = await contatoService.AtualizarContato(contato, 1);

                Assert.True(retorno);

                var resultado = await contatoService.ConsultaPorId(contatoId);

                Assert.Equal(resultado.Tipo, 6);
            }
        }

        [Fact]
        public async Task AtualizarContato_DeveRetornarFalseSeNaoExistir()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new ContatoRepository(context);
                var contatoService = new ContatoService(repository);

                Contato contato = new Contato() 
                {
                    Id = 1951233219
                };

                var resultado = await contatoService.AtualizarContato(contato, 1);

                Assert.False(resultado);
            }
        }

        [Fact]
        public async Task CriarContato_DeveCriarContato()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new ContatoRepository(context);
                var contatoService = new ContatoService(repository);

                Contato contato = new Contato() 
                {
                    Conteudo = "(71) 3576-6491",
                    Tipo = 2,
                    IdPessoa = 1,
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await contatoService.CriarContato(contato);

                Assert.NotNull(resultado); 
                Assert.True(resultado.Id > 0, $"Esperado que Id > 0, mas foi {resultado.Id}");
            }
        }

        [Fact]
        public async Task DeletarContato_DeveDeletarContato()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new ContatoRepository(context);
                var contatoService = new ContatoService(repository);

                Contato contato = new Contato()
                {
                    Conteudo = "(71) 3576-6491",
                    Tipo = 2,
                    IdPessoa = 1,
                    DataCadastro = DateTime.Now,
                    UsuarioCadastro = 1
                };

                var resultado = await contatoService.CriarContato(contato);

                var retorno = await contatoService.DeletarContato(resultado.Id);

                Assert.True(retorno);
            }
        }

        [Fact]
        public async Task ListaContatosPorPessoa_DeveRetornarContatos()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new ContatoRepository(context);
                var contatoService = new ContatoService(repository);

                var result = await contatoService.ListaContatosPorPessoa(1);

                Assert.NotEmpty(result);
            }
        }

        #endregion
    }
}
