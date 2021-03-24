using GiraffeByMiddleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using static Giraffe.Middleware.ApplicationBuilderExtensions;
using static Giraffe.Middleware.ServiceCollectionExtensions;

namespace WebApplication
{
    public interface IHelloWorldGenerator { string Say(); }
    
    public class SadHelloWorldGenerator: IHelloWorldGenerator
    {
        public string Say() => "Hello World! Test from C# :(";
    }
    
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGiraffe();
            services.AddControllers();
            services.AddTransient<IHelloWorldGenerator, SadHelloWorldGenerator>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseGiraffe(HttpHandler.webApp(Composition.build("Test")));
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}