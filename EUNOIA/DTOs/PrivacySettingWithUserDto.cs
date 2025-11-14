namespace EUNOIA.DTOs
{
    /// <summary>
    /// Representa as configurações de privacidade de um usuário, incluindo permissões e informações básicas do usuário.
    /// </summary>
    public class PrivacySettingWithUserDto
    {
        /// <summary>
        /// Identificador único da configuração de privacidade.
        /// </summary>
        public int SettingId { get; set; }

        /// <summary>
        /// Identificador único do usuário associado.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Indica se o reconhecimento facial é permitido.
        /// </summary>
        public bool AllowFacialRecognition { get; set; }

        /// <summary>
        /// Indica se o compartilhamento de dados é permitido.
        /// </summary>
        public bool AllowDataSharing { get; set; }

        /// <summary>
        /// Indica se os relatórios devem ser anonimizados.
        /// </summary>
        public bool AnonymizeReports { get; set; }

        /// <summary>
        /// Data e hora da última atualização das configurações.
        /// </summary>
        public DateTime UpdatedAt { get; set; }

        /// <summary>
        /// Nome do usuário associado.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// E-mail do usuário associado.
        /// </summary>
        public string UserEmail { get; set; } = string.Empty;

        /// <summary>
        /// CPF do usuário associado.
        /// </summary>
        public string UserCPF { get; set; } = string.Empty;
    }
}