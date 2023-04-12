public interface IProductService
{
    Task<IEnumerable<Product>> GetAllProducts();
    Task<Product> GetProductById(int id);
    Task AddProduct(Product product);
    Task<bool> UpdateProduct(Product product);
    Task UpdatePartialProduct(Product product);
    Task<bool> DeleteProduct(int id);
}