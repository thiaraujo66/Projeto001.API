using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Projeto001.Domain.Entities;
using Projeto001.Domain.Interfaces.Services;
using Projeto001.Models.Request.UsuarioRequest;

namespace Projeto001.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : Controller
    {
        #region [ Constantes ]

        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        #endregion

        #region [ Construtores ]

        public TokenController(ITokenService tokenService, IMapper mapper)
        {
            _tokenService = tokenService;
            _mapper = mapper;
        }

        #endregion

        #region [ Métodos Públicos ]

        [HttpPost]
        public async Task<IActionResult> Post(LoginModel model)
        {
            Usuario usuario = _mapper.Map<Usuario>(model);

            string token = await _tokenService.GetToken(usuario);

            if (!string.IsNullOrWhiteSpace(token))
                return Ok(token);

            return Unauthorized();
        }

        #endregion
    }
}
