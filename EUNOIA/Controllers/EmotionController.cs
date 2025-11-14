using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de emoções detectadas.
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
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
        [ProducesResponseType(typeof(List<EmotionDto>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(typeof(List<EmotionDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmotionDto>>> GetBySessionId(int sessionId)
        {
            var emotions = await _service.GetBySessionIdAsync(sessionId);
            return Ok(emotions);
        }

        /// <summary>
        /// Cria uma nova emoção.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateEmotionDto"/> contendo os dados da emoção a ser registrada.</param>
        /// <returns>Resposta HTTP 201 Created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateEmotionDto dto)
        {
            await _service.AddAsync(dto);
            return Created(string.Empty, null);
        }
    }
}