using Cherry.Application.Common.Structures;
using Cherry.Application.FoodApplication.Queries.FoodQueries.GetAll;
using Cherry.Application.FoodApplication.Views;
using Cherry.Web.Helpers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Cherry.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FoodController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(typeof(PagedData<FoodShortView>), 200)]
        public async Task<IActionResult> GetAllFoodsAsync(string phrase, int pageNumber = 1, int pageSize = 10)
        {
            PagedData<FoodShortView> result = await _mediator.Send(new GetAllFoodsQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                Phrase = phrase
            });

            return result.AsActionResult();
        }
    }
}