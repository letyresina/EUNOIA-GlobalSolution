using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    /// <summary>
    /// DTO que representa uma empresa.
    /// </summary>
    public class CompanyDto
    {
        /// <summary>
        /// Identificador único da empresa.
        /// </summary>
        public int CompanyId { get; set; }

        /// <summary>
        /// Nome da empresa.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// CNPJ da empresa.
        /// </summary>
        public string CNPJ { get; set; } = string.Empty;

        /// <summary>
        /// Setor de atuação da empresa.
        /// </summary>
        public CompanySector Sector { get; set; }

        /// <summary>
        /// Indica se a empresa está ativa.
        /// </summary>
        public bool IsActive { get; set; }
    }
}