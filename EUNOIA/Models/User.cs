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
        /// Id do usuário.
        /// </summary>
        [Key]
        public int UserId { get; set; }

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        [Required, MaxLength(100)]
        public required string Name { get; set; }

        /// <summary>
        /// Email do usuário.
        /// </summary>
        [Required, MaxLength(150)]
        public required string Email { get; set; }

        /// <summary>
        /// Senha hash do usuário.
        /// </summary>
        [Required]
        public required string PasswordHash { get; set; }

        /// <summary>
        /// Função do usuário.
        /// </summary>
        [Required, MaxLength(50)]
        public required string Role { get; set; }

        /// <summary>
        /// Departamento do usuário.
        /// </summary>
        [MaxLength(100)]
        public required string Department { get; set; }

        /// <summary>
        /// Quando foi criado a conta do usuário do usuário.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Se a conta do usuário está ativa ou não.
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Chave estrangeira para Company
        [ForeignKey("Company")]
        public int CompanyId { get; set; }
        public required Company Company { get; set; }

        // Relacionamentos
        public required PrivacySetting PrivacySetting { get; set; }
        public ICollection<EmotionSession> EmotionSessions { get; set; } = new List<EmotionSession>();
        public ICollection<AuditLog> AuditLogs { get; set; } = new List<AuditLog>();
    }
}
