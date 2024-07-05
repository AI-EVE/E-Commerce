using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductTypeRepository
    {
        public Task<IReadOnlyList<ProductType>> ProductTypes();
    }
}