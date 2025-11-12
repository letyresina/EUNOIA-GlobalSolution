using EUNOIA.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EUNOIA.Models
{
    /// <summary>
    /// Representa uma entidade de EmotionSession (quais emoções foram coletadas em uma sessão).
    /// </summary>
    public class EmotionSession
    {
        /// <summary>
        /// Id da sessão.
        /// </summary>
        [Key]
        public int SessionId { get; set; }

        // Chave estrangeira para User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public required User User { get; set; }

        /// <summary>
        /// Quando o Feedback foi capturado.
        /// </summary>
        public DateTime CapturedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Contexto de onde foi a sessão de emoção.
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// Dispositivo utilizado.
        /// </summary>
        public DeviceType Device { get; set; }

        /// <summary>
        /// Nível de confiança do modelo
        /// </summary>
        public decimal ConfidenceScore { get; set; }

        /// <summary>
        /// Por quem foi processado
        /// </summary>
        public ProcessedByType ProcessedBy { get; set; }

        /// <summary>
        /// Indica se os dados foram anonimizados para relatório
        /// </summary>
        public bool IsAnonymized { get; set; } = false;

        // Relacionamentos
        public ICollection<Emotion> Emotions { get; set; } = new List<Emotion>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
