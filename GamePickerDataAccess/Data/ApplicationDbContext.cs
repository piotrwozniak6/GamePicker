using GamePickerModels.Models;
using Microsoft.EntityFrameworkCore;

namespace GamePickerDataAccess.Data;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options)
    {
        
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<GameModel> GameModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>().HasData(
            new Category { Id = 1, Name = "Action", Order = 1},
            new Category { Id = 2, Name = "Shooter", Order = 2},
            new Category { Id = 3, Name = "Sports", Order = 3}
            );
        
        modelBuilder.Entity<GameModel>().HasData(
            new GameModel
            {
                Id = 1,
                Title = "Ghost of Tsushima: Director's Cut",
                Description = "Ghost of Tsushima for PC is an award winning action adventure open world game, with a third-person player perspective. It is set in ancient feudal Japan, but the issues faced by the protagonist will be easily understood by Western, modern players.",
                Publisher = "PlayStation PC LLC",
                RegularPrice = 50,
                Price = 50,
                Price50 = 45,
                Price100 = 40,
                CategoryId = 1,
                ImageUrl = ""
            },
            new GameModel
            {
                Id = 2,
                Title = "Horizon Forbidden West Complete Edition - Europe",
                Description = "Join Aloy as she braves a majestic but dangerous new frontier that holds mysterious new threats. This Complete Edition allows you to enjoy the critically acclaimed Horizon Forbidden West on PC in its entirety with bonus content, including the Burning Shores story expansion that picks up after the main game.",
                Publisher = "PlayStation PC LLC, Sony Interactive Entertainment",
                RegularPrice = 50,
                Price = 50,
                Price50 = 45,
                Price100 = 40,
                CategoryId = 1,
                ImageUrl = ""
            },
            new GameModel
            {
                Id = 3,
                Title = "Elden Ring - Shadow of the Erdtree - Europe",
                Description = "Winner of hundreds of accolades including The Game Awards Game of the Year and Golden Joystick Awards Ultimate Game of the Year, ELDEN RING is the acclaimed action RPG epic set in a vast, dark fantasy world. Players embark on an epic quest with the freedom to explore and adventure at their own pace.",
                Publisher = "BANDAI NAMCO Entertainment, FromSoftware, Inc.",
                RegularPrice = 34,
                Price = 34,
                Price50 = 31,
                Price100 = 28,
                CategoryId = 1,
                ImageUrl = ""
            },
            new GameModel
            {
                Id = 4,
                Title = "Insurgency: Sandstorm",
                Description = "Insurgency: Sandstorm is a team-based, tactical FPS based on lethal close quarters combat and objective-oriented multiplayer gameplay. Sequel to the indie breakout FPS Insurgency, Sandstorm is reborn, improved, expanded, and bigger in every way. Experience the intensity of modern combat where skill is rewarded, and teamwork wins the fight. Prepare for a hardcore depiction of combat with deadly ballistics, light attack vehicles, destructive artillery, and HDR audio putting the fear back into the genre.",
                Publisher = "Focus Entertainment",
                RegularPrice = 10,
                Price = 10,
                Price50 = 9,
                Price100 = 8,
                CategoryId = 2,
                ImageUrl = ""
            },
            new GameModel
            {
                Id = 5,
                Title = "Battlefield 4: Premium Edition",
                Description = "Battlefield 4 Premium Edition gives you new maps, modes, and more in one simple package. Complete challenging assignments to unlock new weapons. Dominate tactical challenges in a huge interactive environment — demolish buildings shielding your enemies, lead an assault from the back of a gun boat, or make a little C4 go a long way. In massive 64-player battles, use all your resources and play to your strengths to carve your own path to victory.",
                Publisher = "Electronic Arts",
                RegularPrice = 9,
                Price = 9,
                Price50 = 8,
                Price100 = 7,
                CategoryId = 2,
                ImageUrl = ""
            },
            new GameModel
            {
                Id = 6,
                Title = "EA Sports FC 24",
                Description = "This game includes optional in-game purchases of virtual currency that can be used to acquire virtual in-game items, including a random selection of virtual in-game items.\nFC Points not available in Belgium.",
                Publisher = "Electronic Arts",
                RegularPrice = 42,
                Price = 42,
                Price50 = 38,
                Price100 = 35,
                CategoryId = 3,
                ImageUrl = ""
            },
            new GameModel
            {
                Id = 7,
                Title = "WWE 2K24 - Europe",
                Description = "WrestleMania is the biggest event in sports entertainment, where Superstars become WWE Legends. Experience a gripping retelling of WrestleMania’s greatest moments in 2K Showcase of the Immortals, where you can relive a collection of some of the most unforgettable, career-defining matches.",
                Publisher = "Visual Concepts",
                RegularPrice = 48,
                Price = 48,
                Price50 = 45,
                Price100 = 40,
                CategoryId = 3,
                ImageUrl = ""
            },
            new GameModel
            {
                Id = 8,
                Title = "Undisputed",
                Description = "Boxing is Back! Undisputed is an authentic boxing game developed with care by dedicated fight fans, alongside the professional boxing community.",
                Publisher = "Steel City Interactive",
                RegularPrice = 25,
                Price = 25,
                Price50 = 22,
                Price100 = 20,
                CategoryId = 3,
                ImageUrl = ""
            }
        );
    }
}