using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CawCaw.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string DisplayName { get; set; }
        public string Bio { get; set; }
    }
}