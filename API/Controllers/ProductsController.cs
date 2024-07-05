using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.EndPointsParams;
using Core.Entities;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IProductRepository _productRepo;
        private readonly IMapper _mapper;
        private readonly IProductTypeRepository _productTypeRepo;
        private readonly IproductBrandRepository _productBrandRepo;
        public ProductsController(IProductRepository productRepo, IProductTypeRepository typeRepo,IproductBrandRepository brandRepo , IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
            _productTypeRepo = typeRepo;
            _productBrandRepo = brandRepo;

        }
        
    
        [HttpGet]
        public async Task<ActionResult<Pagination<ProdcutDTO>>> GetProducts([FromQuery] GetProductsParams getProductsParams)
        {
            var products = await _productRepo.GetProductsAsync(getProductsParams);
            var productsDTO = _mapper.Map<IReadOnlyList<ProdcutDTO>>(products);
            var count = await _productRepo.GetProductsCountAsync(getProductsParams);
            var paginationToSend = new Pagination<ProdcutDTO>(getProductsParams.PageNum, getProductsParams.PageSize, productsDTO)
            {
                Count = count
            };

            return paginationToSend;
        }

     

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            var productBrands = await _productBrandRepo.productBrands();
            return Ok(productBrands);
        }

        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            var productTypes = await _productTypeRepo.ProductTypes();
            return Ok(productTypes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdcutDTO>> GetProduct(int id)
        {
            var product = await _productRepo.GetProductByIdAsync(id);

            return _mapper.Map<ProdcutDTO>(product);
        }
    }
}