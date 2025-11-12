using EUNOIA.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EUNOIA.Models
{
    /// <summary>
    /// Representa uma entidade de Feedback.
    /// </summary>
    public class Feedback
    {
        /// <summary>
        /// Id do feedback.
        /// </summary>
        [Key]
        public int FeedbackId { get; set; }

        // Chave estrangeira para EmotionSession
        [ForeignKey("EmotionSession")]
        public int SessionId { get; set; }
        public required EmotionSession EmotionSession { get; set; }

        /// <summary>
        /// Por quem o relatório de feedback foi gerado (IA, Gestor ou RH).
        /// </summary>
        [Required]
        public FeedbackSource GeneratedBy { get; set; }

        /// <summary>
        /// Mensagem escrita para o feedback.
        /// </summary>
        [Required, MaxLength(500)]
        public required string Message { get; set; }

        /// <summary>
        /// Qual a ação sugerida com base do feedback capturado.
        /// </summary>
        public SuggestedAction SuggestedAction { get; set; }

        /// <summary>
        /// Quando o feedback foi cradi
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Lido ou não pelo usuário.
        /// </summary>
        public bool IsViewed { get; set; } = false;
    }
}
