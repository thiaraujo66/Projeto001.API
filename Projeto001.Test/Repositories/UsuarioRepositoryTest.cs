using Projeto001.Application.Services;
using Projeto001.Domain.Entities;
using Projeto001.Infraestrutura.Repositories;

namespace Projeto001.Test.Repositories
{
    public class UsuarioRepositoryTest : IClassFixture<DatabaseFixture>
    {
        #region [ Constantes ]

        private readonly DatabaseFixture _fixture;

        #endregion

        #region [ Construtores ]

        public UsuarioRepositoryTest(DatabaseFixture fixture)
        {
            _fixture = fixture;
        }

        #endregion

        #region [ Testes ]

        [Fact]
        public async Task BuscarPorId_DeveRetornarUsuario()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new UsuarioRepository(context);
                var usuarioService = new UsuarioService(repository);

                var usuarioId = 1;

                var resultado = await usuarioService.ConsultaPorId(usuarioId);

                Assert.NotNull(resultado);
                Assert.Equal(usuarioId, resultado.Id);
            }
        }

        [Fact]
        public async Task AtualizarUsuario_DeveAtualizarUsuario()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new UsuarioRepository(context);
                var usuarioService = new UsuarioService(repository);

                Usuario usuario = new Usuario()
                {
                    Username = "TesteUnitario",
                    Senha = "wkuWmW3Uq8",
                    Permissao = 1,
                    IdPessoa = 1,
                };

                var resultado = await usuarioService.CriarUsuario(usuario);

                Assert.NotNull(resultado);

                resultado.Username = "TesteUnitario2";

                var retorno = await usuarioService.AtualizarUsuario(resultado);

                Assert.True(retorno);

                var compara = await usuarioService.ConsultaPorId(resultado.Id);

                Assert.Equal("TESTEUNITARIO2", compara.Username);
            }
        }

        [Fact]
        public async Task AtualizarUsuario_DeveRetornarFalseSeNaoExistir()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new UsuarioRepository(context);
                var usuarioService = new UsuarioService(repository);

                Usuario usuario = new Usuario()
                {
                    Id = 1951233219
                };

                var resultado = await usuarioService.AtualizarUsuario(usuario);

                Assert.False(resultado);
            }
        }

        [Fact]
        public async Task CriarUsuario_DeveCriarUsuario()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new UsuarioRepository(context);
                var usuarioService = new UsuarioService(repository);

                Usuario usuario = new Usuario()
                {
                    Username = "TesteUnitario",
                    Senha = "wkuWmW3Uq8",
                    Permissao = 1,
                    IdPessoa = 1,
                };

                var resultado = await usuarioService.CriarUsuario(usuario);

                Assert.NotNull(resultado);
                Assert.True(resultado.Id > 0, $"Esperado que Id > 0, mas foi {resultado.Id}");
            }
        }

        [Fact]
        public async Task DeletarUsuario_DeveDeletarUsuario()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new UsuarioRepository(context);
                var usuarioService = new UsuarioService(repository);

                Usuario usuario = new Usuario()
                {
                    Username = "TesteUnitario",
                    Senha = "wkuWmW3Uq8",
                    Permissao = 1,
                    IdPessoa = 1,
                };

                var resultado = await usuarioService.CriarUsuario(usuario);

                var retorno = await usuarioService.DeletarUsuario(resultado.Id);

                Assert.True(retorno);
            }
        }

        [Fact]
        public async Task ListaUsuariosPorPessoa_DeveRetornarUsuarios()
        {
            using (var context = _fixture.CreateContext())
            {
                var repository = new UsuarioRepository(context);
                var usuarioService = new UsuarioService(repository);

                var result = await usuarioService.ListarUsuarios();

                Assert.NotEmpty(result);
            }
        }

        #endregion
    }
}
