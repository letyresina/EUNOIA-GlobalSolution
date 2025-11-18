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
    [Authorize] // ✅ exige autenticação JWT para todos os endpoints, exceto os marcados com [AllowAnonymous]
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

        /// <summary>
        /// Retorna todos os usuários cadastrados.
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(List<UserDto>), StatusCodes.Status200OK)]   // sucesso
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]               // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                  // token sem permissão
        public async Task<ActionResult<List<UserDto>>> GetAll()
        {
            var users = await _service.GetAllAsync();
            return Ok(users);
        }

        /// <summary>
        /// Retorna os dados do usuário correspondente ao CPF informado.
        /// </summary>
        [HttpGet("{cpf}")]
        [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]        // sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]                   // usuário não encontrado
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]               // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                  // token sem permissão
        public async Task<ActionResult<UserDto>> GetByCPF(string cpf)
        {
            var user = await _service.GetByCPFAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Cria um novo usuário com os dados fornecidos.
        /// </summary>
        [HttpPost]
        [AllowAnonymous] // ✅ cadastro de usuário não exige token
        [ProducesResponseType(StatusCodes.Status201Created)]                    // criado com sucesso
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                 // dados inválidos
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]        // erro inesperado
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByCPF), new { cpf = dto.CPF }, null);
        }

        /// <summary>
        /// Atualiza os dados de um usuário existente identificado pelo CPF.
        /// </summary>
        [HttpPut("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]                  // atualizado com sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]                   // usuário não encontrado
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                 // dados inválidos
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]               // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                  // token sem permissão
        public async Task<IActionResult> Update(string cpf, [FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateByCPFAsync(cpf, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove um usuário identificado pelo CPF.
        /// </summary>
        [HttpDelete("{cpf}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]                  // removido com sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]                   // usuário não encontrado
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]               // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                  // token sem permissão
        public async Task<IActionResult> Delete(string cpf)
        {
            await _service.DeleteByCPFAsync(cpf);
            return NoContent();
        }

        /// <summary>
        /// Retorna os dados do usuário junto com a empresa vinculada.
        /// </summary>
        [HttpGet("{cpf}/with-company")]
        [ProducesResponseType(typeof(UserWithCompanyDto), StatusCodes.Status200OK)] // sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]                       // usuário não encontrado
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                   // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                      // token sem permissão
        public async Task<ActionResult<UserWithCompanyDto>> GetByCPFWithCompany(string cpf)
        {
            var user = await _service.GetByCPFWithCompanyAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }

        /// <summary>
        /// Retorna os dados do usuário juntamente com as configurações de privacidade vinculadas ao CPF informado.
        /// </summary>
        [HttpGet("{cpf}/with-privacy-setting")]
        [ProducesResponseType(typeof(UserWithPrivacySettingDto), StatusCodes.Status200OK)] // sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]                              // usuário não encontrado
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                          // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                             // token sem permissão
        public async Task<ActionResult<UserWithPrivacySettingDto>> GetByCPFWithPrivacySetting(string cpf)
        {
            var user = await _service.GetByCPFWithPrivacySettingAsync(cpf);
            if (user == null) return NotFound();
            return Ok(user);
        }
    }
}