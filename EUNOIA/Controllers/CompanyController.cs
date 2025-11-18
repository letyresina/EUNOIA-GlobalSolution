using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas à entidade Empresa.
    /// </summary>
    [ApiController]
    [Authorize] // ✅ exige autenticação JWT para todos os endpoints, exceto os marcados com [AllowAnonymous]
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Produces("application/json")]
    public class CompanyController(CompanyService service) : ControllerBase
    {
        private readonly CompanyService _service = service;

        /// <summary>
        /// Retorna todas as empresas cadastradas.
        /// </summary>
        /// <returns>Lista de empresas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CompanyDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]    // token sem permissão
        public async Task<ActionResult<List<CompanyDto>>> GetAll()
        {
            var companies = await _service.GetAllAsync();
            return Ok(companies);
        }

        /// <summary>
        /// Retorna os dados de uma empresa específica pelo ID.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <returns>Dados da empresa</returns>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]     // empresa não encontrada
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]    // token sem permissão
        public async Task<ActionResult<CompanyDto>> GetById(int id)
        {
            var company = await _service.GetByIdAsync(id);
            if (company == null) return NotFound();
            return Ok(company);
        }

        /// <summary>
        /// Retorna os dados de uma empresa pelo CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ da empresa</param>
        /// <returns>Dados da empresa</returns>
        [HttpGet("by-cnpj/{cnpj}")]
        [ProducesResponseType(typeof(CompanyDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]     // empresa não encontrada
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]    // token sem permissão
        public async Task<ActionResult<CompanyDto>> GetByCNPJ([FromQuery] string cnpj)
        {
            var company = await _service.GetByCNPJAsync(cnpj);
            if (company == null) return NotFound();
            return Ok(company);
        }

        /// <summary>
        /// Cria uma nova empresa na plataforma.
        /// </summary>
        /// <param name="dto">Dados da empresa</param>
        /// <returns>Localização do recurso criado</returns>
        [HttpPost]
        [AllowAnonymous]  
        [ProducesResponseType(StatusCodes.Status201Created)]      // criado com sucesso
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   // dados inválidos
        [ProducesResponseType(StatusCodes.Status500InternalServerError)] // erro inesperado
        public async Task<IActionResult> Create([FromBody] CreateCompanyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdId = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdId }, null);
        }

        /// <summary>
        /// Atualiza os dados de uma empresa existente.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <param name="dto">Novos dados da empresa</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]    // atualizado com sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]     // empresa não encontrada
        [ProducesResponseType(StatusCodes.Status400BadRequest)]   // dados inválidos
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]    // token sem permissão
        public async Task<IActionResult> Update(int id, [FromBody] CreateCompanyDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove uma empresa da plataforma.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]    // removido com sucesso
        [ProducesResponseType(StatusCodes.Status404NotFound)]     // empresa não encontrada
        [ProducesResponseType(StatusCodes.Status401Unauthorized)] // sem token válido
        [ProducesResponseType(StatusCodes.Status403Forbidden)]    // token sem permissão
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}