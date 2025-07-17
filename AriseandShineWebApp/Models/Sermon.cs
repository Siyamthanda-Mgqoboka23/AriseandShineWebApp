using System;
using System.ComponentModel.DataAnnotations;

namespace AriseandShineWebApp.Models
{
    public class Sermon
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime Date { get; set; }

        public string FilePath { get; set; } // Path to the uploaded PDF
    }
}
