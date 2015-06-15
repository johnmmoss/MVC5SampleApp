using System;
using System.ComponentModel.DataAnnotations;

namespace MVC5SampleApp.Domain
{
    public class Notice
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(300)]
        public string Headline { get; set; }

        [Required]
        [StringLength(1000)]
        public string Body { get; set; }

        [Required]
        public DateTime PublishDate { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }
    }
}
