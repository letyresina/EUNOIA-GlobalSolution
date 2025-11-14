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
        /// Identificador único das configurações de privacidade.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SettingId { get; set; }

        /// <summary>
        /// Identificador do usuário ao qual as configurações pertencem.
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// Usuário relacionado às configurações de privacidade.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Indica se o usuário permite o uso de reconhecimento facial.
        /// </summary>
        public bool AllowFacialRecognition { get; set; } = true;

        /// <summary>
        /// Indica se o usuário permite o compartilhamento de seus dados.
        /// </summary>
        public bool AllowDataSharing { get; set; } = false;

        /// <summary>
        /// Indica se o nome do usuário deve ser anonimizado nos relatórios.
        /// </summary>
        public bool AnonymizeReports { get; set; } = false;

        /// <summary>
        /// Data e hora da última atualização das configurações.
        /// </summary>
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    }
}