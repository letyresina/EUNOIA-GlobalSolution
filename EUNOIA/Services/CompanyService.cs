using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    public class CompanyService
    {
        private readonly CompanyRepository _repository;

        public CompanyService(CompanyRepository repository)
        {
            _repository = repository;
        }

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

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}