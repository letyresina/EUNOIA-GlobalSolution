using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// Representa os dados de um feedback vinculado a uma sessão emocional.
    /// </summary>
    public class FeedbackDto
    {
        /// <summary>
        /// Identificador único do feedback.
        /// </summary>
        public int FeedbackId { get; set; }

        /// <summary>
        /// Identificador da sessão emocional à qual o feedback está associado.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Origem do feedback (ex: sistema, especialista, usuário).
        /// </summary>
        public FeedbackSource GeneratedBy { get; set; }

        /// <summary>
        /// Mensagem de feedback gerada.
        /// </summary>
        public string Message { get; set; } = string.Empty;

        /// <summary>
        /// Ação sugerida com base na análise emocional.
        /// </summary>
        public SuggestedAction SuggestedAction { get; set; }

        /// <summary>
        /// Data e hora em que o feedback foi criado.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Indica se o feedback já foi visualizado pelo usuário.
        /// </summary>
        public bool IsViewed { get; set; }
    }
}