using EUNOIA.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EUNOIA.Models
{
    /// <summary>
    /// Representa uma entidade de Emotion (quais emoções foram cadastradas).
    /// </summary>
    public class Emotion
    {
        /// <summary>
        /// Id da emoção.
        /// </summary>
        [Key]
        public int EmotionId { get; set; }

        // Chave estrangeira para EmotionSession
        [ForeignKey("EmotionSession")]
        public int SessionId { get; set; }
        public required EmotionSession EmotionSession { get; set; }

        /// <summary>
        /// Emoção primária detectada.
        /// </summary>
        public PrimaryEmotion PrimaryEmotion { get; set; }

        /// <summary>
        /// Emoção secundária detectada
        /// </summary>
        public SecondaryEmotions SecondaryEmotions { get; set; }

        /// <summary>
        /// Intensidade da emoção principal.
        /// </summary>
        public decimal Intensity { get; set; }

        /// <summary>
        /// Duração da emoção (segundos)
        /// </summary>
        public decimal Duration { get; set; }

        /// <summary>
        /// Data/hora da detecção.
        /// </summary>
        public DateTime DetectedAt { get; set; } = DateTime.UtcNow;
    }
}
