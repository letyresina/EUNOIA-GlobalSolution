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
        /// Identificador único do feedback.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FeedbackId { get; set; }

        /// <summary>
        /// Identificador da sessão emocional relacionada ao feedback.
        /// </summary>
        [ForeignKey("EmotionSession")]
        public int SessionId { get; set; }

        /// <summary>
        /// Sessão emocional à qual o feedback está vinculado.
        /// </summary>
        public EmotionSession? EmotionSession { get; set; }

        /// <summary>
        /// Origem do feedback (IA, Gestor ou RH).
        /// </summary>
        [Required]
        public FeedbackSource GeneratedBy { get; set; }

        /// <summary>
        /// Mensagem escrita do feedback.
        /// </summary>
        [Required, MaxLength(500)]
        public required string Message { get; set; }

        /// <summary>
        /// Ação sugerida com base no conteúdo do feedback.
        /// </summary>
        public SuggestedAction SuggestedAction { get; set; }

        /// <summary>
        /// Data e hora em que o feedback foi criado.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indica se o feedback já foi visualizado pelo usuário.
        /// </summary>
        public bool IsViewed { get; set; } = false;
    }
}