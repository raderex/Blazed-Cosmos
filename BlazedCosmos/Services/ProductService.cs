using BlazedCosmos.Models;
using BlazedCosmos.Data;
using Microsoft.EntityFrameworkCore;
using BlazedCosmos.Services.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BlazedCosmos.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }
    }
}