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

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Retorna os dados de um usuário pelo CPF.
        /// </summary>
        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<UserDto>> GetByCPF(string cpf)
        {
            var user = await _service.GetByCPFAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário.
        /// </summary>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByCPF), new { cpf = dto.CPF }, null);
        }

        /// <summary>
        /// Atualiza os dados de um usuário pelo CPF.
        /// </summary>
        [HttpPut("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(string cpf, [FromBody] CreateUserDto dto)
        {
            await _service.UpdateByCPFAsync(cpf, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um usuário pelo CPF.
        /// </summary>
        [HttpDelete("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(string cpf)
        {
            await _service.DeleteByCPFAsync(cpf);
            return NoContent();
        }
    }
}