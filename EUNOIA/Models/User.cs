using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EUNOIA.Models
{
    /// <summary>
    /// Representa uma entidade de User (usuário propriamente dito).
    /// </summary>
    public class User
    {
        /// <summary>
        /// Identificador único do usuário.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        /// <summary>
        /// CPF do usuário.
        /// </summary>
        [Required, MaxLength(14)]
        public string CPF { get; set; } = string.Empty;

        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        [Required, MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Endereço de e-mail do usuário.
        /// </summary>
        [Required, MaxLength(150)]
        public required string Email { get; set; }

        /// <summary>
        /// Hash da senha do usuário.
        /// </summary>
        [Required]
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Função ou cargo do usuário.
        /// </summary>
        [Required, MaxLength(50)]
        public required string Role { get; set; }

        /// <summary>
        /// Departamento ao qual o usuário pertence.
        /// </summary>
        [MaxLength(100)]
        public required string Department { get; set; }

        /// <summary>
        /// Data e hora de criação da conta do usuário.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Indica se a conta do usuário está ativa.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Identificador da empresa à qual o usuário está vinculado.
        /// </summary>
        [ForeignKey("Company")]
        public int CompanyId { get; set; }

        /// <summary>
        /// Empresa associada ao usuário.
        /// </summary>
        public Company Company { get; set; } = null;

        /// <summary>
        /// Configurações de privacidade do usuário.
        /// </summary>
        public PrivacySetting? PrivacySetting { get; set; }

        /// <summary>
        /// Sessões de emoção associadas ao usuário.
        /// </summary>
        public ICollection<EmotionSession> EmotionSessions { get; set; } = new List<EmotionSession>();

        /// <summary>
        /// Logs de auditoria relacionados ao usuário.
        /// </summary>
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}