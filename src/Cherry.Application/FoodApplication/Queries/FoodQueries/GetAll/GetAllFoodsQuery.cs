using Cherry.Application.Common.Structures;
using Cherry.Application.FoodApplication.Views;
using MediatR;

namespace Cherry.Application.FoodApplication.Queries.FoodQueries.GetAll
{
    public class GetAllFoodsQuery : PagedQuery, IRequest<PagedData<FoodShortView>>
    {
        public string Phrase { get; set; }
    }
}