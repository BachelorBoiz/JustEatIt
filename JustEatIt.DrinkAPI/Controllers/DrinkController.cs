using JustEatIt.DrinkAPI.Models;
using JustEatIt.DrinkAPI.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace JustEatIt.DrinkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinkController : ControllerBase
    {
        private IDrinkService _drinkService;

        public DrinkController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }


        // GET: api/<DrinkController>
        [HttpGet]
        public async Task<List<Drink>> Get()
        {
            var drinks = await _drinkService.GetAllDrinks();

            return drinks;
        }

        // GET api/<DrinkController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var drink = await _drinkService.GetDrinkById(id);
            if (drink == null)
            {
                return NotFound();
            }

            return Ok(drink);
        }

        // POST api/<DrinkController>
        [HttpPost]
        public IActionResult CreateDrink([FromBody] Drink drink)
        {
            if (drink == null)
            {
                return BadRequest();
            }

            _drinkService.CreateDrink(drink);

            return Ok();
        }

        // PUT api/<DrinkController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Drink drink)
        {
            if (id != drink.Id)
            {
                return BadRequest();
            }

            var existingDrink = await _drinkService.GetDrinkById(id);
            if (existingDrink == null)
            {
                return NotFound();
            }

            await _drinkService.UpdateDrink(drink);
            return NoContent();
        }

        // DELETE api/<DrinkController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingDrink = await _drinkService.GetDrinkById(id);
            if (existingDrink == null)
            {
                return NotFound();
            }

            await _drinkService.DeleteDrink(id);
            return NoContent();
        }
    }
}
