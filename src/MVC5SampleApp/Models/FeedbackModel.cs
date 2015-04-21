using System.ComponentModel.DataAnnotations;

namespace MVC5SampleApp.Models
{
    public class FeedbackModel
    {
        [Required]
        [StringLength(100)]
        public string Email { get; set; }
        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        public string Surname { get; set; }
        [Required]
        [StringLength(600)]
        public string Text { get; set; }
    }
}