using CRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        List<Product> Products = new List<Product>
        {
            new Product {Id=1,Name="Mahmoud1",Discription="This Is mahmoud1"},
            new Product {Id=2,Name="Mahmoud2",Discription="This Is mahmoud2"},
            new Product {Id=3,Name="Mahmoud3",Discription="This Is mahmoud3"}
        };

        [HttpGet("")]
        public IActionResult GetAll()
        {
            return Ok(Products);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = Products.First(product => product.Id == id);
            if(product is null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpPost]
        public IActionResult Add(Product request) 
        { 
            if(request is null)
            {
                return BadRequest();
            }
            var product = new Product 
            { 
                Id = request.Id,
                Name = request.Name,
                Discription = request.Discription
            };
            Products.Add(product);
            return Ok(product);
        }

        [HttpPut]
        public IActionResult Update(int id,Product request)
        {
            var currentProduct = Products.First(product => product.Id == id);
            if(currentProduct is null) {
                return NotFound();
            }
            currentProduct.Name = request.Name;
            currentProduct.Discription = request.Discription;

            return Ok(currentProduct);
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var product = Products.First(product => product.Id == id);
            if (product is null)
            {
                return NotFound();
            }
            Products.Remove(product);

            return Ok(product);
        }
    }
}
