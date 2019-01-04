using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using NetCore22Demos.Models;
using NetCore22Demos.Data;

namespace NetCore22Demos.Controllers
{
    // Using the ApiConventionType attribute on a controller.
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly NetCore22DemosContext _core22DemosContext;

        private readonly List<Product> _products = new List<Product>
        {
            new Product
            {
                Id = 1,
                Name = "Product 1",
                Description = "Product 1 desc"
            },
            new Product
            {
                Id = 2,
                Name = "Product 2",
                Description = "Product 2 desc"
            },
            new Product
            {
                Id = 3,
                Name = "Product 3",
                Description = "Product 3 desc"
            }
        };

        public ProductController(NetCore22DemosContext core22DemosContext)
        {
            _core22DemosContext = core22DemosContext;
        }

        // GET api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _products;
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // POST api/products
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/products/5
        [ApiConventionMethod(typeof(DefaultApiConventions), nameof(DefaultApiConventions.Put))]
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // GET api/products/5
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Abc))]
        [HttpGet("[action]/{id}")]
        public ActionResult<Product> AbcProduct(int id)
        {
            var product = _products.Find(p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // GET api/ProductsFromDb
        [HttpGet("[action]")]
        public ActionResult<List<Product>> ProductsFromDb()
        {
            return _core22DemosContext.Products.ToList();
        }
    }
}
