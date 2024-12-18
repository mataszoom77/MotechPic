using Microsoft.EntityFrameworkCore;
using MotechPicFront.Server.Data;
using MotechPicFront.Server.Models;

namespace MotechPicFront.Server.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MotechPicContext _context;

        public ProductRepository(MotechPicContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .AsNoTracking() // Prevent EF Core from tracking this instance
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task AddProductAsync(Product product)
        {
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            var existingProduct = await _context.Products.AsNoTracking()
                .FirstOrDefaultAsync(p => p.Id == product.Id);

            if (existingProduct == null)
                throw new KeyNotFoundException($"Product with ID {product.Id} not found.");

            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }


        public async Task DeleteProductAsync(int id)
        {
            var product = await GetProductByIdAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }
    }
}
