using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    [Authorize]
    /// <summary>
    /// Controlador responsável por gerenciar operações relacionadas a usuários.
    /// </summary>
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UserController"/>.
        /// </summary>
        /// <param name="service">Serviço responsável pelas operações de usuário.</param>
        public UserController(UserService service) => _service = service;

        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        /// <summary>
        /// Retorna os dados do usuário correspondente ao CPF informado.
        /// </summary>
        /// <param name="cpf">CPF do usuário a ser consultado.</param>
        /// <returns>Os dados do usuário, caso encontrado; caso contrário, NotFound.</returns>
        public async Task<ActionResult<UserDto>> GetByCPF(string cpf)
        {
            var user = await _service.GetByCPFAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        /// <summary>
        /// Cria um novo usuário com os dados fornecidos.
        /// </summary>
        /// <param name="dto">Objeto contendo os dados do usuário a ser criado.</param>
        /// <returns>Retorna 201 Created se o usuário for criado com sucesso, ou 400 Bad Request em caso de erro.</returns>
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByCPF), new { cpf = dto.CPF }, null);
        }

        [HttpPut("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        /// <summary>
        /// Atualiza os dados de um usuário existente identificado pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário a ser atualizado.</param>
        /// <param name="dto">Objeto contendo os novos dados do usuário.</param>
        /// <returns>Retorna 204 No Content se a atualização for bem-sucedida, 404 Not Found se o usuário não for encontrado, ou 400 Bad Request em caso de erro.</returns>
        public async Task<IActionResult> Update(string cpf, [FromBody] CreateUserDto dto)
        {
            await _service.UpdateByCPFAsync(cpf, dto);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        /// <summary>
        /// Remove um usuário identificado pelo CPF.
        /// </summary>
        /// <param name="cpf">CPF do usuário a ser removido.</param>
        /// <returns>Retorna 204 No Content se a exclusão for bem-sucedida, ou 404 Not Found se o usuário não for encontrado.</returns>
        public async Task<IActionResult> Delete(string cpf)
        {
            await _service.DeleteByCPFAsync(cpf);
            return NoContent();
        }

        /// <summary>
        /// Retorna os dados do usuário junto com a empresa vinculada.
        /// </summary>
        [HttpGet("{cpf}/with-company")]
        [ProducesResponseType(typeof(UserWithCompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserWithCompanyDto>> GetByCPFWithCompany(string cpf)
        {
            var user = await _service.GetByCPFWithCompanyAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Autentica um usuário pelo CPF e senha.
        /// </summary>
        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var isAuthenticated = await _service.AuthenticateAsync(dto);
            if (!isAuthenticated) return Unauthorized("CPF ou senha inválidos.");

            return Ok("Login realizado com sucesso.");
        }

        /// <summary>
        /// Retorna os dados do usuário juntamente com as configurações de privacidade vinculadas ao CPF informado.
        /// </summary>
        /// <param name="cpf">CPF do usuário a ser consultado.</param>
        /// <returns>Os dados do usuário com configurações de privacidade, caso encontrado; caso contrário, NotFound.</returns>
        [HttpGet("{cpf}/with-privacy-setting")]
        [ProducesResponseType(typeof(UserWithPrivacySettingDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserWithPrivacySettingDto>> GetByCPFWithPrivacySetting(string cpf)
        {
            var user = await _service.GetByCPFWithPrivacySettingAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }

}