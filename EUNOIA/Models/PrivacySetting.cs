using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EUNOIA.Models
{
    /// <summary>
    /// Representa uma entidade de PrivacySettings (Privacidade do usuário).
    /// </summary>
    public class PrivacySetting
    {
        /// <summary>
        /// Id das configurações.
        /// </summary>
        [Key]
        public int SettingId { get; set; }

        // Chave estrangeira para User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public required User User { get; set; }

        /// <summary>
        /// Configuração para caso o usuário permita seu reconhecimento facial.
        /// </summary>
        public bool AllowFacialRecognition { get; set; } = true;
        /// <summary>
        /// Configuração para caso o usuário permita o compartilhamento de seus dados.
        /// </summary>
        public bool AllowDataSharing { get; set; } = false;
        /// <summary>
        /// Configuração para caso o usuário deseja que seu nome não apareça nos relatórios.
        /// </summary>
        public bool AnonymizeReports { get; set; } = false;
        /// <summary>
        /// Quando foi a última vez que foi atualizada.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}
