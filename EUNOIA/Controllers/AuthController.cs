using EUNOIA.DTOs;
using EUNOIA.Repositories;
using EUNOIA.Security;
using EUNOIA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controller responsável pela autenticação e geração de tokens.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [AllowAnonymous]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly TokenService _tokenService;

        /// <summary>
        /// Controlller de autenticação.
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="tokenService"></param>
        public AuthController(UserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Realiza o login e retorna um token JWT.
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(object), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(object), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(object), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userRepository.GetByCPFAsync(dto.CPF);
            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Credenciais inválidas.");

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token });
        }
    }
}