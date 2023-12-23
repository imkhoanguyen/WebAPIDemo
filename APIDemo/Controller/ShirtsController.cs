using APIDemo.Filters.ActionFilters;
using APIDemo.Filters.ExceptionFilters;
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
            return Ok(ShirtRepository.GetShirts());
        }

        [HttpGet("{id}")]
        [Shirt_ValidateShirtIdFilter]
        public IActionResult GetShirtById(int id)
        {
            return Ok(ShirtRepository.GetShirtById(id));
        }

        [HttpPost]
        [Shirt_ValidateCreateShirtFilter]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            ShirtRepository.AddShirt(shirt);
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }
        [HttpPut("{id}")]
        [Shirt_ValidateShirtIdFilter]
        [Shirt_ValidateUpdateShirtFilter]
        [Shirt_HandleUpdateExceptionsFilter]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            if (id != shirt.ShirtId) return BadRequest();

            ShirtRepository.UpdateShirt(shirt);

            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteShirt(int id)
        {
            return Ok($"Deleting shirt: {id}");
        }
    }
}
