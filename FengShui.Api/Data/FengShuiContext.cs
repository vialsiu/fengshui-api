//------the database, one dbset per table
using Microsoft.EntityFrameworkCore;
using FengShui.Api.Data.Seed;
using FengShui.Api.Models;

namespace FengShui.Api.Data;

/// <summary>
/// the ef core context for the fengshui database
/// </summary>
public class FengShuiContext(DbContextOptions<FengShuiContext> options) : DbContext(options)
{
    /// <summary>the players</summary>
    public DbSet<Player> Players { get; set; } = null!;
    /// <summary>the game's rooms and the ones players made</summary>
    public DbSet<Room> Rooms { get; set; } = null!;
    /// <summary>every kind of furniture</summary>
    public DbSet<FurnitureType> FurnitureTypes { get; set; } = null!;
    /// <summary>the feng shui rules</summary>
    public DbSet<Rule> Rules { get; set; } = null!;
    /// <summary>the clients</summary>
    public DbSet<Client> Clients { get; set; } = null!;
    /// <summary>the requests to fix a room</summary>
    public DbSet<Request> Requests { get; set; } = null!;
    /// <summary>what each client owns for each request</summary>
    public DbSet<InventoryItem> InventoryItems { get; set; } = null!;
    /// <summary>start, example and saved layouts</summary>
    public DbSet<Layout> Layouts { get; set; } = null!;
    /// <summary>every piece in every layout</summary>
    public DbSet<Placement> Placements { get; set; } = null!;

    /// <summary>
    /// extra setup ef can't work out on its own
    /// </summary>
    /// <param name="modelBuilder">used to set up the tables</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        //---codes and api keys get looked up a lot and can't repeat, so they get a unique index
        //-----ref https://learn.microsoft.com/en-us/ef/core/modeling/indexes
        modelBuilder.Entity<FurnitureType>().HasIndex(f => f.Code).IsUnique();
        modelBuilder.Entity<Rule>().HasIndex(r => r.Code).IsUnique();
        modelBuilder.Entity<Player>().HasIndex(p => p.ApiKey).IsUnique();

        //-------a client can only list each kind of furniture once per request
        modelBuilder.Entity<InventoryItem>()
            .HasIndex(i => new { i.RequestId, i.FurnitureTypeId })
            .IsUnique();

        //----the game's starting content, the arrays live in the Seed folder
        //--ref https://learn.microsoft.com/en-us/ef/core/modeling/data-seeding#model-managed-data
        modelBuilder.Entity<FurnitureType>().HasData(FurnitureTypeSeed.All);
        modelBuilder.Entity<Rule>().HasData(RuleSeed.All);
        //--------rooms, clients, then the requests and inventory that point at them (ef sorts out the insert order itself)
        modelBuilder.Entity<Room>().HasData(RoomSeed.All);
        modelBuilder.Entity<Client>().HasData(ClientSeed.All);
        modelBuilder.Entity<Request>().HasData(RequestSeed.All);
        modelBuilder.Entity<InventoryItem>().HasData(InventoryItemSeed.All);
        //---the messy rooms the player starts from
        modelBuilder.Entity<Layout>().HasData(LayoutSeed.All);
        modelBuilder.Entity<Placement>().HasData(PlacementSeed.All);
    }

    /// <summary>
    /// saves every enum as its name instead of a number, so the database is readable
    /// </summary>
    /// <param name="configurationBuilder">used to set the conventions</param>
    //------ref https://learn.microsoft.com/en-us/ef/core/modeling/bulk-configuration#pre-convention-configuration
    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<Enum>().HaveConversion<string>();
    }
}