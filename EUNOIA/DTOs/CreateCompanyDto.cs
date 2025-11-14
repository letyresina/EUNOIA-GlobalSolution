using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO para criação de uma nova empresa.
    /// </summary>
    public class CreateCompanyDto
    {
        /// <summary>
        /// Nome da empresa.
        /// </summary>
        [Required(ErrorMessage = "O nome da empresa é obrigatório.")]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// CNPJ da empresa no formato 00.000.000/0000-00.
        /// </summary>
        [Required(ErrorMessage = "O CNPJ é obrigatório.")]
        [RegularExpression(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$", ErrorMessage = "CNPJ inválido. Use o formato 00.000.000/0000-00.")]
        public string CNPJ { get; set; } = string.Empty;

        /// <summary>
        /// Setor da empresa.
        /// </summary>
        [Required(ErrorMessage = "O setor é obrigatório.")]
        public CompanySector Sector { get; set; }

        /// <summary>
        /// Indica se a empresa está ativa.
        /// </summary>
        public bool IsActive { get; set; }
    }
}