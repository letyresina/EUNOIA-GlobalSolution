using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para criação de uma nova emoção.
    /// </summary>
    public class CreateEmotionDto
    {
        /// <summary>
        /// Identificador da sessão de emoção à qual esta emoção será associada.
        /// </summary>
        public int SessionId { get; set; }

        /// <summary>
        /// Emoção primária detectada (ex: alegria, tristeza, raiva).
        /// </summary>
        public PrimaryEmotion PrimaryEmotion { get; set; }

        /// <summary>
        /// Emoções secundárias complementares à emoção primária.
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
    }
}