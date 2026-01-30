using System.ComponentModel.DataAnnotations;

namespace ResumeProjectNight.Entities
{
    public class ProjectCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public ICollection<Portfolio> Portfolios { get; set; }
    }
}
