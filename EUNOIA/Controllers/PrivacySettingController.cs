using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[ApiVersion("2.0")]
[Authorize]
[Route("api/v{version:apiVersion}/[controller]")]
[Produces("application/json")]
public class PrivacySettingController : ControllerBase
{
    private readonly PrivacySettingService _service;

    public PrivacySettingController(PrivacySettingService service)
    {
        _service = service;
    }

    /// <summary>
    /// Obtém todas as configurações de privacidade.
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<List<PrivacySettingDto>>> GetAll()
    {
        var settings = await _service.GetAllAsync();
        return Ok(settings);
    }

    /// <summary>
    /// Obtém a configuração de privacidade de um usuário.
    /// </summary>
    [HttpGet("{userId}")]
    public async Task<ActionResult<PrivacySettingWithUserDto>> GetByUserIdWithUser(int userId)
    {
        var setting = await _service.GetByUserIdWithUserAsync(userId);
        if (setting == null) return NotFound();
        return Ok(setting);
    }

    /// <summary>
    /// Cria uma nova configuração de privacidade.
    /// </summary>
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePrivacySettingDto dto)
    {
        await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetByUserIdWithUser), new { userId = dto.UserId }, null);
    }

    /// <summary>
    /// Atualiza a configuração de privacidade.
    /// </summary>
    [HttpPut("{userId}")]
    public async Task<IActionResult> Update(int userId, [FromBody] CreatePrivacySettingDto dto)
    {
        await _service.UpdateAsync(userId, dto);
        return NoContent();
    }

    /// <summary>
    /// Remove a configuração de privacidade.
    /// </summary>
    [HttpDelete("{userId}")]
    public async Task<IActionResult> Delete(int userId)
    {
        await _service.DeleteByUserIdAsync(userId);
        return NoContent();
    }
}