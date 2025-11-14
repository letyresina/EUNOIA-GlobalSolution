using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para criação de uma nova sessão de emoção.
    /// </summary>
    public class CreateEmotionSessionDto
    {
        /// <summary>
        /// Identificador do usuário que participou da sessão.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Contexto em que a sessão foi realizada (ex: reunião, pausa, atividade).
        /// </summary>
        public Context Context { get; set; }

        /// <summary>
        /// Tipo de dispositivo utilizado para capturar a sessão.
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
        public bool IsAnonymized { get; set; } = false;
    }
}