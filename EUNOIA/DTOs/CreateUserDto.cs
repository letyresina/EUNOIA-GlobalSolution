using System.ComponentModel.DataAnnotations;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para criação de um novo usuário.
    /// </summary>
    public class CreateUserDto
    {
        /// <summary>
        /// Nome completo do usuário.
        /// </summary>
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Endereço de e-mail do usuário.
        /// </summary>
        [Required, MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Hash da senha do usuário.
        /// </summary>
        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        /// <summary>
        /// Papel/função do usuário no sistema.
        /// </summary>
        [Required, MaxLength(50)]
        public string Role { get; set; } = string.Empty;

        /// <summary>
        /// Departamento do usuário.
        /// </summary>
        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        /// <summary>
        /// CPF do usuário (formato: 000.000.000-00).
        /// </summary>
        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. Use o formato 000.000.000-00.")]
        public string CPF { get; set; } = string.Empty;

        /// <summary>
        /// Indica se o usuário está ativo.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Identificador da empresa à qual o usuário pertence.
        /// </summary>
        [Required]
        public int CompanyId { get; set; }
    }
}