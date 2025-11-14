namespace EUNOIA.DTOs
{
    /// <summary>
    /// Representa as configurações de privacidade de um usuário.
    /// </summary>
    public class PrivacySettingDto
    {
        /// <summary>
        /// Identificador único da configuração de privacidade.
        /// </summary>
        public int SettingId { get; set; }

        /// <summary>
        /// Identificador do usuário associado a esta configuração.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Indica se o reconhecimento facial está permitido.
        /// </summary>
        public bool AllowFacialRecognition { get; set; }

        /// <summary>
        /// Indica se o compartilhamento de dados está permitido.
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
    }
}