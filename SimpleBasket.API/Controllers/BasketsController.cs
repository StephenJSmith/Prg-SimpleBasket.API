using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleBasket.API.Dtos;
using SimpleBasket.API.Entities;
using SimpleBasket.API.Services;

namespace SimpleBasket.API.Controllers
{
    [ApiController]
    [Route("api/baskets")]
    public class BasketsController: ControllerBase
    {
        private readonly ISimpleBasketRepository _repository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IMapper _mapper;

        public BasketsController(
            ISimpleBasketRepository repository,
            IAuthenticationService authenticationService,
            IMapper mapper)
        {
            _repository = repository;
            _authenticationService = authenticationService;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult SubmitBasket(IEnumerable<OrderItemForSubmitDto> orderItemDtos)
        {
            var authenticatedUserId = _authenticationService.GetAuthenticatedUserId();
            var orderItems = _mapper.Map<IEnumerable<OrderItem>>(orderItemDtos);
            var currentDateTime = System.DateTime.Now;

            _repository.SubmitOrder(authenticatedUserId, currentDateTime, orderItems);

            // TODO: Create a named Get so can return a CreatedAtRoute()
            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
