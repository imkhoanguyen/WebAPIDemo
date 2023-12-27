using APIDemo.Data;
using APIDemo.Filters.ActionFilters;
using APIDemo.Filters.ExceptionFilters;
using APIDemo.Model;
using APIDemo.Model.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIDemo.Controller
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ShirtsController : ControllerBase
    {
        private readonly ApplicationDbContext db;

        public ShirtsController(ApplicationDbContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public IActionResult GetShirts()
        {
            return Ok(db.Shirts.ToList());
        }

        [HttpGet("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult GetShirtById(int id)
        {
            return Ok(HttpContext.Items["shirts"]);
        }

        [HttpPost]
        [TypeFilter(typeof(Shirt_ValidateCreateShirtFilterAttribute))]
        public IActionResult CreateShirt([FromBody] Shirt shirt)
        {
            db.Shirts.Add(shirt);
            db.SaveChanges();
            return CreatedAtAction(nameof(GetShirtById),
                new { id = shirt.ShirtId },
                shirt);
        }
        [HttpPut("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        [Shirt_ValidateUpdateShirtFilter]
        [TypeFilter(typeof(Shirt_HandleUpdateExceptionsFilterAttribute))]
        public IActionResult UpdateShirt(int id, Shirt shirt)
        {
            var shirtToUpdate = HttpContext.Items["shirts"] as Shirt;
            shirtToUpdate.Brand = shirt.Brand;
            shirtToUpdate.Price = shirt.Price;
            shirtToUpdate.Gender = shirt.Gender;
            shirtToUpdate.Color = shirt.Color;
            shirtToUpdate.Size = shirt.Size;

            db.Update(shirtToUpdate);
            db.SaveChanges();

            return NoContent();
        }
        [HttpDelete("{id}")]
        [TypeFilter(typeof(Shirt_ValidateShirtIdFilterAttribute))]
        public IActionResult DeleteShirt(int id)
        {
            var shirtToDelete = HttpContext.Items["shirts"] as Shirt;
            db.Remove(shirtToDelete);
            db.SaveChanges();

            return Ok(shirtToDelete);
        }
    }
}
