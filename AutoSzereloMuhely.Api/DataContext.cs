using AutoSzereloMuhely.Domain;
using Microsoft.EntityFrameworkCore;

namespace AutoSzereloMuhely.API;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    
    public virtual DbSet<Munka> Munkak { get; set; }
    public virtual DbSet<Ugyfel> Ugyfelek { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Munka>().Property(m => m.Kategoria).HasConversion<string>();
        modelBuilder.Entity<Munka>().Property(m => m.Allapot).HasConversion<string>();
    }
    
}