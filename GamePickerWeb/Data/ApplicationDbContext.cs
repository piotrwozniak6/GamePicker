using GamePickerWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace GamePickerWeb.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
}