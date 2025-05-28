using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Enums;
using Projeto001.Domain.Interfaces.Services;
using Projeto001.Models.Request;
using Projeto001.Models.Request.UsuarioRequest;
using Projeto001.Models.Response;
using Projeto001.Models.Response.UsuarioResponse;

namespace Projeto001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {
        #region [ Constantes ]

        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        #endregion

        #region [ Construtores ]

        public UsuarioController(IUsuarioService usuarioService, IMapper mapper)
        {
            _mapper = mapper;
            _usuarioService = usuarioService;
        }

        #endregion

        #region [ Métodos Públicos ]

        [HttpGet("Listar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)},{nameof(TipoPermissaoSistema.Funcionario)}")]
        public async Task<ActionResult<BaseRespose<IEnumerable<ListaUsuarioResponse>>>> ListarUsuario()
        {
            try
            {
                IEnumerable<Usuario> usu = await _usuarioService.ListarUsuarios();

                IEnumerable<ListaUsuarioResponse> retorno = _mapper.Map<IEnumerable<ListaUsuarioResponse>>(usu);

                var response = new BaseRespose<IEnumerable<ListaUsuarioResponse>>() { Sucesso = true, Mensagem = "Lista de Usuários", Data = retorno };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<IEnumerable<ListaUsuarioResponse>>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = null };

                return BadRequest(exception);
            }
        }

        [HttpPost("Login")]
        public async Task<ActionResult<BaseRespose<LoginResponse>>> Login(LoginModel model)
        {
            try
            {
                Usuario? usuario = await _usuarioService.Login(model.Username, model.Senha);

                if (usuario is null)
                    return BadRequest(new BaseRespose<LoginResponse>() { Sucesso = false, Mensagem = "Usuário e senha incorretos.", Data = null });

                LoginResponse response = _mapper.Map<LoginResponse>(usuario);

                var retorno = new BaseRespose<LoginResponse>() { Sucesso = true, Mensagem = "", Data = response };

                return Ok(retorno);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<LoginResponse>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = null };

                return BadRequest(exception);
            }
        }

        [HttpPost("CriarUsuario")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> CriarUsuario(CriarUsuarioModel model) 
        {
            try
            {
                Usuario usuario = _mapper.Map<Usuario>(model);

                Usuario usu = await _usuarioService.CriarUsuario(usuario);

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Usuário criado com sucesso!", Data = true };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<bool>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = false };

                return BadRequest(exception);
            }
        }

        [HttpPost("AlterarSenha")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> AlterarSenha(AlterarSenhaModel model) 
        {
            try
            {
                Usuario? usuario;

                usuario = await _usuarioService.Login(model.Username, model.Senha);

                if (usuario == null)
                {
                    var usuarioNaoEncontrado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Senha atual incorreta.", Data = false };

                    return BadRequest(usuarioNaoEncontrado);
                }

                usuario.Senha = model.NovaSenha;

                bool retorno = await _usuarioService.AtualizarUsuario(usuario);

                if (retorno)
                {
                    var senhaNaoAtualizada = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Não foi possível alterar a senha.", Data = false };

                    return BadRequest(senhaNaoAtualizada);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Senha alterada com sucesso!", Data = true };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<bool>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = false };

                return BadRequest(exception);
            }
        }

        [HttpPost("Alterar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> AlterarUsuario(AlterarUsuario model) 
        {
            try
            {
                Usuario usu = _mapper.Map<Usuario>(model);

                bool retorno = await _usuarioService.AtualizarUsuario(usu);

                if (retorno)
                {
                    var usuarioNaoAtualizado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Usuário não atualizado.", Data = false };

                    return BadRequest(usuarioNaoAtualizado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Usuário atualizado com sucesso!", Data = true };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<bool>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = false };

                return BadRequest(exception);
            }
        }

        [HttpPost("Deletar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> DeletarUsuario(DeletarUsuarioModel model) 
        {
            try
            {
                var retorno = await _usuarioService.DeletarUsuario(model.Id);

                if (retorno)
                {
                    var usuarioNaoAtualizado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Usuário não encontrado.", Data = false };

                    return BadRequest(usuarioNaoAtualizado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Usuário exclúido com sucesso!", Data = true };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<bool>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = false };

                return BadRequest(exception);
            }
        }

        [HttpPost("Consultar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<ConsultaUsuarioResponse>>> ConsultarUsuario(BaseRequest model)
        {
            try
            {
                Usuario? retorno = await _usuarioService.ConsultaPorId(model.Id);

                if (retorno is null) 
                {
                    return BadRequest(new BaseRespose<ConsultaUsuarioResponse>() { Sucesso = false, Mensagem = "Usuário não encontrado", Data = null });
                }

                ConsultaUsuarioResponse consultaUsuario = _mapper.Map<ConsultaUsuarioResponse>(retorno);

                var response = new BaseRespose<ConsultaUsuarioResponse>() { Sucesso = true, Mensagem = "Consulta de usuário realizada com sucesso!", Data = consultaUsuario };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<bool>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = false };

                return BadRequest(exception);
            }
        }

        #endregion

    }
}
