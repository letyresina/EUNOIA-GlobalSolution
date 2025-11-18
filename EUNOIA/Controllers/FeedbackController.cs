using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de feedbacks.
    /// </summary>
    [ApiController]
    [ApiVersion("2.0")]
    [Authorize] 
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class FeedbackController : ControllerBase
    {
        private readonly FeedbackService _service;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="FeedbackController"/> com o serviço de feedbacks.
        /// </summary>
        /// <param name="service">Serviço responsável pelas operações de feedback.</param>
        public FeedbackController(FeedbackService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todos os feedbacks cadastrados.
        /// </summary>
        /// <returns>Lista de <see cref="FeedbackDto"/> contendo os dados dos feedbacks.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<FeedbackDto>), StatusCodes.Status200OK)]   // sucesso
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                   // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                      // token sem permissão
        public async Task<ActionResult<List<FeedbackDto>>> GetAll()
        {
            var feedbacks = await _service.GetAllAsync();
            return Ok(feedbacks);
        }

        /// <summary>
        /// Retorna os feedbacks de uma sessão específica.
        /// </summary>
        /// <param name="sessionId">Identificador da sessão emocional.</param>
        /// <returns>Lista de <see cref="FeedbackDto"/> associadas à sessão informada.</returns>
        [HttpGet("session/{sessionId}")]
        [ProducesResponseType(typeof(List<FeedbackDto>), StatusCodes.Status200OK)]   // sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]                        // sessão não encontrada
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                    // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                       // token sem permissão
        public async Task<ActionResult<List<FeedbackDto>>> GetBySessionId(int sessionId)
        {
            var feedbacks = await _service.GetBySessionIdAsync(sessionId);
            if (feedbacks == null || !feedbacks.Any())
                return NotFound();

            return Ok(feedbacks);
        }

        /// <summary>
        /// Cria um novo feedback.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateFeedbackDto"/> contendo os dados do feedback a ser criado.</param>
        /// <returns>Resposta HTTP 201 Created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]                         // criado com sucesso
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                      // dados inválidos
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                    // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                       // token sem permissão
        public async Task<IActionResult> Create([FromBody] CreateFeedbackDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(dto);
            return Created(string.Empty, null);
        }
    }
}