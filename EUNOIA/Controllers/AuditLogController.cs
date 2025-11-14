using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de logs de auditoria.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class AuditLogController : ControllerBase
    {
        private readonly AuditLogService _service;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="AuditLogController"/> com o serviço de auditoria.
        /// </summary>
        /// <param name="service">Serviço responsável pelas operações de log de auditoria.</param>
        public AuditLogController(AuditLogService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os logs de auditoria registrados no sistema.
        /// </summary>
        /// <returns>Lista de <see cref="AuditLogDto"/>.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<AuditLogDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AuditLogDto>>> GetAll()
        {
            var logs = await _service.GetAllAsync();
            return Ok(logs);
        }

        /// <summary>
        /// Retorna os logs de auditoria associados a um usuário específico.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Lista de <see cref="AuditLogDto"/> relacionados ao usuário.</returns>
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<AuditLogDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<AuditLogDto>>> GetByUserId(int userId)
        {
            var logs = await _service.GetByUserIdAsync(userId);
            return Ok(logs);
        }

        /// <summary>
        /// Cria um novo log de auditoria.
        /// </summary>
        /// <param name="dto">Dados do log a ser criado.</param>
        /// <returns>Resposta HTTP 201 Created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateAuditLogDto dto)
        {
            await _service.AddAsync(dto);
            return Created(string.Empty, null);
        }
    }
}