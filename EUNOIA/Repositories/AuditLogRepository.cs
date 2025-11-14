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

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados Eunoia.</param>
        public AuditLogRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os logs de auditoria, incluindo os dados do usuário associado.
        /// </summary>
        /// <returns>Lista de logs de auditoria ordenados por data decrescente.</returns>
        public async Task<List<AuditLog>> GetAllAsync()
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna os logs de auditoria de um usuário específico, incluindo os dados do usuário.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Lista de logs de auditoria do usuário ordenados por data decrescente.</returns>
        public async Task<List<AuditLog>> GetByUserIdAsync(int userId)
        {
            return await _context.AuditLogs
                .Include(a => a.User)
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.Timestamp)
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona um novo log de auditoria ao banco de dados.
        /// </summary>
        /// <param name="log">Objeto <see cref="AuditLog"/> a ser inserido.</param>
        public async Task AddAsync(AuditLog log)
        {
            _context.AuditLogs.Add(log);
            await _context.SaveChangesAsync();
        }
    }
}