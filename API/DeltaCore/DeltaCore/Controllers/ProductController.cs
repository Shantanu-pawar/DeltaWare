using DeltaCore.Models;
using DeltaCore.ServiceLayer;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeltaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _service;

        public ProductController(IMapper mapper, IProductService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts()
        {
            var products = await _service.GetProducts();
            var records = _mapper.Map<List<Product>>(products);
            return Ok(records);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(ProductRequestDto productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // You may want to use AutoMapper or manual mapping here
            var product = new Product
            {
                ProductId = productDto.ProductId,
                Name = productDto.Name,
                Description = productDto.Description
                // Other properties
            };

            await _service.CreateProduct(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Additional action to retrieve a single product by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            var product = await _service.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            var productDto = _mapper.Map<Product>(product);
            return Ok(productDto);
        }
    }

    public class ProductRequestDto
    {
        public string ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        // Other properties if needed
    }
}
