namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO que representa um usuário juntamente com suas configurações de privacidade.
    /// </summary>
    public class UserWithPrivacySettingDto
    {
        /// <summary>
        /// CPF do usuário.
        /// </summary>
        public string CPF { get; set; } = string.Empty;

        /// <summary>
        /// Nome do usuário.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// E-mail do usuário.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Papel do usuário na empresa.
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// Departamento do usuário.
        /// </summary>
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// Data de criação do usuário.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Indica se o usuário está ativo.
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// Identificador da empresa à qual o usuário pertence.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Indica se o usuário permite reconhecimento facial.
        /// </summary>
        public bool AllowFacialRecognition { get; set; }

        /// <summary>
        /// Indica se o usuário permite compartilhamento de dados.
        /// </summary>
        public bool AllowDataSharing { get; set; }

        /// <summary>
        /// Indica se os relatórios do usuário devem ser anonimizados.
        /// </summary>
        public bool AnonymizeReports { get; set; }

        /// <summary>
        /// Data da última atualização das configurações de privacidade.
        /// </summary>
        public DateTime PrivacyUpdatedAt { get; set; }
    }
}