using ProductAPI.Utilities;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<IEnumerable<Product>> GetAllProducts()
    {
        try
        {
            return await _productRepository.GetAll();
        }
        catch (Exception ex)
        {
            // Log the exception
            throw new ServiceException("Error retrieving products", ex);
        }
    }

    public async Task<Product> GetProductById(int id)
    {
        try
        {
            return await _productRepository.Get(id);
        }
        catch (Exception ex)
        {
            // Log the exception
            throw new ServiceException($"Error retrieving product with id {id}", ex);
        }
    }

    public async Task AddProduct(Product product)
    {
        try
        {
            await _productRepository.Create(product);
        }
        catch (Exception ex)
        {
            // Log the exception
            throw new ServiceException("Error adding product", ex);
        }
    }

    public async Task<bool> UpdateProduct(Product product)
    {
        try
        {
            return await _productRepository.Update(product);
        }
        catch (Exception ex)
        {
            // Log the exception
            throw new ServiceException($"Error updating product with id {product.Id}", ex);
        }
    }

    public async Task<bool> DeleteProduct(int id)
    {
        try
        {
            return await _productRepository.Delete(id);
        }
        catch (Exception ex)
        {
            // Log the exception
            throw new ServiceException($"Error deleting product with id {id}", ex);
        }
    }

    public async Task UpdatePartialProduct(Product product)
    {
        try
        {
            await _productRepository.UpdatePartial(product);
        }
        catch (Exception ex)
        {
            // Log the exception
            throw new ServiceException($"Error updating product with id {product.Id}", ex);
        }
    }
}
