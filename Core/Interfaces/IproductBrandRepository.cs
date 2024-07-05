using Core.Entities;

namespace Core.Interfaces
{
    public interface IproductBrandRepository
    {
        public Task<IReadOnlyList<ProductBrand>> productBrands();
    }
}