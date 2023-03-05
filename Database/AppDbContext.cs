using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ValorantMoments.Models;

namespace ValorantMoments.Database
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {

        } 
        public DbSet<Moment> Moments { get; set; }

    }
}
