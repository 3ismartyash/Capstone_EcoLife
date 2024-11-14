using Microsoft.AspNetCore.Identity;

namespace EcoLife.AuthAPi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
