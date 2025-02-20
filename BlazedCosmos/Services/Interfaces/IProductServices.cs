using BlazedCosmos.Models;

using System.Collections.Generic;
using System.Threading.Tasks;
namespace BlazedCosmos.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<Product>> GetAllProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
    }
}