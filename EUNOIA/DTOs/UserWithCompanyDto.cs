namespace EUNOIA.DTOs
{
    public class UserWithCompanyDto
    {
        public string CPF { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyCNPJ { get; set; } = string.Empty;
    }
}