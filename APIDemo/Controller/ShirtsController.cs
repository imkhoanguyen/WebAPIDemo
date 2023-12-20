using APIDemo.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {
        private List<Shirt> shirts = new List<Shirt>()
        {
            new Shirt{ShirtId = 1, Brand = "My Brand", Color = "Red", Gender = "Men", Price = 30, Size = 10},
            new Shirt{ShirtId = 2, Brand = "My Brand", Color = "Blue", Gender = "Men", Price = 45, Size = 42},
            new Shirt{ShirtId = 3, Brand = "My Brand", Color = "White", Gender = "Men", Price = 61, Size = 55},
            new Shirt{ShirtId = 4, Brand = "My Brand", Color = "Black", Gender = "Men", Price = 22, Size = 33}
        };
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all the shirts");
        }

        [HttpGet("{id}")]
        public IActionResult GetShirtById(int id)
        {
            var shirt = shirts.FirstOrDefault(x => x.ShirtId == id);
            if(shirt == null) return NotFound();
            return Ok(shirt);
        }
        [HttpPost]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            return Ok("Create shirt");
        }
        [HttpPut("{id}")]
        public IActionResult UpdateShirt(int id)
        {
            return Ok($"Updating shirt: {id}");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting shirt: {id}");
        }
    }
}
