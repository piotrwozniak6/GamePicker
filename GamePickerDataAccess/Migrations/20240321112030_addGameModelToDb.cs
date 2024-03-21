using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GamePickerWeb.Migrations
{
    /// <inheritdoc />
    public partial class addGameModelToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "GameModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Publisher = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegularPrice = table.Column<double>(type: "float", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Price50 = table.Column<double>(type: "float", nullable: false),
                    Price100 = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameModels", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "GameModels",
                columns: new[] { "Id", "Description", "Price", "Price100", "Price50", "Publisher", "RegularPrice", "Title" },
                values: new object[,]
                {
                    { 1, "Ghost of Tsushima for PC is an award winning action adventure open world game, with a third-person player perspective. It is set in ancient feudal Japan, but the issues faced by the protagonist will be easily understood by Western, modern players.", 50.0, 40.0, 45.0, "PlayStation PC LLC", 50.0, "Ghost of Tsushima: Director's Cut" },
                    { 2, "Join Aloy as she braves a majestic but dangerous new frontier that holds mysterious new threats. This Complete Edition allows you to enjoy the critically acclaimed Horizon Forbidden West on PC in its entirety with bonus content, including the Burning Shores story expansion that picks up after the main game.", 50.0, 40.0, 45.0, "PlayStation PC LLC, Sony Interactive Entertainment", 50.0, "Horizon Forbidden West Complete Edition - Europe" },
                    { 3, "Winner of hundreds of accolades including The Game Awards Game of the Year and Golden Joystick Awards Ultimate Game of the Year, ELDEN RING is the acclaimed action RPG epic set in a vast, dark fantasy world. Players embark on an epic quest with the freedom to explore and adventure at their own pace.", 34.0, 28.0, 31.0, "BANDAI NAMCO Entertainment, FromSoftware, Inc.", 34.0, "Elden Ring - Shadow of the Erdtree - Europe" },
                    { 4, "Insurgency: Sandstorm is a team-based, tactical FPS based on lethal close quarters combat and objective-oriented multiplayer gameplay. Sequel to the indie breakout FPS Insurgency, Sandstorm is reborn, improved, expanded, and bigger in every way. Experience the intensity of modern combat where skill is rewarded, and teamwork wins the fight. Prepare for a hardcore depiction of combat with deadly ballistics, light attack vehicles, destructive artillery, and HDR audio putting the fear back into the genre.", 10.0, 8.0, 9.0, "Focus Entertainment", 10.0, "Insurgency: Sandstorm" },
                    { 5, "Battlefield 4 Premium Edition gives you new maps, modes, and more in one simple package. Complete challenging assignments to unlock new weapons. Dominate tactical challenges in a huge interactive environment — demolish buildings shielding your enemies, lead an assault from the back of a gun boat, or make a little C4 go a long way. In massive 64-player battles, use all your resources and play to your strengths to carve your own path to victory.", 9.0, 7.0, 8.0, "Electronic Arts", 9.0, "Battlefield 4: Premium Edition" },
                    { 6, "This game includes optional in-game purchases of virtual currency that can be used to acquire virtual in-game items, including a random selection of virtual in-game items.\nFC Points not available in Belgium.", 42.0, 35.0, 38.0, "Electronic Arts", 42.0, "EA Sports FC 24" },
                    { 7, "WrestleMania is the biggest event in sports entertainment, where Superstars become WWE Legends. Experience a gripping retelling of WrestleMania’s greatest moments in 2K Showcase of the Immortals, where you can relive a collection of some of the most unforgettable, career-defining matches.", 48.0, 40.0, 45.0, "Visual Concepts", 48.0, "WWE 2K24 - Europe" },
                    { 8, "Boxing is Back! Undisputed is an authentic boxing game developed with care by dedicated fight fans, alongside the professional boxing community.", 25.0, 20.0, 22.0, "Steel City Interactive", 25.0, "Undisputed" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GameModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);
        }
    }
}
