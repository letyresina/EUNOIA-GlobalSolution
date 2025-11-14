using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly UserService _service;

        public UserController(UserService service)
        {
            _service = service;
        }

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
        public async Task<ActionResult<UserDto>> GetByCPF(string cpf)
        {
            var user = await _service.GetByCPFAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByCPF), new { cpf = dto.CPF }, null);
        }

        [HttpPut("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string cpf, [FromBody] CreateUserDto dto)
        {
            await _service.UpdateByCPFAsync(cpf, dto);
            return NoContent();
        }

        [HttpDelete("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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