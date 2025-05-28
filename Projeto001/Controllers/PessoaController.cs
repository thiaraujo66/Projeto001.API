using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Enums;
using Projeto001.Domain.Interfaces.Services;
using Projeto001.Models.Request;
using Projeto001.Models.Request.PessoaRequest;
using Projeto001.Models.Response;
using Projeto001.Models.Response.PessoaResponse;
using System.Security.Claims;

namespace Projeto001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        #region [ Constantes ]

        private readonly IPessoaService _pessoaService;
        private readonly IMapper _mapper;

        #endregion

        #region [ Construtores ]
        public PessoaController(IPessoaService pessoaService, IMapper mapper)
        {
            _mapper = mapper;
            _pessoaService = pessoaService;
        }

        #endregion

        #region [ Métodos Públicos ]

        [HttpGet("Listar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)},{nameof(TipoPermissaoSistema.Funcionario)}")]
        public async Task<ActionResult<BaseRespose<IEnumerable<ListarPessoaResponse>>>> ListarPessoa()
        {
            try
            {
                IEnumerable<Pessoa> pessoas = await _pessoaService.ListaPessoas();

                IEnumerable<ListarPessoaResponse> retorno = _mapper.Map<IEnumerable<ListarPessoaResponse>>(pessoas);

                var response = new BaseRespose<IEnumerable<ListarPessoaResponse>>() { Sucesso = true, Mensagem = "Lista de Pessoas", Data = retorno };

                return Ok(response);
            }
            catch (Exception ex)
            {
                var exception = new BaseRespose<IEnumerable<ListarPessoaResponse>>() { Sucesso = false, Mensagem = string.Format("Erro: {0}", ex.Message), Data = null };

                return BadRequest(exception);
            }
        }

        [HttpPost("Criar")]
        [Authorize(Roles = $"{nameof(TipoPermissaoSistema.Administrador)},{nameof(TipoPermissaoSistema.Supervisor)}")]
        public async Task<ActionResult<BaseRespose<bool>>> CriarPessoa(CriarPessoaRequest model)
        {
            try
            {
                var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                Pessoa novoPessoa = _mapper.Map<Pessoa>(model);

                novoPessoa.DataCadastro = DateTime.Now;
                novoPessoa.UsuarioCadastro = Convert.ToInt32(usuarioId);

                var retorno = await _pessoaService.CriarPessoa(novoPessoa);

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Pessoa Criado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> AtualizarPessoa(AtualizarPessoaRequest model)
        {
            try
            {
                var usuarioId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                Pessoa pessoa = _mapper.Map<Pessoa>(model);

                var retorno = await _pessoaService.AtualizarPessoa(pessoa, Convert.ToInt32(usuarioId));

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Pessoa atualizado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> DeletarPessoa(DeletarPessoaRequest model)
        {
            try
            {
                var retorno = await _pessoaService.DeletarPessoa(model.Id);

                if (retorno)
                {
                    var pessoaNaoEncontrado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Pessoa não encontrado.", Data = true };

                    return BadRequest(pessoaNaoEncontrado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Pessoa atualizado com sucesso", Data = true };

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
        public async Task<ActionResult<BaseRespose<bool>>> ConsultarPessoa(BaseRequest model)
        {
            try
            {
                Pessoa? pessoa = await _pessoaService.ConsultaPorId(model.Id);

                if (pessoa is null)
                {
                    var pessoaNaoEncontrado = new BaseRespose<bool>() { Sucesso = false, Mensagem = "Pessoa não encontrado.", Data = true };

                    return BadRequest(pessoaNaoEncontrado);
                }

                var response = new BaseRespose<bool>() { Sucesso = true, Mensagem = "Pessoa atualizado com sucesso", Data = true };

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
