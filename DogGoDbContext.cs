using DogGo.Models;
using Microsoft.EntityFrameworkCore;
namespace DogGo.Data;

public class DogGoDbContext : DbContext
{
    public DbSet<Neighborhood> Neighborhoods { get; set; }
    public DbSet<Dog> Dogs { get; set; }
    public DbSet<Owner> Owners { get; set; }
    public DbSet<Walk> Walks { get; set; }
    public DbSet<Walker> Walkers { get; set; }
    public DbSet<WalkDog> WalkDogs { get; set; }

    public DogGoDbContext(DbContextOptions<DogGoDbContext> context) : base(context)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<WalkDog>()
            .HasKey(wd => new { wd.WalkId, wd.DogId });

        modelBuilder.Entity<WalkDog>()
            .HasOne(wd => wd.Walk)
            .WithMany(w => w.WalkDogs)
            .HasForeignKey(wd => wd.WalkId);

        modelBuilder.Entity<WalkDog>()
            .HasOne(wd => wd.Dog)
            .WithMany(d => d.WalkDogs)
            .HasForeignKey(wd => wd.DogId);
        // seed data with campsite types
        modelBuilder.Entity<Neighborhood>().HasData(new Neighborhood[]
        {
            new Neighborhood {Id = 1, Name = "East Nashville"},
            new Neighborhood {Id = 2, Name = "Antioch"},
            new Neighborhood {Id = 3, Name = "Berry Hill"},
            new Neighborhood {Id = 4, Name = "Germantown"},
            new Neighborhood {Id = 5, Name = "The Gulch"},
            new Neighborhood {Id = 6, Name = "Downtown"},
            new Neighborhood {Id = 7, Name = "Music Row"},
            new Neighborhood {Id = 8, Name = "Hermitage"},
            new Neighborhood {Id = 9, Name = "Madison"},
            new Neighborhood {Id = 10, Name = "Green Hills"},
            new Neighborhood {Id = 11, Name = "Midtown"},
            new Neighborhood {Id = 12, Name = "West Nashville"},
            new Neighborhood {Id = 13, Name = "Donelson"},
            new Neighborhood {Id = 14, Name = "North Nashville"},
            new Neighborhood {Id = 15, Name = "Belmont-Hillsboro"}
        });

        modelBuilder.Entity<Owner>().HasData(new Owner[]
        {
            new Owner {Id = 1, Name="John Sanchez", Email="john@gmail.com", Address="355 Main St", Phone="(615)-553-2456",NeighborhoodId= 1},
            new Owner {Id = 2, Name="Patricia Young", Email="patty@gmail.com", Address="355 Main St", Phone="(615)-553-2456",NeighborhoodId= 2},
            new Owner {Id = 3, Name="Robert Brown", Email="robert@gmail.com", Address="355 Main St", Phone="(615)-553-2456",NeighborhoodId= 3},
            new Owner {Id = 4, Name="Jennifer Wilson", Email="jennifer@gmail.com", Address="355 Main St", Phone="(615)-553-2456",NeighborhoodId= 1},
            new Owner {Id = 5, Name="Michael Moore", Email="michael@gmail.com", Address="355 Main St", Phone="(615)-553-2456",NeighborhoodId= 2},
            new Owner {Id = 6, Name="Linda Green", Email="linda@gmail.com", Address="355 Main St", Phone="(615)-553-2456",NeighborhoodId= 3},
            new Owner {Id = 7, Name="William Anderson", Email="william@gmail.com", Address="355 Main St", Phone="(615)-553-2456",NeighborhoodId= 1}
        });

        modelBuilder.Entity<Dog>().HasData(new Dog[]
        {
            new Dog {Id = 1, Name="Ninni", OwnerId = 1, Breed="Rottweiler"},
            new Dog {Id = 2, Name="Kuma", OwnerId = 1, Breed="Rottweiler"},
            new Dog {Id = 3, Name="Remy", OwnerId = 2, Breed="Greyhound"},
            new Dog {Id = 4, Name="Xyla", OwnerId = 3, Breed="Dalmation"},
            new Dog {Id = 5, Name="Chewy", OwnerId = 3, Breed="Beagle"},
            new Dog {Id = 6, Name="Groucho", OwnerId = 4, Breed="Dalmation"},
            new Dog {Id = 7, Name="Finley", OwnerId = 5, Breed="Golden Retriever"},
            new Dog {Id = 8, Name="Casper", OwnerId = 6, Breed="Golden Retriever"},
            new Dog {Id = 9, Name="Bubba", OwnerId = 7, Breed="English Bulldog"},
            new Dog {Id = 10, Name="Zeus", OwnerId = 7, Breed="Schnauzer"}
        });

        modelBuilder.Entity<Walker>().HasData(new Walker[]
        {
            new Walker {Id=1, Name="Claudelle", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=15},
            new Walker {Id=2, Name="Roi", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=9},
            new Walker {Id=3, Name="Shena", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=10},
            new Walker {Id=4, Name="Gibb", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=8},
            new Walker {Id=5, Name="Tammy", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=6},
            new Walker {Id=6, Name="Rufe", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=11},
            new Walker {Id=7, Name="Cassandry", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=12},
            new Walker {Id=8, Name="Cully", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=4},
            new Walker {Id=9, Name="Cully", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=14},
            new Walker {Id=10, Name="Agnesse", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=1},
            new Walker {Id=11, Name="Koo", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=7},
            new Walker {Id=12, Name="Diana", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=6},
            new Walker {Id=13, Name="Moreen", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=7},
            new Walker {Id=14, Name="Sonni", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=13},
            new Walker {Id=15, Name="Nadiya", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=9},
            new Walker {Id=16, Name="Olag", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=12},
            new Walker {Id=17, Name="Alasdair", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=12},
            new Walker {Id=18, Name="Jo ann", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=12},
            new Walker {Id=19, Name="Ewen", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=6},
            new Walker {Id=20, Name="Andee", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=5},
            new Walker {Id=21, Name="Sada", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=12},
            new Walker {Id=22, Name="Tasia", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=3},
            new Walker {Id=23, Name="Sherry", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=5},
            new Walker {Id=24, Name="Witty", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=6},
            new Walker {Id=25, Name="Ezekiel", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=5},
            new Walker {Id=26, Name="Emmeline", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=1},
            new Walker {Id=27, Name="Darrick", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=9},
            new Walker {Id=28, Name="Redford", ImageUrl="https://avatars.dicebear.com/v2/female/c117aa483c649ecbc46c6d65172bf6e6.svg", NeighborhoodId=14}
        });

    }

}