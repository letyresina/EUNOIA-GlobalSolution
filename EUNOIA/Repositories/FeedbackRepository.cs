using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    /// <summary>
    /// Repositório para manipulação de feedbacks.
    /// </summary>
    public class FeedbackRepository
    {
        private readonly EunoiaDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados Eunoia.</param>
        public FeedbackRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todos os feedbacks cadastrados, ordenados por data de criação decrescente.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Feedback"/>.</returns>
        public async Task<List<Feedback>> GetAllAsync()
        {
            return await _context.Feedbacks
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna os feedbacks vinculados a uma sessão específica.
        /// </summary>
        /// <param name="sessionId">Identificador da sessão emocional.</param>
        /// <returns>Lista de objetos <see cref="Feedback"/> relacionados à sessão informada.</returns>
        public async Task<List<Feedback>> GetBySessionIdAsync(int sessionId)
        {
            return await _context.Feedbacks
                .Where(f => f.SessionId == sessionId)
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona um novo feedback ao banco de dados.
        /// </summary>
        /// <param name="feedback">Objeto <see cref="Feedback"/> a ser inserido.</param>
        public async Task AddAsync(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();
        }
    }
}