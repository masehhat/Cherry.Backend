using Cherry.Application.Common.Structures;
using Cherry.Application.FoodApplication.Commands.RestaurantCommands;
using Cherry.Application.FoodApplication.Queries.GetSingle;
using Cherry.Application.FoodApplication.Queries.RestaurantQueries.GetAll;
using Cherry.Application.FoodApplication.Views;
using Cherry.Domain.Common;
using Cherry.Domain.FoodAggregate;
using Cherry.Web.Helpers;
using Cherry.Web.Models.Food;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cherry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> AddNewRestaurantAsync([FromBody] AddNewRestaurantModel model)
        {
            int result = await _mediator.Send(new RestaurantCreateCommand
            {
                Address = new Address(model.City, model.Street, model.Alley, model.No),
                Name = model.Name
            });

            return result.AsActionResult();
        }

        [HttpPost]
        [Route("{restaurantId:int}/food")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> AddFoodToMenuAsync(int restaurantId, [FromBody] AddFoodToMenuModel model)
        {
            int result = await _mediator.Send(new AddFoodToMenuCommand
            {
                Name = model.Name,
                Price = new Price(model.Price),
                RestaurantId = restaurantId
            });

            return result.AsActionResult();
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedData<RestaurantShortView>), 200)]
        public async Task<IActionResult> GetAllRestaurantsQueryAsync(string phrase, int pageNumber = 1,
            int pageSize = 10)
        {
            PagedData<RestaurantShortView> result = await _mediator.Send(new GetAllRestaurantsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Phrase = phrase
            });

            return result.AsActionResult();
        }

        [HttpGet]
        [Route("{restaurantId:int}")]
        [ProducesResponseType(typeof(RestaurantView), 200)]
        public async Task<IActionResult> GetRestaurantQueryAsync(int restaurantId)
        {
            RestaurantView result = await _mediator.Send(new GetRestaurantQuery
            {
                RestaurantId = restaurantId
            });

            return result.AsActionResult();
        }
    }
}