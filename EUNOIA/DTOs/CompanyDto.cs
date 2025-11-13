using EUNOIA.Enums;

namespace EUNOIA.DTOs
{
    public class CompanyDto
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string CNPJ { get; set; } = string.Empty;
        public CompanySector Sector { get; set; }
        public bool IsActive { get; set; }
    }
}