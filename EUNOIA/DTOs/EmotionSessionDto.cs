using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// Representa os dados de uma sessão de emoção.
    /// </summary>
    public class EmotionSessionDto
    {
        /// <summary>
        /// Identificador único da sessão de emoção.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Identificador do usuário associado à sessão.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nome do usuário que participou da sessão.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora em que a sessão foi capturada.
        /// </summary>
        public DateTime CapturedAt { get; set; }

        /// <summary>
        /// Contexto em que a sessão foi realizada (ex: reunião, pausa, etc.).
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// Tipo de dispositivo utilizado na sessão.
        /// </summary>
        public DeviceType Device { get; set; }

        /// <summary>
        /// Nível de confiança do modelo na detecção das emoções.
        /// </summary>
        public decimal ConfidenceScore { get; set; }

        /// <summary>
        /// Origem do processamento da sessão (ex: IA, humano).
        /// </summary>
        public ProcessedByType ProcessedBy { get; set; }

        /// <summary>
        /// Indica se os dados da sessão foram anonimizados.
        /// </summary>
        public bool IsAnonymized { get; set; }
    }
}