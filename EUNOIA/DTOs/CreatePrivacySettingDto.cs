namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para criar configurações de privacidade de um usuário.
    /// </summary>
    public class CreatePrivacySettingDto
    {
        /// <summary>
        /// Identificador do usuário ao qual as configurações de privacidade pertencem.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Indica se o reconhecimento facial está permitido para o usuário.
        /// </summary>
        public bool AllowFacialRecognition { get; set; } = true;

        /// <summary>
        /// Indica se o compartilhamento de dados está permitido para o usuário.
        /// </summary>
        public bool AllowDataSharing { get; set; } = false;

        /// <summary>
        /// Indica se os relatórios devem ser anonimizados para o usuário.
        /// </summary>
        public bool AnonymizeReports { get; set; } = false;
    }
}