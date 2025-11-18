using EUNOIA.DTOs;
using EUNOIA.Repositories;
using EUNOIA.Security;
using EUNOIA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controller responsável pela autenticação e geração de tokens JWT.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [AllowAnonymous] 
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class AuthController : ControllerBase
    {
        private readonly UserRepository _userRepository;
        private readonly TokenService _tokenService;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="AuthController"/>.
        /// </summary>
        /// <param name="userRepository">Repositório de usuários.</param>
        /// <param name="tokenService">Serviço responsável pela geração de tokens JWT.</param>
        public AuthController(UserRepository userRepository, TokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        /// <summary>
        /// Realiza o login e retorna um token JWT.
        /// </summary>
        /// <param name="dto">Credenciais de login (CPF e senha).</param>
        /// <returns>Token JWT válido para autenticação.</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(object), StatusCodes.Status200OK)]            // login bem-sucedido
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                    // requisição malformada (ex: JSON inválido)
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                  // credenciais inválidas
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]           // erro inesperado no servidor
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState); 

            var user = await _userRepository.GetByCPFAsync(dto.CPF);
            if (user == null || !PasswordHasher.VerifyPassword(dto.Password, user.PasswordHash))
                return Unauthorized("Credenciais inválidas."); 

            var token = _tokenService.GenerateToken(user);
            return Ok(new { token }); 
        }
    }
}