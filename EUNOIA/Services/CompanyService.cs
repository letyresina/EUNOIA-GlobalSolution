using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço responsável por gerenciar operações de negócio relacionadas à entidade Company.
    /// </summary>
    public class CompanyService
    {
        private readonly CompanyRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância do serviço com o repositório de empresas.
        /// </summary>
        /// <param name="repository">Instância do repositório de empresas.</param>
        public CompanyService(CompanyRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todas as empresas cadastradas no sistema.
        /// </summary>
        /// <returns>Lista de objetos CompanyDto.</returns>
        public async Task<List<CompanyDto>> GetAllAsync()
        {
            var companies = await _repository.GetAllAsync();
            return companies.Select(c => new CompanyDto
            {
                CompanyId = c.CompanyId,
                Name = c.Name,
                CNPJ = c.CNPJ,
                Sector = c.Sector,
                IsActive = c.IsActive
            }).ToList();
        }

        /// <summary>
        /// Busca uma empresa pelo seu identificador.
        /// </summary>
        /// <param name="id">Identificador da empresa.</param>
        /// <returns>Objeto CompanyDto ou null se não encontrado.</returns>
        public async Task<CompanyDto?> GetByIdAsync(int id)
        {
            var company = await _repository.GetByIdAsync(id);
            if (company == null) return null;

            return new CompanyDto
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
                CNPJ = company.CNPJ,
                Sector = company.Sector,
                IsActive = company.IsActive
            };
        }

        /// <summary>
        /// Busca uma empresa pelo seu CNPJ.
        /// </summary>
        /// <param name="cnpj">CNPJ da empresa.</param>
        /// <returns>Objeto CompanyDto ou null se não encontrado.</returns>
        public async Task<CompanyDto?> GetByCNPJAsync(string cnpj)
        {
            var company = await _repository.GetByCNPJAsync(cnpj);
            if (company == null) return null;

            return new CompanyDto
            {
                CompanyId = company.CompanyId,
                Name = company.Name,
                CNPJ = company.CNPJ,
                Sector = company.Sector,
                IsActive = company.IsActive
            };
        }

        /// <summary>
        /// Adiciona uma nova empresa ao sistema.
        /// </summary>
        /// <param name="dto">DTO contendo os dados da empresa.</param>
        /// <returns>Identificador da empresa criada.</returns>
        public async Task<int> AddAsync(CreateCompanyDto dto)
        {
            var company = new Company
            {
                Name = dto.Name,
                CNPJ = dto.CNPJ,
                Sector = dto.Sector,
                IsActive = dto.IsActive
            };

            await _repository.AddAsync(company);
            return company.CompanyId;
        }

        /// <summary>
        /// Atualiza os dados de uma empresa existente.
        /// </summary>
        /// <param name="id">Identificador da empresa.</param>
        /// <param name="dto">DTO com os dados atualizados.</param>
        public async Task UpdateAsync(int id, CreateCompanyDto dto)
        {
            var company = await _repository.GetByIdAsync(id);
            if (company == null) return;

            company.Name = dto.Name;
            company.CNPJ = dto.CNPJ;
            company.Sector = dto.Sector;
            company.IsActive = dto.IsActive;

            await _repository.UpdateAsync(company);
        }

        /// <summary>
        /// Remove uma empresa do sistema com base no seu identificador.
        /// </summary>
        /// <param name="id">Identificador da empresa a ser removida.</param>
        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}