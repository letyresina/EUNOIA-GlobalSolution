using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de emoções detectadas.
    /// </summary>
    [ApiController]
    [Authorize] 
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class EmotionController : ControllerBase
    {
        private readonly EmotionService _service;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="EmotionController"/> com o serviço de emoções.
        /// </summary>
        /// <param name="service">Serviço responsável pelas operações de emoções detectadas.</param>
        public EmotionController(EmotionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as emoções cadastradas.
        /// </summary>
        /// <returns>Lista de <see cref="EmotionDto"/> contendo os dados das emoções detectadas.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<EmotionDto>), StatusCodes.Status200OK)]   // sucesso
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                  // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                     // token sem permissão
        public async Task<ActionResult<List<EmotionDto>>> GetAll()
        {
            var emotions = await _service.GetAllAsync();
            return Ok(emotions);
        }

        /// <summary>
        /// Retorna as emoções de uma sessão específica.
        /// </summary>
        /// <param name="sessionId">Identificador da sessão de emoção.</param>
        /// <returns>Lista de <see cref="EmotionDto"/> associadas à sessão informada.</returns>
        [HttpGet("session/{sessionId}")]
        [ProducesResponseType(typeof(List<EmotionDto>), StatusCodes.Status200OK)]   // sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]                       // sessão não encontrada
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                   // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                      // token sem permissão
        public async Task<ActionResult<List<EmotionDto>>> GetBySessionId(int sessionId)
        {
            var emotions = await _service.GetBySessionIdAsync(sessionId);
            if (emotions == null || !emotions.Any())
                return NotFound();

            return Ok(emotions);
        }

        /// <summary>
        /// Cria uma nova emoção.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateEmotionDto"/> contendo os dados da emoção a ser registrada.</param>
        /// <returns>Resposta HTTP 201 Created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]                        // criado com sucesso
        [ProducesResponseType(StatusCodes.Status400BadRequest)]                     // dados inválidos
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]                   // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]                      // token sem permissão
        public async Task<IActionResult> Create([FromBody] CreateEmotionDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.AddAsync(dto);
            return Created(string.Empty, null);
        }
    }
}