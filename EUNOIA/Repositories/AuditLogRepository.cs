using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    /// <summary>
    /// Repositório para manipulação de logs de auditoria.
    /// </summary>
    public class AuditLogRepository
    {
        private readonly EunoiaDbContext _context;

        public AuditLogRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os logs de auditoria.
        /// </summary>
        public async Task<List<AuditLog>> GetAllAsync()
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna os logs de auditoria de um usuário específico.
        /// </summary>
        public async Task<List<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona um novo log de auditoria.
        /// </summary>
        public async Task AddAsync(AuditLog log)
        {
            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}