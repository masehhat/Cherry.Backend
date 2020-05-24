using Cherry.Application.OrderApplication.Exceptions;
using Cherry.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.OrderApplication.Commands
{
    public class AddOrderCommandValidator : IPipelineBehavior<AddOrderCommand, int>
    {
        private readonly CherryDbContext _context;

        public AddOrderCommandValidator(CherryDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddOrderCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<int> next)
        {
            int[] foodIds = request.FoodsAndCounts.Keys.ToArray();

            request.FoodsAndPrices = await _context.Foods
                .Where(x => foodIds.Contains(x.Id))
                .ToDictionaryAsync(x => x.Id, x => x.Price);

            if (request.FoodsAndPrices.Count != foodIds.Length)
                throw new SelectedFoodIsWrongException();

            int respose = await next();

            return respose;
        }
    }
}
