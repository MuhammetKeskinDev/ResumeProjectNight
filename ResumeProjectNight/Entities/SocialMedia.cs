namespace ResumeProjectNight.Entities
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public string IconClass { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public int SortOrder { get; set; }
    }
}

