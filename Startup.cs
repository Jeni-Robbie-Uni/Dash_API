using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using API_dash.Models;
using Microsoft.EntityFrameworkCore;
using API_dash.Middleware;

namespace API_dash
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
            string potato = Configuration.GetConnectionString("dashconnectstring");
            services.AddDbContext<UserContext>(opt =>
                opt.UseSqlServer(potato));
            services.AddControllers();
            services.AddTokenAuthentication(Configuration);
        }




        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            using (IServiceScope serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                UserContext context = serviceScope.ServiceProvider.GetRequiredService<UserContext>();
                context.Database.EnsureCreated();
            }

                if (env.IsDevelopment())
                {
                    app.UseDeveloperExceptionPage();
                }

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
