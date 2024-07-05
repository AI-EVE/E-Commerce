using Core.EndPointsParams;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync(GetProductsParams getProductsParams);
        Task<int> GetProductsCountAsync(GetProductsParams getProductsParams);
        
    }
}