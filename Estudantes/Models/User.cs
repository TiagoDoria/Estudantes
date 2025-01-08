using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Estudantes.Models
{
    public class User : IdentityUser
    {
        [Required]
        public string Name { get; set; }
    }
}
