using EUNOIA.DTOs;
using EUNOIA.Models;
using EUNOIA.Repositories;

namespace EUNOIA.Services
{
    /// <summary>
    /// Serviço para operações relacionadas a emoções detectadas.
    /// </summary>
    public class EmotionService
    {
        private readonly EmotionRepository _repository;

        /// <summary>
        /// Inicializa uma nova instância do serviço de emoções com o repositório fornecido.
        /// </summary>
        /// <param name="repository">Repositório responsável pelas operações de persistência de emoções.</param>
        public EmotionService(EmotionRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retorna todas as emoções cadastradas.
        /// </summary>
        /// <returns>Lista de objetos <see cref="EmotionDto"/> contendo os dados das emoções.</returns>
        public async Task<List<EmotionDto>> GetAllAsync()
        {
            var emotions = await _repository.GetAllAsync();
            return emotions.Select(e => new EmotionDto
            {
                EmotionId = e.EmotionId,
                SessionId = e.SessionId,
                PrimaryEmotion = e.PrimaryEmotion,
                SecondaryEmotions = e.SecondaryEmotions,
                Intensity = e.Intensity,
                Duration = e.Duration,
                DetectedAt = e.DetectedAt
            }).ToList();
        }

        /// <summary>
        /// Retorna as emoções de uma sessão específica.
        /// </summary>
        /// <param name="sessionId">Identificador da sessão de emoção.</param>
        /// <returns>Lista de objetos <see cref="EmotionDto"/> relacionados à sessão informada.</returns>
        public async Task<List<EmotionDto>> GetBySessionIdAsync(int sessionId)
        {
            var emotions = await _repository.GetBySessionIdAsync(sessionId);
            return emotions.Select(e => new EmotionDto
            {
                EmotionId = e.EmotionId,
                SessionId = e.SessionId,
                PrimaryEmotion = e.PrimaryEmotion,
                SecondaryEmotions = e.SecondaryEmotions,
                Intensity = e.Intensity,
                Duration = e.Duration,
                DetectedAt = e.DetectedAt
            }).ToList();
        }

        /// <summary>
        /// Adiciona uma nova emoção.
        /// </summary>
        /// <param name="dto">Objeto <see cref="CreateEmotionDto"/> contendo os dados da emoção a ser registrada.</param>
        public async Task AddAsync(CreateEmotionDto dto)
        {
            var emotion = new Emotion
            {
                SessionId = dto.SessionId,
                PrimaryEmotion = dto.PrimaryEmotion,
                SecondaryEmotions = dto.SecondaryEmotions,
                Intensity = dto.Intensity,
                Duration = dto.Duration,
                DetectedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(emotion);
        }
    }
}