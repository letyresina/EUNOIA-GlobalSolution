using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    public class CompanyRepository
    {
        private readonly EunoiaDbContext _context;

        public CompanyRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int id)
        {
            return await _context.Companies.FindAsync(id);
        }

        public async Task<Company?> GetByCNPJAsync(string cnpj)
        {
            return await _context.Companies
                .FirstOrDefaultAsync(c => c.CNPJ == cnpj);
        }

        public async Task AddAsync(Company company)
        {
            _context.Companies.Add(company);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Company company)
        {
            _context.Companies.Update(company);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var company = await _context.Companies.FindAsync(id);
            if (company != null)
            {
                _context.Companies.Remove(company);
                await _context.SaveChangesAsync();
            }
        }
    }
}