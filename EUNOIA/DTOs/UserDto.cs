namespace EUNOIA.DTOs
{
    /// <summary>
    /// Data Transfer Object para informações do usuário.
    /// </summary>
    public class UserDto
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
        /// Papel do usuário no sistema.
        /// </summary>
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// Departamento ao qual o usuário pertence.
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
        /// Identificador da empresa associada ao usuário.
        /// </summary>
        public int CompanyId { get; set; }
    }
}