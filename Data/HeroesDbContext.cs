global using Microsoft.EntityFrameworkCore;
namespace SuperHero.Data;

public class SuperHeroContext : DbContext
{
    public SuperHeroContext(DbContextOptions<SuperHeroContext> options) : base(options) {}
    
    public DbSet<SuperHero> SuperHeroes { get; set; }
}