using Microsoft.EntityFrameworkCore;

public class ProductRepository : IProductRepository
{
    private readonly ProductDbContext _context;
    public ProductRepository(ProductDbContext context)
    {
        _context = context;
    }
    public async Task Create(Product product)
    {
        await _context.Products.AddAsync(product);
        await _context.SaveChangesAsync();
    }
    public async Task<Product> Get(int id)
    {
        return await _context.Products.FindAsync(id);
    }
    public async Task<List<Product>> GetAll()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task<bool> Update(Product product)
    {
        var existingProduct = _context.Products.SingleOrDefault(p => p.Id == product.Id);
        if (existingProduct != null)
            _context.Products.Entry(existingProduct).CurrentValues.SetValues(product);
        else
            return false;

        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<bool> Delete(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
        return false;
    }

    public async Task<bool> UpdatePartial(Product updatedProduct)
    {

        var existingProduct = _context.Products.SingleOrDefault(p => p.Id == updatedProduct.Id);
        if (existingProduct == null)
        {
            return false;
        }

        // Update only the specified properties
        if (!string.IsNullOrEmpty(updatedProduct.Name))
        {
            existingProduct.Name = updatedProduct.Name;
        }
        if (!string.IsNullOrEmpty(updatedProduct.Description))
        {
            existingProduct.Description = updatedProduct.Description;
        }
        if (updatedProduct.Price > 0)
        {
            existingProduct.Price = updatedProduct.Price;
        }
        await _context.SaveChangesAsync();

        return true;
    }
}