using Microsoft.EntityFrameworkCore;

namespace AnimalShelter.Models
{
  public class AnimalShelterContext : DbContext
  {
    public DbSet<Pet> Pets { get; set; }

    public AnimalShelterContext(DbContextOptions<AnimalShelterContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder) //seeding data into our database/ On model creation 
    {
      builder.Entity<Pet>()
        .HasData(
          new Pet { PetId = 1, Name = "Jackie", Species = "Cat", Breed = "Tortie", Color = "Brown and Black", Age = 5 },
          new Pet { PetId = 2, Name = "Spike", Species = "Dog", Breed = "Labrador", Color = "Yellow", Age = 11 },
          new Pet { PetId = 3, Name = "Felix", Species = "Cat", Breed = "Tuxedo", Color = "Black and White", Age = 3 },
          new Pet { PetId = 4, Name = "Poppins", Species = "Dog", Breed = "Schnauzer", Color = "White", Age = 24 },
          new Pet { PetId = 5, Name = "Benny", Species = "Dog", Breed = "Bulldog", Color = "Brown and White", Age = 12 }
        );
    }
  }
}
