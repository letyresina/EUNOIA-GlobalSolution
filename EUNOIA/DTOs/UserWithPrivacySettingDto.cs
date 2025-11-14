namespace EUNOIA.DTOs
{
    public class UserWithPrivacySettingDto
    {
        public string CPF { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Department { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
        public int CompanyId { get; set; }

        // Dados de privacidade
        public bool AllowFacialRecognition { get; set; }
        public bool AllowDataSharing { get; set; }
        public bool AnonymizeReports { get; set; }
        public DateTime PrivacyUpdatedAt { get; set; }
    }
}