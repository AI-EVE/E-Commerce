using Core.Entities;
using Core.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductTypeRepository : IProductTypeRepository
    {
        private SiteContext _context;
        public ProductTypeRepository(SiteContext context)
        {
            _context = context;
        }
        public async Task<IReadOnlyList<ProductType>> ProductTypes()
        {
            return await _context.Types.ToListAsync();   
        }
    }
}