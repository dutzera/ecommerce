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
        [Route("order")]
        public class OrderController : ControllerBase
        {
            [HttpGet]
            [Route("")]
            public async Task<ActionResult<List<OrderModel>>> Get([FromServices] DataContext context)
            {
                var orders = await context.Order.Include(i => i.ordered_model).ToListAsync();
                return orders;
            }

            [HttpPost]
            [Route("new/order")]
            public async Task<ActionResult<OrderModel>> Post(
                [FromServices] DataContext context,
                [FromBody]OrderModel model)
            {
                if (ModelState.IsValid)
                {
                    Console.WriteLine(model);
                    context.Order.Add(model);
                    context.SaveChanges();
                    foreach (var ordered_product in model.products)
                    {
                        var product = context.Products.Find(ordered_product);
                        product.prod_Amount--;
                        context.Products.Update(product);
                        context.Ordered_list.Add( new OrderedModel { 
                            fk_order_id = model.order_id,
                            fk_product_id = ordered_product
                        });
                    }
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
