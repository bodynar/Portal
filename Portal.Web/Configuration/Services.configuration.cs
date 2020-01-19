namespace Portal.Web.Configuration
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using Portal.DataAccess;
    using Portal.Web.Models;

    using SimpleInjector;

    public static class ServicesConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration, Container container)
        {
            services
                .AddControllers();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration => {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddSimpleInjector(container, options => {
                options
                    .AddAspNetCore()
                    .AddControllerActivation();
            });

            services.AddSingleton<Container>((_) => container);

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<DataBaseContext>(options =>
                options.UseSqlServer(connectionString,
                    x => x
                        .MigrationsAssembly("Portal.DataAccess.Migrations"))
                .EnableDetailedErrors()
            );

            #region Mail

            services.AddOptions();
            services.Configure<SmtpSettings>(configuration.GetSection("SmtpSettings"));

            #endregion
        }
    }
}