using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    public class PrivacySettingRepository
    {
        private readonly EunoiaDbContext _context;

        public PrivacySettingRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        public async Task<List<PrivacySetting>> GetAllAsync()
        {
            return await _context.PrivacySettings.ToListAsync();
        }

        public async Task<PrivacySetting?> GetByUserIdAsync(int userId)
        {
            return await _context.PrivacySettings.FirstOrDefaultAsync(p => p.UserId == userId);
        }

        public async Task AddAsync(PrivacySetting setting)
        {
            _context.PrivacySettings.Add(setting);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(PrivacySetting setting)
        {
            _context.PrivacySettings.Update(setting);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByUserIdAsync(int userId)
        {
            var setting = await GetByUserIdAsync(userId);
            if (setting != null)
            {
                _context.PrivacySettings.Remove(setting);
                await _context.SaveChangesAsync();
            }
        }
    }
}