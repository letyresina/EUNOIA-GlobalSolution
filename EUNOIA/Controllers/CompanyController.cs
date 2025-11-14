using EUNOIA.DTOs;
using EUNOIA.Services;
using Microsoft.AspNetCore.Mvc;

namespace EUNOIA.Controllers
{
    /// <summary>
    /// Controlador responsável pelas operações relacionadas à entidade Empresa.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class CompanyController(CompanyService service) : ControllerBase
    {
        private readonly CompanyService _service = service;

        /// <summary>
        /// Inicializa uma nova instância de <see cref="CompanyController"/>.
        /// </summary>
        /// <param name="service">Serviço de empresas.</param>
        // O construtor primário já está sendo utilizado acima.

        /// <summary>
        /// Retorna todas as empresas cadastradas.
        /// </summary>
        /// <returns>Lista de empresas</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<CompanyDto>), StatusCodes.Status200OK)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<CompanyDto>> GetByCNPJ(string cnpj)
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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateCompanyDto dto)
        {
            var createdId = await _service.AddAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = createdId }, null);
        }

        /// <summary>
        /// Atualiza os dados de uma empresa existente.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        /// <param name="dto">Novos dados da empresa</param>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int id, [FromBody] CreateCompanyDto dto)
        {
            await _service.UpdateAsync(id, dto);
            return NoContent();
        }

        /// <summary>
        /// Remove uma empresa da plataforma.
        /// </summary>
        /// <param name="id">ID da empresa</param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}