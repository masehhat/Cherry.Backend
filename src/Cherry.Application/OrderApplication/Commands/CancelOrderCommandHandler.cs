using Cherry.Application.Common.Exceptions;
using Cherry.Application.OrderApplication.Exceptions;
using Cherry.Application.OrderApplication.Notifications.CanceledNotification.Ping;
using Cherry.Domain.OrderAggregate;
using Cherry.Domain.OrderAggregate.Specs;
using Cherry.Infrastructure.Persistance;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.OrderApplication.Commands
{
    public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand>
    {
        private readonly CherryDbContext _context;
        private readonly IMediator _mediator;

        public CancelOrderCommandHandler(CherryDbContext context,IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
        {
            Order order = await _context.Orders
                .FirstOrDefaultAsync(x=>x.Id == request.OrderId && x.UserId == request.UserId);

            if (order == null)
                throw new ItemNotFoundException();

            if (!order.IsCancelable)
                throw new OrderCouldNotCancelException();

            order.Cancel();

            await _context.SaveChangesAsync();

            await _mediator.Publish(new OrderCanceledNotification
            {
                OrderId = order.Id
            });

            return await Task.FromResult(Unit.Value);
        }
    }
}
