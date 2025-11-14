using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controlador responsável por gerenciar as configurações de privacidade dos usuários.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PrivacySettingController(PrivacySettingService service) : ControllerBase
    {
        private readonly PrivacySettingService _service = service;

        /// <summary>
        /// Obtém todas as configurações de privacidade.
        /// </summary>
        /// <returns>Lista de configurações de privacidade.</returns>
        public async Task<ActionResult<List<PrivacySettingDto>>> GetAll()
        {
            var settings = await _service.GetAllAsync();
            return Ok(settings);
        }

        /// <summary>
        /// Obtém a configuração de privacidade de um usuário, incluindo informações do usuário.
        /// </summary>
        /// <param name="userId">ID do usuário.</param>
        /// <returns>Configuração de privacidade com informações do usuário.</returns>
        public async Task<ActionResult<PrivacySettingWithUserDto>> GetByUserIdWithUser(int userId)
        {
            var setting = await _service.GetByUserIdWithUserAsync(userId);
            if (setting == null) return NotFound();
            return Ok(setting);
        }

        /// <summary>
        /// Cria uma nova configuração de privacidade para um usuário.
        /// </summary>
        /// <param name="dto">Dados para criação da configuração de privacidade.</param>
        /// <returns>Status de criação.</returns>
        public async Task<IActionResult> Create([FromBody] CreatePrivacySettingDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByUserIdWithUser), new { userId = dto.UserId }, null);
        }

        /// <summary>
        /// Atualiza a configuração de privacidade de um usuário.
        /// </summary>
        /// <param name="userId">ID do usuário.</param>
        /// <param name="dto">Dados para atualização da configuração de privacidade.</param>
        /// <returns>Status de atualização.</returns>
        public async Task<IActionResult> Update(int userId, [FromBody] CreatePrivacySettingDto dto)
        {
            await _service.UpdateAsync(userId, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove a configuração de privacidade de um usuário.
        /// </summary>
        /// <param name="userId">ID do usuário.</param>
        /// <returns>Status de remoção.</returns>
        public async Task<IActionResult> Delete(int userId)
        {
            await _service.DeleteByUserIdAsync(userId);
            return NoContent();
        }
    }
}