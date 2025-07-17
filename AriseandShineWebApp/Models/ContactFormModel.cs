using System.ComponentModel.DataAnnotations;

namespace AriseandShineWebApp.Models
{
    public class ContactFormModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [EmailAddress]
        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Message { get; set; } = string.Empty;

        public bool AttendsChurch { get; set; }
    }
}
