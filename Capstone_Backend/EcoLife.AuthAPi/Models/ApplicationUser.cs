using Microsoft.AspNetCore.Identity;

namespace EcoLife.AuthAPi.Models
{
    public class ApplicationUser : IdentityUser<int>
    {
        public string Name { get; set; }
    }
}
