using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço para operações relacionadas a sessões de emoção.
    /// </summary>
    public class EmotionSessionService
    {
        private readonly EmotionSessionRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância do serviço de sessões de emoção com o repositório fornecido.
        /// </summary>
        /// <param name="repository">Repositório responsável pelas operações de persistência de sessões de emoção.</param>
        public EmotionSessionService(EmotionSessionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todas as sessões de emoção com dados do usuário.
        /// </summary>
        /// <returns>Lista de objetos <see cref="EmotionSessionDto"/> contendo os dados das sessões.</returns>
        public async Task<List<EmotionSessionDto>> GetAllAsync()
        {
            var sessions = await _repository.GetAllAsync();
            return sessions.Select(s => new EmotionSessionDto
            {
                SessionId = s.SessionId,
                UserId = s.UserId,
                UserName = s.User.Name,
                CapturedAt = s.CapturedAt,
                Context = s.Context,
                Device = s.Device,
                ConfidenceScore = s.ConfidenceScore,
                ProcessedBy = s.ProcessedBy,
                IsAnonymized = s.IsAnonymized
            }).ToList();
        }

        /// <summary>
        /// Retorna as sessões de emoção de um usuário específico.
        /// </summary>
        /// <param name="userId">Identificador do usuário.</param>
        /// <returns>Lista de <see cref="EmotionSessionDto"/> relacionadas ao usuário informado.</returns>
        public async Task<List<EmotionSessionDto>> GetByUserIdAsync(int userId)
        {
            var sessions = await _repository.GetByUserIdAsync(userId);
            return sessions.Select(s => new EmotionSessionDto
            {
                SessionId = s.SessionId,
                UserId = s.UserId,
                UserName = s.User.Name,
                CapturedAt = s.CapturedAt,
                Context = s.Context,
                Device = s.Device,
                ConfidenceScore = s.ConfidenceScore,
                ProcessedBy = s.ProcessedBy,
                IsAnonymized = s.IsAnonymized
            }).ToList();
        }

        /// <summary>
        /// Adiciona uma nova sessão de emoção.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateEmotionSessionDto"/> contendo os dados da sessão a ser criada.</param>
        public async Task AddAsync(CreateEmotionSessionDto dto)
        {
            var session = new EmotionSession
            {
                UserId = dto.UserId,
                Context = dto.Context,
                Device = dto.Device,
                ConfidenceScore = dto.ConfidenceScore,
                ProcessedBy = dto.ProcessedBy,
                IsAnonymized = dto.IsAnonymized,
                CapturedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(session);
        }
    }
}