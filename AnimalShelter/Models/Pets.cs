using System.ComponentModel.DataAnnotations;

namespace AnimalShelter.Models
{
  public class Pet
  {
    public int PetId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [StringLength(20)]
    [Required] 
    public string Species { get; set; }
    [StringLength(20)]
    [Required]
    public string Breed { get; set; }
    [StringLength(20)]
    [Required]
    public string Color { get; set; }
    [Required]
    [Range(0, 30, ErrorMessage = "Age must be between 0 and 30.")]
    public int Age { get; set; }
  }
}
