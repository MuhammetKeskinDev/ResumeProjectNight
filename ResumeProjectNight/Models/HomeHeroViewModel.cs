using ResumeProjectNight.Entities;

namespace ResumeProjectNight.Models
{
    public class HomeHeroViewModel
    {
        public HomeHero? HomeHero { get; set; }
        public List<SocialMedia> SocialMedias { get; set; } = new();
    }
}

