using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimpleBasket.API.Dtos;
using SimpleBasket.API.Services;

namespace SimpleBasket.API.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController: ControllerBase
    {
        private readonly ISimpleBasketRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(ISimpleBasketRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<ProductDto> GetProducts()
        {
            var productsFromRepo = _repository.GetProducts();
            var dtos = _mapper.Map<IEnumerable<ProductDto>>(productsFromRepo);

            return Ok(dtos);
        }

        [HttpGet("freight/{orderAmount:decimal}")]
        public ActionResult<decimal> CalculateFreight(decimal orderAmount)
        {
            var freight = _repository.CalculateFreight(orderAmount);

            return Ok(freight);
        }
    }
}
