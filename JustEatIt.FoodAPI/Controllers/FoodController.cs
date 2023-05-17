using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JustEatIt.FoodAPI.Models;
using JustEatIt.FoodAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JustEatIt.FoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private IFoodService _foodService;

        public FoodController(IFoodService foodService)
        {
            _foodService = foodService;
        }
        
        // GET: api/<FoodController>
        [HttpGet]
        public async Task<List<Food>> Get()
        {
            var foods = await _foodService.GetAllFoods();
            return foods;
        }

        // GET api/<FoodController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var food = await _foodService.GetFoodById(id);

            if (food == null)
            {
                return NotFound();
            }
            return Ok(food);
        }

        // POST api/<FoodController>
        [HttpPost]
        public async Task<IActionResult> CreateFood([FromBody] Food food)
        {
            if (food == null)
            {
                return BadRequest();
            }

            await _foodService.CreateFood(food);
            
            return Ok();
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Food food)
        {
            if (id != food.Id)
            {
                return BadRequest();
            }
            var existingFood = await _foodService.GetFoodById(id);
            if (existingFood == null)
            {
                return NotFound();
            }

            await _foodService.UpdateFood(food);
            return NoContent();
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var existingFood = await _foodService.GetFoodById(id);
            if (existingFood == null)
            {
                return NotFound();
            }

            await _foodService.DeleteFood(id);
            return NoContent();
        }
    }
}
