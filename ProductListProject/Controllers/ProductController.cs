using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProductListProject.Data;
using Microsoft.EntityFrameworkCore;

namespace ProductListProject.Controllers
{
    [ApiController]
    [Route("products")]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<ProductModel>>> Get([FromServices] DataContext context)
        {
            var products = await context.Products.ToListAsync();
            return products;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<ProductModel>> Get([FromServices] DataContext context,int id)
        {
            var product = await context.Products
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.prod_Id == id);
            return product;
        }

        [HttpPost]
        [Route("new/product")]
        public async Task<ActionResult<ProductModel>> Post(
            [FromServices] DataContext context, 
            [FromBody]ProductModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model);
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }


    }
}
