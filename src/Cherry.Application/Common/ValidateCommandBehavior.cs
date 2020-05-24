using Cherry.Application.Common.Exceptions;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.Common
{
    public class ValidateCommandBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly IValidator<TRequest> _validator;

        public ValidateCommandBehavior(IValidator<TRequest> validator = null)
        {
            _validator = validator;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (_validator == null)
                return next();

            ValidationResult validationResult = _validator.Validate(request);

            if (validationResult.IsValid)
                return next();

            StringBuilder errorBuilder = new StringBuilder();

            errorBuilder.AppendLine("Invalid command, reason: ");

            foreach (var error in validationResult.Errors)
            {
                errorBuilder.AppendLine(error.ErrorMessage);
            }

            throw new ModelValidationException(errorBuilder.ToString());
        }
    }
}