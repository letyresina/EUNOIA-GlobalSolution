namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO que representa um usuário juntamente com informações da empresa associada.
    /// </summary>
    public class UserWithCompanyDto
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
        /// Papel/função do usuário.
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
        /// Id da empresa associada.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Nome da empresa associada.
        /// </summary>
        public string CompanyName { get; set; } = string.Empty;

        /// <summary>
        /// CNPJ da empresa associada.
        /// </summary>
        public string CompanyCNPJ { get; set; } = string.Empty;
    }
}