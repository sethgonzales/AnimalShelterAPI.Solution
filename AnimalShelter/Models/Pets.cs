using System.ComponentModel.DataAnnotations; //this model has valid validation

namespace CretaceousApi.Models
{
  public class Pet
  {
    public int PetId { get; set; }
    [Required]
    [StringLength(20)]
    public string Name { get; set; }
    [Required]
    public string Species { get; set; }
    [Required]
    [Range(0, 200, ErrorMessage = "Age must be between 0 and 30.")]
    public int Age { get; set; }
  }

}
 