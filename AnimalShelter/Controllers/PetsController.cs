// using Microsoft.AspNetCore.Mvc;
// using Microsoft.EntityFrameworkCore;
// using AnimalShelter.Models;
// using CretaceousApi.Models;

// namespace AnimalShelter.Controllers
// {
//   [Route("api/[controller]")] /
//   [ApiController]
//   public class PetsController : ControllerBase
//   {
//     private readonly AnimalShelterContext _db;

//     public PetsController(AnimalShelterContext db)
//     {
//       _db = db;
//     }

//     // GET: api/Pets
//     [HttpGet]
//     public async Task<ActionResult<PaginatedList<Pet>>> Get(string species, string name, string breed, string color, int minimumAge, int pageIndex = 1, int pageSize = 10)
//     {
//       IQueryable<Pet> query = _db.Pets.AsQueryable();
//       if (species != null)
//       {
//         query = query.Where(entry => entry.Species == species);
//       }
//       if (name != null)
//       {
//         query = query.Where(entry => entry.Name == name);
//       }
//       if (breed != null)
//       {
//         query = query.Where(entry => entry.Breed == breed);
//       }
//       if (color != null)
//       {
//         query = query.Where(entry => entry.Color == color);
//       }
//       if (minimumAge > 0)
//       {
//         query = query.Where(entry => entry.Age >= minimumAge);
//       }

//       var paginatedAnimals = await PaginatedList<Animal>.CreateAsync(query, pageIndex, pageSize);

//       if (paginatedAnimals.Count == 0)
//       {
//         return NotFound();
//       }

//       return paginatedAnimals;

//     }

//     // GET: api/Pets/5
//     [HttpGet("{id}")]
//     public async Task<ActionResult<Animal>> GetAnimal(int id)
//     {
//       Animal animal = await _db.Animals.FindAsync(id);

//       if (animal == null)
//       {
//         return NotFound();
//       }

//       return animal;
//     }

//     // POST api/Pets
//     [HttpPost] //post request to create a new animal
//     public async Task<ActionResult<Animal>> Post(Animal animal)
//     {
//       _db.Animals.Add(animal);
//       await _db.SaveChangesAsync();
//       return CreatedAtAction(nameof(GetAnimal), new { id = animal.AnimalId }, animal); // GetAnimal states the controller name, second argument creates a new animal id, third argument is the resource variable name that was created by this action.
//     }

//     // PUT: api/Animals/5
//     [HttpPut("{id}")] //PUT action just edits
//     public async Task<IActionResult> Put(int id, Animal animal)
//     {
//       if (id != animal.AnimalId) //check that the id is the id for the animal we passed through
//       {
//         return BadRequest(); //if invalid send bad request
//       }

//       _db.Animals.Update(animal); //if it is valid update the animal in the database

//       try
//       {
//         await _db.SaveChangesAsync();
//       }
//       catch (DbUpdateConcurrencyException) //if an error is thrown by the database...
//       {
//         if (!AnimalExists(id)) //check to see if an animal in the database does not exist
//         {
//           return NotFound(); //if it doesnt, then not found
//         }
//         else
//         {
//           throw; //throw an error?
//         }
//       }

//       return NoContent();
//     }

//     private bool AnimalExists(int id)
//     {
//       return _db.Animals.Any(e => e.AnimalId == id);
//     }

//     // DELETE: api/Animals/5
//     [HttpDelete("{id}")]
//     public async Task<IActionResult> DeleteAnimal(int id)
//     {
//       Animal animal = await _db.Animals.FindAsync(id);
//       if (animal == null)
//       {
//         return NotFound();
//       }

//       _db.Animals.Remove(animal);
//       await _db.SaveChangesAsync();

//       return NoContent();
//     }

//   }
// }
