
//create the interface
public interface IProductRepository
{
    Task Create(Product product);
    Task<Product> Get(int id);
    Task<List<Product>> GetAll();
    Task<bool> Update(Product product);
    Task<bool> Delete(int id);
    Task<bool> UpdatePartial(Product product);
}
//public interface IProductRepository
//{
//    void Create(Product product);
//    Product Read(int id);
//    List<Product> ReadAll();
//    void Update(Product product);
//    void Delete(int id);
//}
//public class ProductRepository : IProductRepository
//{
//    private readonly ProductDbContext _context;

//    public ProductRepository(ProductDbContext context)
//    {
//        _context = context;
//    }

//    public void Create(Product product)
//    {
//        _context.Products.Add(product);
//        _context.SaveChanges();
//    }

//    public Product Read(int id)
//    {
//        return _context.Products.Find(id);
//    }

//    public List<Product> ReadAll()
//    {
//        return _context.Products.ToList();
//    }

//    public void Update(Product product)
//    {
//        _context.Products.Update(product);
//        _context.SaveChanges();
//    }

//    public void Delete(int id)
//    {
//        var product = _context.Products.Find(id);
//        _context.Products.Remove(product);
//        _context.SaveChanges();
//    }
//}
