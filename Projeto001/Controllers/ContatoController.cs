using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Enums;
using Projeto001.Domain.Interfaces.Services;
using Projeto001.Models.Request;
using Projeto001.Models.Request.ContatoRequest;
using Projeto001.Models.Response;
using Projeto001.Models.Response.ContatoResponse;
using System.Security.Claims;

namespace Projeto001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContatoController : Controller
    {
        #region [ Constantes ]

        private readonly IContatoService _contatoService;
        private readonly IMapper _mapper;

        #endregion

        #region [ Construtores ]

        public ContatoController(IContatoService contatoService, IMapper mapper)
        {
            _mapper = mapper;
            _contatoService = contatoService;
        }

        #endregion

        #region [ Métodos Públicos ]

        [HttpPost("Listar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)},{nameof(TipoPermissaoSistema.Funcionario)}")]
        public async Task<ActionResult<BaseRespose<IEnumerable<ListarContatosResponse>>>> ListarContato(ListarContatoRequest model)
        {
            try
            {
                IEnumerable<Contato> ctt = await _contatoService.ListaContatosPorPessoa(model.IdPessoa);

                IEnumerable<ListarContatosResponse> retorno = _mapper.Map<IEnumerable<ListarContatosResponse>>(ctt);

                var response = new BaseRespose<IEnumerable<ListarContatosResponse>>() { Sucesso = true, Mensagem = "Lista de Contatos", Data = retorno };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<IEnumerable<ListarContatosResponse>>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = null };

                return BadRequest(exception);
            }
        }

        [HttpPost("Criar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> CriarContato(CriarContatoRequest model)
        {
            try
            {
                var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                Contato novoContato = _mapper.Map<Contato>(model);

                novoContato.DataCadastro = DateTime.Now;
                novoContato.UsuarioCadastro = Convert.ToInt32(usuarioId);

                var retorno = await _contatoService.CriarContato(novoContato);

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Contato Criado com sucesso", Data = true };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<bool>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = false };

                return BadRequest(exception);
            }
        }

        [HttpPost("Atualizar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> AtualizarContato(AtualizarContatoRequest model) 
        {
            try
            {
                var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                Contato ctt = _mapper.Map<Contato>(model);

                var retorno = await _contatoService.AtualizarContato(ctt, Convert.ToInt32(usuarioId));

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Contato atualizado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> DeletarContato(DeletarContatoRequest model) 
        {
            try
            {
                var retorno = await _contatoService.DeletarContato(model.Id);

                if (retorno) 
                {
                    var contatoNaoEncontrado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Contato não encontrado.", Data = false };

                    return BadRequest(contatoNaoEncontrado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Contato atualizado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> ConsultarContato(BaseRequest model)
        {
            try
            {
                Contato? contato = await _contatoService.ConsultaPorId(model.Id);

                if (contato is null)
                {
                    var contatoNaoEncontrado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Contato não encontrado.", Data = true };

                    return BadRequest(contatoNaoEncontrado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Contato atualizado com sucesso", Data = true };

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
