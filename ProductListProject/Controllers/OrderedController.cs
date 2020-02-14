using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductListProject.Data;
using ProductListProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductListProject.Controllers
{
    [ApiController]
    [Route("ordered")]
    public class OrderedController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<OrderedModel>>> Get([FromServices] DataContext context)
        {
            var ordered = await context.Ordered_list.ToListAsync();
            return ordered;
        }

        [HttpPost]
        [Route("new/ordered")]
        public async Task<ActionResult<OrderedModel>> Post(
            [FromServices] DataContext context,
            [FromBody]OrderedModel model)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(model);

                context.Ordered_list.Add(model);
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
