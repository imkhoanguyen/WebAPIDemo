using APIDemo.Data;
using APIDemo.Model;
using APIDemo.Model.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Drawing;
using System.Reflection;

namespace APIDemo.Filters.ActionFilters
{
    public class Shirt_ValidateCreateShirtFilterAttribute : ActionFilterAttribute
    {
        private readonly ApplicationDbContext db;

        public Shirt_ValidateCreateShirtFilterAttribute(ApplicationDbContext db)
        {
            this.db = db;
        }
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            var shirt = context.ActionArguments["shirt"] as Shirt;

            if (shirt == null)
            {
                context.ModelState.AddModelError("Shirt", "Shirt is null.");
                var problemDetail = new ValidationProblemDetails(context.ModelState)
                {
                    Status = StatusCodes.Status400BadRequest,
                };
                context.Result = new BadRequestObjectResult(problemDetail);
            }
            else if (shirt != null)
            {
                // check trung thuoc tinh
                var existingShirt = db.Shirts.FirstOrDefault(x =>
            !string.IsNullOrWhiteSpace(shirt.Brand) &&
            !string.IsNullOrWhiteSpace(x.Brand) &&
            x.Brand.ToLower() == shirt.Brand.ToLower() &&
            !string.IsNullOrWhiteSpace(shirt.Color) &&
                !string.IsNullOrWhiteSpace(x.Color) &&
            x.Color.ToLower() == shirt.Color.ToLower() &&
            !string.IsNullOrWhiteSpace(shirt.Gender) &&
                !string.IsNullOrWhiteSpace(x.Gender) &&
            x.Gender.ToLower() == shirt.Gender.ToLower() &&
                shirt.Size.HasValue &&
            x.Size.HasValue &&
            x.Size.Value == shirt.Size.Value);
                if (existingShirt != null)
                {
                    context.ModelState.AddModelError("Shirt", "Shirt is contain.");
                    var problemDetail = new ValidationProblemDetails(context.ModelState)
                    {
                        Status = StatusCodes.Status400BadRequest,
                    };
                    context.Result = new BadRequestObjectResult(problemDetail);
                }
            }


        }
    }
}
