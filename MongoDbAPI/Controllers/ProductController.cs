using Microsoft.AspNetCore.Mvc;
using MongoDbAPI.Models;
using MongoDbAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDbAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class ProductController : Controller
    {
        private IProductCollection db = new ProductCollection();

        [HttpGet]
        public async Task<IActionResult> GetAllProduct()
        {
            return Ok(await db.GetAllProduct());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetaills(string id)
        {
            return Ok(await db.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (product.Name == string.Empty)
            {
                ModelState.AddModelError("Name", "The product shouldn't be empty");
            }

            await db.InsertProduct(product);

            return Created("Created", true);

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct([FromBody] Product product, string id)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (product.Name == string.Empty)
            {
                //ModelState.AddModelError("Name", "The product shouldn't be empty");
                ModelState.AddModelError("Name", "Cambio de mensajes");
            }

            product.Id = new MongoDB.Bson.ObjectId(id);
            await db.UpdateProduct(product);

            return Created("Created", true);

        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await db.DeleteProduct(id);

            return NoContent();
        }
    }
}
