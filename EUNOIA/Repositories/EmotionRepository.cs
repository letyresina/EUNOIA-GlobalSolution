using EUNOIA.Data;
using EUNOIA.Models;
using Microsoft.EntityFrameworkCore;

namespace EUNOIA.Repositories
{
    /// <summary>
    /// Repositório para manipulação de emoções detectadas.
    /// </summary>
    public class EmotionRepository
    {
        private readonly EunoiaDbContext _context;

        /// <summary>
        /// Inicializa uma nova instância do repositório com o contexto do banco de dados.
        /// </summary>
        /// <param name="context">Contexto do banco de dados Eunoia.</param>
        public EmotionRepository(EunoiaDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna todas as emoções cadastradas, ordenadas por data de detecção decrescente.
        /// </summary>
        /// <returns>Lista de objetos <see cref="Emotion"/>.</returns>
        public async Task<List<Emotion>> GetAllAsync()
        {
            return await _context.Emotions
                .OrderByDescending(e => e.DetectedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Retorna as emoções associadas a uma sessão específica.
        /// </summary>
        /// <param name="sessionId">Identificador da sessão de emoção.</param>
        /// <returns>Lista de objetos <see cref="Emotion"/> relacionados à sessão.</returns>
        public async Task<List<Emotion>> GetBySessionIdAsync(int sessionId)
        {
            return await _context.Emotions
                .Where(e => e.SessionId == sessionId)
                .OrderByDescending(e => e.DetectedAt)
                .ToListAsync();
        }

        /// <summary>
        /// Adiciona uma nova emoção ao banco de dados.
        /// </summary>
        /// <param name="emotion">Objeto <see cref="Emotion"/> a ser inserido.</param>
        public async Task AddAsync(Emotion emotion)
        {
            _context.Emotions.Add(emotion);
            await _context.SaveChangesAsync();
        }
    }
}