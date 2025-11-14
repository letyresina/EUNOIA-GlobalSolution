using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// Representa os dados de uma emoção detectada.
    /// </summary>
    public class EmotionDto
    {
        /// <summary>
        /// Identificador único da emoção registrada.
        /// </summary>
        public int EmotionId { get; set; }

        /// <summary>
        /// Identificador da sessão de emoção à qual esta emoção pertence.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Emoção primária detectada (ex: alegria, tristeza, raiva).
        /// </summary>
        public PrimaryEmotion PrimaryEmotion { get; set; }

        /// <summary>
        /// Emoções secundárias associadas à detecção.
        /// </summary>
        public SecondaryEmotions SecondaryEmotions { get; set; }

        /// <summary>
        /// Intensidade da emoção detectada, em escala decimal.
        /// </summary>
        public decimal Intensity { get; set; }

        /// <summary>
        /// Duração da emoção detectada, em segundos.
        /// </summary>
        public decimal Duration { get; set; }

        /// <summary>
        /// Data e hora em que a emoção foi detectada.
        /// </summary>
        public DateTime DetectedAt { get; set; }
    }
}