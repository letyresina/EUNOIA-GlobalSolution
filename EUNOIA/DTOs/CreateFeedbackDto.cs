using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para criação de um novo feedback.
    /// </summary>
    public class CreateFeedbackDto
    {
        /// <summary>
        /// Identificador da sessão emocional à qual o feedback será vinculado.
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
    }
}