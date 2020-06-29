using DevMeet.Services;
using DevMeetData.Context;
using DevMeetData.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DevMeet
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
            services.AddDbContext<ApplicationContext>(opt =>
               opt.UseInMemoryDatabase("SeatList"));

            services.AddScoped<ISeatService, SeatService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IEventBookingService, EventBookingService>();
            services.AddScoped<IBookingItemService, BookingItemService>();

            services.AddScoped<SeatRepository>();
            services.AddScoped<EventRepository>();
            services.AddScoped<EventBookingRepository>();
            services.AddScoped<BookingItemRepository>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
