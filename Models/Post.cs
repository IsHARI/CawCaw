using System;
using System.ComponentModel.DataAnnotations;

namespace CawCaw.Models
{
    public class Post
    {
        public int Id { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string PostText { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}