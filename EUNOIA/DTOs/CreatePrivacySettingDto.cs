namespace EUNOIA.DTOs
{
    public class CreatePrivacySettingDto
    {
        public int UserId { get; set; }
        public bool AllowFacialRecognition { get; set; } = true;
        public bool AllowDataSharing { get; set; } = false;
        public bool AnonymizeReports { get; set; } = false;
    }
}