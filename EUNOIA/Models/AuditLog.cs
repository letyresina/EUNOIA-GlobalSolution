using EUNOIA.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EUNOIA.Models
{
    /// <summary>
    /// Representa uma entidade de AuditLog (logs do que foi realizado na API em caso de rastreamento).
    /// </summary>
    public class AuditLog
    {
        /// <summary>
        /// Id do Log
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        // Chave estrangeira para User
        [ForeignKey("User")]
        public int UserId { get; set; }
        public required User User { get; set; }

        /// <summary>
        /// Ação realizada
        /// </summary>
        public AuditAction Action { get; set; }

        /// <summary>
        /// Data e hora de quando foi realizado a ação
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// IP de origem da requisição
        /// </summary>
        [Required, MaxLength(50)]
        public required string IpAddress { get; set; }

        /// <summary>
        /// Se a ação foi realizada com sucesso ou não
        /// </summary>
        public bool IsSuccessful { get; set; }
    }
}
