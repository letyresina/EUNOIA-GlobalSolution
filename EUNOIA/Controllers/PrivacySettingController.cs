using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class PrivacySettingController : ControllerBase
    {
        private readonly PrivacySettingService _service;

        public PrivacySettingController(PrivacySettingService service)
        {
            _service = service;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<PrivacySettingDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<PrivacySettingDto>>> GetAll()
        {
            var settings = await _service.GetAllAsync();
            return Ok(settings);
        }

        [HttpGet("{userId}/with-user")]
        [ProducesResponseType(typeof(PrivacySettingWithUserDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<PrivacySettingWithUserDto>> GetByUserIdWithUser(int userId)
        {
            var setting = await _service.GetByUserIdWithUserAsync(userId);
            if (setting == null) return NotFound();
            return Ok(setting);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreatePrivacySettingDto dto)
        {
            await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetByUserIdWithUser), new { userId = dto.UserId }, null);
        }

        [HttpPut("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Update(int userId, [FromBody] CreatePrivacySettingDto dto)
        {
            await _service.UpdateAsync(userId, dto);
            return NoContent();
        }

        [HttpDelete("{userId}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Delete(int userId)
        {
            await _service.DeleteByUserIdAsync(userId);
            return NoContent();
        }
    }
}