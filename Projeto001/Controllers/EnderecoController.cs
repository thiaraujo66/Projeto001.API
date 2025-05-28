using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Enums;
using Projeto001.Domain.Interfaces.Services;
using Projeto001.Models.Request;
using Projeto001.Models.Request.EnderecoRequest;
using Projeto001.Models.Response;
using Projeto001.Models.Response.EnderecoResponse;
using System.Security.Claims;

namespace Projeto001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : Controller
    {
        #region [ Constantes ]

        private readonly IEnderecoService _enderecoService;
        private readonly IMapper _mapper;

        #endregion

        #region [ Construtores ]

        public EnderecoController(IEnderecoService enderecoService, IMapper mapper)
        {
            _mapper = mapper;
            _enderecoService = enderecoService;
        }

        #endregion

        #region [ Métodos Públicos ]

        [HttpPost("Listar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)},{nameof(TipoPermissaoSistema.Funcionario)}")]
        public async Task<ActionResult<BaseRespose<IEnumerable<ListarEnderecoResponse>>>> ListarEndereco(ListarEnderecoRequest model)
        {
            try
            {
                IEnumerable<Endereco> enderecos = await _enderecoService.ListaEnderecosPorPessoa(model.IdPessoa);

                IEnumerable<ListarEnderecoResponse> retorno = _mapper.Map<IEnumerable<ListarEnderecoResponse>>(enderecos);

                var response = new BaseRespose<IEnumerable<ListarEnderecoResponse>>() { Sucesso = true, Mensagem = "Lista de Enderecos", Data = retorno };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<IEnumerable<ListarEnderecoResponse>>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = null };

                return BadRequest(exception);
            }
        }

        [HttpPost("Criar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> CriarEndereco(CriarEnderecoRequest model)
        {
            try
            {
                var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                Endereco novoEndereco = _mapper.Map<Endereco>(model);

                novoEndereco.DataCadastro = DateTime.Now;
                novoEndereco.UsuarioCadastro = Convert.ToInt32(usuarioId);

                var retorno = await _enderecoService.CriarEndereco(novoEndereco);

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Endereco Criado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> AtualizarEndereco(AtualizarEnderecoRequest model)
        {
            try
            {
                var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                Endereco endereco = _mapper.Map<Endereco>(model);

                var retorno = await _enderecoService.AtualizarEndereco(endereco, Convert.ToInt32(usuarioId));

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Endereco atualizado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> DeletarEndereco(DeletarEnderecoRequest model)
        {
            try
            {
                var retorno = await _enderecoService.DeletarEndereco(model.Id);

                if (retorno)
                {
                    var enderecoNaoEncontrado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Endereço não encontrado", Data = false };

                    return BadRequest(enderecoNaoEncontrado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Endereco atualizado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> ConsultarEndereco(BaseRequest model)
        {
            try
            {
                Endereco? endereco = await _enderecoService.ConsultaPorId(model.Id);

                if (endereco is null)
                {
                    var enderecoNaoEncontrado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Endereco não encontrado.", Data = true };

                    return BadRequest(enderecoNaoEncontrado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Endereco atualizado com sucesso", Data = true };

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
