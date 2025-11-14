using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    public class UserRepository
    {
        private readonly EunoiaDbContext _context;

        public UserRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetByCPFAsync(string cpf)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.CPF == cpf);
        }

        public async Task AddAsync(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(User user)
        {
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByCPFAsync(string cpf)
        {
            var user = await GetByCPFAsync(cpf);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User?> GetByCPFWithCompanyAsync(string cpf)
        {
            return await _context.Users
                .Include(u => u.Company)
                .FirstOrDefaultAsync(u => u.CPF == cpf);
        }

    }
}