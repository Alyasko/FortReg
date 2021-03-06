using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FortuneRegistry.Core.Transactions;
using FortuneRegistry.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace FortuneRegistry.Api
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

            var configuration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Foo, FooDto>();
                //cfg.CreateMap<Bar, BarDto>();
            });

            configuration.AssertConfigurationIsValid();
            var mapper = configuration.CreateMapper();

            services.AddSingleton<IMapper>(mapper);

            services.AddScoped<TransactionsService>();
            services.AddScoped<TransactionsRepository>();

            services.AddScoped<FamilyMembersService>();
            services.AddScoped<FamilyMembersRepository>();

            services.AddScoped<CategoriesService>();
            services.AddScoped<CategoriesRepository>();

            services.AddScoped<SummaryService>();
            services.AddScoped<PlansRepository>();
            services.AddScoped<DatabaseService>();

            services.AddScoped<CurrenciesRepository>();
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
