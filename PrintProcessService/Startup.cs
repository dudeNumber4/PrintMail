using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PrintMailDomain;
using PrintMailStore;
using System;
using System.Linq;

namespace PrintProcessService
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddMediatR(typeof(PrintFileProcessorService), typeof(PrintFileEntity));  // type from each assembly using mediatr
            services.AddSingleton<IReadModel>(new PrintMailFileReadModel());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints((Action<Microsoft.AspNetCore.Routing.IEndpointRouteBuilder>)(endpoints =>
            {
                GrpcEndpointRouteBuilderExtensions.MapGrpcService<PrintFileProcessorService>(endpoints);

                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                });
            }));
        }
    }
}
