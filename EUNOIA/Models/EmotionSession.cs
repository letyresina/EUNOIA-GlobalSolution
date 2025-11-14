using EUNOIA.Enums;
using Microsoft.EntityFrameworkCore;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SessionId { get; set; }

        /// <summary>
        /// Chave estrangeira para o usuário relacionado à sessão.
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// Usuário relacionado à sessão.
        /// </summary>
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
        /// Nível de confiança do modelo.
        /// </summary>
        [Precision(5, 2)]
        public decimal ConfidenceScore { get; set; }

        /// <summary>
        /// Por quem foi processado.
        /// </summary>
        public ProcessedByType ProcessedBy { get; set; }

        /// <summary>
        /// Indica se os dados foram anonimizados para relatório.
        /// </summary>
        public bool IsAnonymized { get; set; } = false;

        /// <summary>
        /// Lista de emoções detectadas durante a sessão.
        /// </summary>
        public ICollection<Emotion> Emotions { get; set; } = new List<Emotion>();

        /// <summary>
        /// Lista de feedbacks associados à sessão.
        /// </summary>
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}