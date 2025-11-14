namespace EUNOIA.DTOs
{
    /// <summary>
    /// Representa os dados de um log de auditoria com informações do usuário.
    /// </summary>
    public class AuditLogDto
    {
        /// <summary>
        /// Identificador único do log de auditoria.
        /// </summary>
        public int LogId { get; set; }

        /// <summary>
        /// Identificador do usuário relacionado ao log.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Nome do usuário que realizou a ação.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Ação registrada no log (ex: login, alteração de dados).
        /// </summary>
        public string Action { get; set; } = string.Empty;

        /// <summary>
        /// Data e hora em que a ação foi realizada.
        /// </summary>
        public DateTime Timestamp { get; set; }

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