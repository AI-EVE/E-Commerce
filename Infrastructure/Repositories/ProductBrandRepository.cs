using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductBrandRepository : IproductBrandRepository
    {
        private SiteContext _context;
        public ProductBrandRepository(SiteContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<ProductBrand>> productBrands()
        {
            return await _context.Brands.ToListAsync();   
        }
    }

}