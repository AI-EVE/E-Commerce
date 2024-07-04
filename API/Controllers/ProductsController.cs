using API.DTOs;
using API.Helpers;
using AutoMapper;
using Core.EndPointsParams;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {
        IProductRepository _ProductRepo;
        IMapper _mapper;
        public ProductsController(IProductRepository ProductRepo, IMapper mapper)
        {
            _ProductRepo = ProductRepo;
            _mapper = mapper;
        }
        
    
        [HttpGet]
        public async Task<ActionResult<Pagination<ProdcutDTO>>> GetProducts([FromQuery] GetProductsParams getProductsParams)
        {
            var products = await _ProductRepo.GetProductsAsync(getProductsParams);
            var productsDTO = _mapper.Map<IReadOnlyList<ProdcutDTO>>(products);
            
            return new Pagination<ProdcutDTO>(getProductsParams.PageNum, getProductsParams.PageSize, productsDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ProdcutDTO>> GetProduct(int id)
        {
            var product = await _ProductRepo.GetProductByIdAsync(id);

            return _mapper.Map<ProdcutDTO>(product);
        }

    }
}