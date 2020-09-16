using LibraryWebApp.Database;
using LibraryWebApp.Dto.Filters;
using LibraryWebApp.Models.Domain;
using LibraryWebApp.Services;
using LibraryWebApp.Services.FilteringServices;
using LibraryWebApp.Services.Seeding;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace LibraryWebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            var conString = Configuration.GetConnectionString("LibraryDatabase");
            services.AddDbContext<LibraryContext>(o => o.UseSqlServer(conString));
            services.AddScoped<IReader<Book>, ContextReader<Book>>();
            services.AddScoped<IWriter<Book>, ContextReader<Book>>();
            services.AddScoped<IFilteringService<Book, BookFilter>, BooksFilteringService>();
            services.AddHostedService<ContextDataSeeder>();
            services.AddSingleton<IDataProvider, JsonDataProvider>();
            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LibraryWebApp API V1");
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
