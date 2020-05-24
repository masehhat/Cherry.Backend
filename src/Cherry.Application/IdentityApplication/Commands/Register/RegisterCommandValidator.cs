using Cherry.Application.Common.Exceptions;
using Cherry.Application.IdentityApplication.Exceptions;
using Cherry.Domain.IdentityAggregate;
using Cherry.Infrastructure.Persistance;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Cherry.Application.IdentityApplication.Commands.Register
{
    public class RegisterCommandValidator : IPipelineBehavior<RegisterCommand, string>
    {
        private readonly CherryDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterCommandValidator(CherryDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<string> Handle(RegisterCommand request, CancellationToken cancellationToken, RequestHandlerDelegate<string> next)
        {
            if (await _context.Users.AnyAsync(x => x.NormalizedUserName == request.UserName))
                throw new UserNameIsRepetitiveException();

            List<string> passwordErrors = new List<string>();

            var validators = _userManager.PasswordValidators;

            foreach (var validator in validators)
            {
                var result = await validator.ValidateAsync(_userManager, null, request.Password);

                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        passwordErrors.Add(error.Description);
                    }
                }
            }

            string errorMessages = null;

            if (passwordErrors.Any())
            {
                errorMessages = string.Join(Environment.NewLine, passwordErrors
                                            .Select(e => $"{e}{Environment.NewLine}")
                                            .ToList());

                throw new ModelValidationException(errorMessages);
            }

            string response = await next();

            return response;
        }
    }
}