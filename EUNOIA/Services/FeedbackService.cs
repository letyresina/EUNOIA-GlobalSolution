using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço para operações relacionadas a feedbacks.
    /// </summary>
    public class FeedbackService
    {
        private readonly FeedbackRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância do serviço de feedbacks com o repositório fornecido.
        /// </summary>
        /// <param name="repository">Repositório responsável pelas operações de persistência de feedbacks.</param>
        public FeedbackService(FeedbackRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todos os feedbacks cadastrados.
        /// </summary>
        /// <returns>Lista de objetos <see cref="FeedbackDto"/> contendo os dados dos feedbacks.</returns>
        public async Task<List<FeedbackDto>> GetAllAsync()
        {
            var feedbacks = await _repository.GetAllAsync();
            return feedbacks.Select(f => new FeedbackDto
            {
                FeedbackId = f.FeedbackId,
                SessionId = f.SessionId,
                GeneratedBy = f.GeneratedBy,
                Message = f.Message,
                SuggestedAction = f.SuggestedAction,
                CreatedAt = f.CreatedAt,
                IsViewed = f.IsViewed
            }).ToList();
        }

        /// <summary>
        /// Retorna os feedbacks de uma sessão específica.
        /// </summary>
        /// <param name="sessionId">Identificador da sessão emocional.</param>
        /// <returns>Lista de objetos <see cref="FeedbackDto"/> associados à sessão informada.</returns>
        public async Task<List<FeedbackDto>> GetBySessionIdAsync(int sessionId)
        {
            var feedbacks = await _repository.GetBySessionIdAsync(sessionId);
            return feedbacks.Select(f => new FeedbackDto
            {
                FeedbackId = f.FeedbackId,
                SessionId = f.SessionId,
                GeneratedBy = f.GeneratedBy,
                Message = f.Message,
                SuggestedAction = f.SuggestedAction,
                CreatedAt = f.CreatedAt,
                IsViewed = f.IsViewed
            }).ToList();
        }

        /// <summary>
        /// Adiciona um novo feedback.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateFeedbackDto"/> contendo os dados do feedback a ser criado.</param>
        public async Task AddAsync(CreateFeedbackDto dto)
        {
            var feedback = new Feedback
            {
                SessionId = dto.SessionId,
                GeneratedBy = dto.GeneratedBy,
                Message = dto.Message,
                SuggestedAction = dto.SuggestedAction,
                CreatedAt = DateTime.UtcNow,
                IsViewed = false
            };

            await _repository.AddAsync(feedback);
        }
    }
}