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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<FoodController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<FoodController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<FoodController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
