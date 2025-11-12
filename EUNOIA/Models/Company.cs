using EUNOIA.Enums;
using System.ComponentModel.DataAnnotations;

namespace EUNOIA.Models
{
    /// <summary>
    /// Representa uma entidade de Company (empresa).
    /// </summary>
    public class Company
    {
        /// <summary>
        /// Id da empresa.
        /// </summary>
        [Key]
        public int CompanyId { get; set; }

        /// <summary>
        /// Nome da empresa.
        /// </summary>
        [Required, MaxLength(150)]
        public required string Name { get; set; }

        /// <summary>
        /// CNPJ da empresa.
        /// </summary>
        [Required, MaxLength(18)]
        public required string CNPJ { get; set; }

        /// <summary>
        /// Setor de atuação da empresa.
        /// </summary>
        public CompanySector Sector { get; set; }

        /// <summary>
        /// Quando foi criado a empresa na plataforma.
        /// </summary>
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Se a empresa está ativa na plataforma ou não.
        /// </summary>
        public bool IsActive { get; set; } = true;

        // Relacionamento
        public ICollection<User> Users { get; set; } = new List<User>();

    }
}
