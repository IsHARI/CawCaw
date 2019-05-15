// ViewModel for Index.cshtml

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using CawCaw.Models;

namespace CawCaw.Views.Home
{
    public class Index
    {
        [Required]
        [Display(Name = "New post")]
        public string InputText { get; set; }

        public List<Post> Posts { get; set; }
    }
}