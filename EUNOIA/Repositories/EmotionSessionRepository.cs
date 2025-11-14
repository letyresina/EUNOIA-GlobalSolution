using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    /// <summary>
    /// Repositório para manipulação de sessões de emoção.
    /// </summary>
    public class EmotionSessionRepository
    {
        private readonly EunoiaDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados Eunoia.</param>
        public EmotionSessionRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as sessões de emoção com dados do usuário.
        /// </summary>
        /// <returns>Lista de sessões de emoção ordenadas por data de captura decrescente.</returns>
        public async Task<List<EmotionSession>> GetAllAsync()
        {
            return await _context.EmotionSessions
                .Include(e => e.User)
                .OrderByDescending(e => e.CapturedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna as sessões de emoção de um usuário específico.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Lista de sessões de emoção do usuário ordenadas por data de captura decrescente.</returns>
        public async Task<List<EmotionSession>> GetByUserIdAsync(int userId)
        {
            return await _context.EmotionSessions
                .Include(e => e.User)
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.CapturedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona uma nova sessão de emoção.
        /// </summary>
        /// <param name="session">Objeto <see cref="EmotionSession"/> a ser inserido.</param>
        public async Task AddAsync(EmotionSession session)
        {
            _context.EmotionSessions.Add(session);
            await _context.SaveChangesAsync();
        }
    }
}