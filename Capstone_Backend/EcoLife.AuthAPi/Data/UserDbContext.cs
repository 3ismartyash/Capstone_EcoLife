using EcoLife.AuthAPi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EcoLife.AuthAPi.Data
{
    public class UserDbContext : IdentityDbContext<ApplicationUser,ApplicationRole,int>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
       
    }
}
