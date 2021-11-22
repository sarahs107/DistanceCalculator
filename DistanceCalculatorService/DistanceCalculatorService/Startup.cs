using DistanceCalculatorService.Calculators;
using DistanceCalculatorService.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace DistanceCalculatorService
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

            services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter())); ;

            //create calculation types and inject into service
            IList<IDistanceCalculator> distanceCalculators = new List<IDistanceCalculator>();            
            
            foreach (CalculationType calcType in Enum.GetValues(typeof(CalculationType)))
            {
                if (calcType == CalculationType.Haversine)
                {
                    distanceCalculators.Add(new HaversineCalculatorDistanceFactory().CreateCalculator());
                }
                else if (calcType == CalculationType.Pythagoras)
                {
                    distanceCalculators.Add(new PythagorasDistanceCalculatorFactory().CreateCalculator());
                }
            }
            services.AddScoped<IDistanceCalculatorService>( x=> new DistanceCalculatorService(distanceCalculators));
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DistanceCalculatorService", Version = "v1" });
                
            });

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DistanceCalculatorService v1"));
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
