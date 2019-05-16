using System;
using System.ComponentModel.DataAnnotations;

namespace CawCaw.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public ApplicationUser Author { get; set; }

        [Required]
        [MaxLength(140)]
        public string PostText { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}