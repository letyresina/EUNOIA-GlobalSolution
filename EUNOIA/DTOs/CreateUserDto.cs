using System.ComponentModel.DataAnnotations;

namespace EUNOIA.DTOs
{
    public class CreateUserDto
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, MaxLength(150)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string PasswordHash { get; set; } = string.Empty;

        [Required, MaxLength(50)]
        public string Role { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Department { get; set; } = string.Empty;

        [Required]
        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "CPF inválido. Use o formato 000.000.000-00.")]
        public string CPF { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [Required]
        public int CompanyId { get; set; }
    }
}