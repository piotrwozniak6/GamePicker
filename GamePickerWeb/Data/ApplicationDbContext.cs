using GamePickerWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GamePickerWeb.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", Order = 1},
            new Category { Id = 2, Name = "Shooter", Order = 2},
            new Category { Id = 3, Name = "Sports", Order = 3}
            );
    }
}