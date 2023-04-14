using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using ProductAPI.Utilities;

namespace ProductAPI.Controllers
{
    [ApiController]
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/products")]
    public class ProductsV2Controller : Controller
    {
        private readonly IProductService _productService;

        public ProductsV2Controller(IProductService productService)
        {
            _productService = productService;
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] Product product)
        {
            if (string.IsNullOrEmpty(product.Name))
            {
                return BadRequest("Product name cannot be empty.");
            }

            if (product.Price <= 0)
            {
                return BadRequest("Product price must be greater than zero.");
            }

            try
            {
                await _productService.AddProduct(product);
                return Accepted();
            }
            catch (ServiceException ex)
            {
                // Log the exception
                return StatusCode(500, ex.Message);
            }
        }

        //I have discovered a new approach for patching in .NET Core, but unfortunately, I do not have the availability to debug it at this time.

        //[HttpPatch("new/{id}")]
        //public async Task<IActionResult> UpdateProduct(int id, [FromBody] JsonPatchDocument<Product> patchDoc)
        //{

        //    // Get the product from the repository
        //    var product = await _productService.GetProductById(id);

        //    // Apply the patch to the product
        //    patchDoc.ApplyTo(product);

        //    // Save the updated product to the repository
        //    _productService.UpdateProduct(product);

        //    return Ok(product);
        //}


        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            if (id != product.Id)
            {
                return BadRequest();
            }
            await _productService.UpdatePartialProduct(product);
            return NoContent();
        }
    }
}
