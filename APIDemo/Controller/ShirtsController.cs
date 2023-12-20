using APIDemo.Filters;
using APIDemo.Model;
using APIDemo.Model.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace APIDemo.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {
       
        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok("Reading all the shirts");
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
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
