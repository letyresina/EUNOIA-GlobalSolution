using EUNOIA.Enums;
using Microsoft.EntityFrameworkCore;
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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmotionId { get; set; }

        /// <summary>
        /// Chave estrangeira para a sessão de emoção associada.
        /// </summary>
        [ForeignKey("EmotionSession")]
        public int SessionId { get; set; }
        /// <summary>
        /// Sessão de emoção associada a esta emoção.
        /// </summary>
        public EmotionSession? EmotionSession { get; set; }

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
        [Precision(5, 2)]
        public decimal Intensity { get; set; }

        /// <summary>
        /// Duração da emoção (segundos)
        /// </summary>
        [Precision(5, 2)]
        public decimal Duration { get; set; }

        /// <summary>
        /// Data/hora da detecção.
        /// </summary>
        public DateTime DetectedAt { get; set; } = DateTime.UtcNow;
    }
}
