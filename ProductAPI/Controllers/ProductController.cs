using Microsoft.AspNetCore.Mvc;
using ProductAPI.Utilities;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

[ApiController]
//[Route("api/products")]
[ApiVersion("1")]
[Route("api/v{version:apiVersion}/products")]
public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllProducts()
    {
        try
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }
        catch (ServiceException ex)
        {
            // Log the exception
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductById(int id)
    {
        try
        {
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        catch (ServiceException ex)
        {
            // Log the exception
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> AddProduct([FromBody] Product product)
    {
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
    {
        try
        {
            if (id != product.Id)
                return BadRequest();

            var updated = await _productService.UpdateProduct(product);
            
            if (updated == false)
                return NotFound();

            return NoContent();
        }
        catch (ServiceException ex)
        {
            // Log the exception
            return StatusCode(500, ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        try
        {
            var deleted = await _productService.DeleteProduct(id);
            
            if (deleted == false)
                return NotFound();

            return NoContent();
        }
        catch (ServiceException ex)
        {
            // Log the exception
            return StatusCode(500, ex.Message);
        }
    }
}
