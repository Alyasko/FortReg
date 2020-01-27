using AutoMapper;
using FortuneRegistry.Core.Transactions;
using FortuneRegistry.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;

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

            SetupContainer(services);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FortReg", Version = "v1" });
                c.MapType<ObjectId>(() => new OpenApiSchema { Type = "string", Description = "12 bit hexadecimal ObjectId value", Format = "objectId", Example = new OpenApiString("000000000000000000000000") });
                c.MapType<ObjectId?>(() => new OpenApiSchema { Type = "string", Description = "12 bit hexadecimal ObjectId value", Format = "objectId", Example = new OpenApiString("000000000000000000000000") });
            });
        }

        private void SetupContainer(IServiceCollection services)
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                //cfg.CreateMap<Foo, FooDto>();
                //cfg.CreateMap<Bar, BarDto>();
            });

            configuration.AssertConfigurationIsValid();

            var mapper = configuration.CreateMapper();
            services.AddSingleton<IMapper>(mapper);

            services.AddSingleton<TransactionsService>();
            services.AddSingleton<TransactionsRepository>();

            services.AddSingleton<FamilyMembersService>();
            services.AddSingleton<FamilyMembersRepository>();

            services.AddSingleton<CategoriesService>();
            services.AddSingleton<CategoriesRepository>();

            services.AddSingleton<SummaryService>();
            services.AddSingleton<PlansRepository>();
            services.AddSingleton<DatabaseService>();

            services.AddSingleton<CurrenciesRepository>();
            services.AddSingleton<IMapper>(mapper);

            services.AddSingleton<TransactionsService>();
            services.AddSingleton<TransactionsRepository>();

            services.AddSingleton<FamilyMembersService>();
            services.AddSingleton<FamilyMembersRepository>();

            services.AddSingleton<CategoriesService>();
            services.AddSingleton<CategoriesRepository>();

            services.AddSingleton<SummaryService>();
            services.AddSingleton<PlansRepository>();
            services.AddSingleton<DatabaseService>();

            services.AddSingleton<CurrenciesRepository>();
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

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}
