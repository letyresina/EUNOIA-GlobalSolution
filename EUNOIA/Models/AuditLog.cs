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
        /// Identificador único do log.
        /// </summary>
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LogId { get; set; }

        /// <summary>
        /// Identificador do usuário relacionado ao log.
        /// </summary>
        [ForeignKey("User")]
        public int UserId { get; set; }

        /// <summary>
        /// Usuário relacionado ao log.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Tipo de ação realizada na API.
        /// </summary>
        public AuditAction Action { get; set; }

        /// <summary>
        /// Data e hora em que a ação foi registrada.
        /// </summary>
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Endereço IP de origem da requisição.
        /// </summary>
        [Required, MaxLength(50)]
        public required string IpAddress { get; set; }

        /// <summary>
        /// Indica se a ação foi realizada com sucesso.
        /// </summary>
        public bool IsSuccessful { get; set; }
    }
}