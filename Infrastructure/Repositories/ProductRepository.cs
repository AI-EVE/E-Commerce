using Core.EndPointsParams;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        SiteContext _context;
        public ProductRepository(SiteContext context)
        {
            _context = context;
        }
    
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Type)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(GetProductsParams getProductsParams)
        {         

            var query = _context.Products.AsQueryable();
            var skip = (getProductsParams.PageNum - 1) * getProductsParams.PageSize;
            var take = getProductsParams.PageSize;

            if (getProductsParams.BrandId.HasValue)
            {
                query = query.Where(p => p.ProductBrandId == getProductsParams.BrandId);
            }

            if (getProductsParams.TypeId.HasValue)
            {
                query = query.Where(p => p.ProductTypeId == getProductsParams.TypeId);
            }

            if (!string.IsNullOrEmpty(getProductsParams.Search))
            {
                query = query.Where(p => p.Name.ToLower().Contains(getProductsParams.Search.ToLower()));
            }


            return getProductsParams.SortedBy switch
            {
                "priceAsc" => await query
                    .OrderBy(p => p.Price)
                    .Skip(skip).Take(take)
                    .Include(p => p.Brand)
                    .Include(p => p.Type)
                    .ToListAsync(),
                "priceDesc" => await query
                    .OrderByDescending(p => p.Price)
                    .Skip(skip).Take(take)
                    .Include(p => p.Brand)
                    .Include(p => p.Type)
                    .ToListAsync(),
                _ => await query
                    .OrderBy(p => p.Id)
                    .Skip(skip).Take(take)
                    .Include(p => p.Brand)
                    .Include(p => p.Type)
                    .ToListAsync()
            };
        }
    }
}