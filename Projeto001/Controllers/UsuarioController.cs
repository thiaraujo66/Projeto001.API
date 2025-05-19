using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Services;
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

        [HttpPost("Login")]
        public async Task<ActionResult<BaseRespose<LoginResponse>>> Login(LoginModel model)
        {
            try
            {
                Usuario usuario = await _usuarioService.Login(model.Username, model.Senha);

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

        #endregion

    }
}
