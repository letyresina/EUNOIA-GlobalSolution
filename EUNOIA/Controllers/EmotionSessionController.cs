using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controller responsável pelos endpoints de sessões de emoção.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class EmotionSessionController : ControllerBase
    {
        private readonly EmotionSessionService _service;

        /// <summary>
        /// Inicializa uma nova instância do <see cref="EmotionSessionController"/> com o serviço de sessões de emoção.
        /// </summary>
        /// <param name="service">Serviço responsável pelas operações de sessão de emoção.</param>
        public EmotionSessionController(EmotionSessionService service)
        {
            _service = service;
        }

        /// <summary>
        /// Retorna todas as sessões de emoção.
        /// </summary>
        /// <returns>Lista de <see cref="EmotionSessionDto"/> contendo os dados das sessões.</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<EmotionSessionDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmotionSessionDto>>> GetAll()
        {
            var sessions = await _service.GetAllAsync();
            return Ok(sessions);
        }

        /// <summary>
        /// Retorna as sessões de emoção de um usuário específico.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Lista de <see cref="EmotionSessionDto"/> relacionadas ao usuário informado.</returns>
        [HttpGet("user/{userId}")]
        [ProducesResponseType(typeof(List<EmotionSessionDto>), StatusCodes.Status200OK)]
        public async Task<ActionResult<List<EmotionSessionDto>>> GetByUserId(int userId)
        {
            var sessions = await _service.GetByUserIdAsync(userId);
            return Ok(sessions);
        }

        /// <summary>
        /// Cria uma nova sessão de emoção.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateEmotionSessionDto"/> contendo os dados da sessão a ser criada.</param>
        /// <returns>Resposta HTTP 201 Created.</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateEmotionSessionDto dto)
        {
            await _service.AddAsync(dto);
            return Created(string.Empty, null);
        }
    }
}