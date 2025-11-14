using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para criação de um novo log de auditoria.
    /// </summary>
    public class CreateAuditLogDto
    {
        /// <summary>
        /// Identificador do usuário que realizou a ação.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Tipo de ação realizada pelo usuário.
        /// </summary>
        public AuditAction Action { get; set; }

        /// <summary>
        /// Endereço IP de origem da requisição.
        /// </summary>
        public string IpAddress { get; set; } = string.Empty;

        /// <summary>
        /// Indica se a ação foi realizada com sucesso.
        /// </summary>
        public bool IsSuccessful { get; set; }
    }
}