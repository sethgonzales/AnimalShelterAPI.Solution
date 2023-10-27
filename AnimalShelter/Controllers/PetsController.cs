using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AnimalShelter.Models;

namespace AnimalShelter.Controllers
{
  [Route("api/[controller]")] 
  [ApiController]
  public class PetsController : ControllerBase
  {
    private readonly AnimalShelterContext _db;

    public PetsController(AnimalShelterContext db)
    {
      _db = db;
    }

    // GET: api/Pets
    [HttpGet]
    public async Task<ActionResult<PaginatedList<Pet>>> Get(string species, string name, string breed, string color, int minimumAge, int pageIndex = 1, int pageSize = 10)
    {
      IQueryable<Pet> query = _db.Pets.AsQueryable();
      if (species != null)
      {
        query = query.Where(entry => entry.Species == species);
      }
      if (name != null)
      {
        query = query.Where(entry => entry.Name == name);
      }
      if (breed != null)
      {
        query = query.Where(entry => entry.Breed == breed);
      }
      if (color != null)
      {
        query = query.Where(entry => entry.Color == color);
      }
      if (minimumAge > 0)
      {
        query = query.Where(entry => entry.Age >= minimumAge);
      }

      var paginatedPets = await PaginatedList<Pet>.CreateAsync(query, pageIndex, pageSize);

      if (paginatedPets.Count == 0)
      {
        return NotFound();
      }

      return paginatedPets;
    }

    // GET: api/Pets/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Pet>> GetPet(int id)
    {
      Pet pet = await _db.Pets.FindAsync(id);

      if (pet == null)
      {
        return NotFound();
      }

      return pet;
    }

    // POST api/Pets
    [HttpPost] 
    public async Task<ActionResult<Pet>> Post(Pet pet)
    {
      _db.Pets.Add(pet);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetPet), new { id = pet.PetId }, pet); 
    }

    // PUT: api/Pets/5
    [HttpPut("{id}")] 
    public async Task<IActionResult> Put(int id, Pet pet)
    {
      if (id != pet.PetId) 
      {
        return BadRequest(); 
      }

      _db.Pets.Update(pet); 

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException) 
      {
        if (!PetExists(id)) 
        {
          return NotFound(); 
        }
        else
        {
          throw; 
        }
      }

      return NoContent();
    }

    private bool PetExists(int id)
    {
      return _db.Pets.Any(e => e.PetId == id);
    }

    // DELETE: api/Pets/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
      Pet pet = await _db.Pets.FindAsync(id);
      if (pet == null)
      {
        return NotFound();
      }

      _db.Pets.Remove(pet);
      await _db.SaveChangesAsync();

      return NoContent();
    }

  }
}
