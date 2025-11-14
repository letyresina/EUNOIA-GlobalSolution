namespace EUNOIA.DTOs
{
    public class PrivacySettingDto
    {
        public int SettingId { get; set; }
        public int UserId { get; set; }
        public bool AllowFacialRecognition { get; set; }
        public bool AllowDataSharing { get; set; }
        public bool AnonymizeReports { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}