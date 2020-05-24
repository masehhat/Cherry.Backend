using AutoMapper;
using Cherry.Application.Common;
using Cherry.Application.Common.Middlewares;
using Cherry.Application.FoodApplication.Commands.RestaurantCommands;
using Cherry.Application.FoodApplication.Mappings;
using Cherry.Application.FoodApplication.Validators;
using Cherry.Application.IdentityApplication.Commands.Register;
using Cherry.Application.OrderApplication.Commands;
using Cherry.Domain.IdentityAggregate.Services.Login;
using Cherry.Infrastructure.Persistance;
using Cherry.Infrastructure.Services;
using Cherry.Web.InstallerServices;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cherry.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.InstallIdentityConfiguration(Configuration);

            services.AddDbContext<CherryDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("CherryDbConnection"));
            });

            services.AddScoped<ILoginService, LoginService>();
            services.AddSingleton<ISendSmsService, SendSmsService>();

            services.AddMediatR(typeof(RestaurantCreateCommand).Assembly);
            services.AddValidatorsFromAssembly(typeof(RestaurantValidator).Assembly);
            services.AddAutoMapper(typeof(RestaurantMappingProfile).Assembly);

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<AddFoodToMenuCommand, int>), typeof(AddFoodToMenuCommandValidator));
            services.AddTransient(typeof(IPipelineBehavior<RegisterCommand, string>), typeof(RegisterCommandValidator));
            services.AddTransient(typeof(IPipelineBehavior<AddOrderCommand, int>), typeof(AddOrderCommandValidator));

            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseMiddleware<ExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}