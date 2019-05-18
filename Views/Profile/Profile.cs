// ViewModel for Profile

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CawCaw.Models;

namespace CawCaw.Views.Profile
{
    public class Profile
    {
        [Required(ErrorMessage = "A post can't be empty")]
        [StringLength(140, ErrorMessage = "A post can be at most 140 characters long")]
        [Display(Name = "New post")]
        public string InputText { get; set; }

        public ApplicationUser ProfileUser { get; set; }

        public List<Post> Posts { get; set; }

        public bool Current { get; set; }
    }
}