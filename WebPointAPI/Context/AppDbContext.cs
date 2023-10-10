using Microsoft.EntityFrameworkCore;
using WebPointAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebPointAPI.Context
{
    public class AppDbContext : IdentityDbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Historico> Historicos { get; set; }
    }
}
