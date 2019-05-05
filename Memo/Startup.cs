using System;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using FluentValidation.AspNetCore;
using Memo.Api.Mapper;
using Memo.Api.Middleware;
using Memo.Api.Module;
using Memo.Core;
using Memo.Domain.WordAggregate;
using Memo.Infrastructure.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Swagger;

namespace Memo.Api
{
    public class Startup
    {
        public IConfigurationRoot Configuration { get; private set; }

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            this.Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString =
                @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Memo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            services.AddEntityFrameworkSqlServer().AddDbContext<Context>(o =>
            {
                o.UseSqlServer(connectionString, builder =>
                {
                    builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                    builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
                });
            });

            services.AddAutoMapper();
            AutoMapper.Mapper.Initialize(cfg => { cfg.AddProfile<AutoMapperProfile>(); });


            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
            {
                builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            }));

            services.AddMvc().AddControllersAsServices()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Formatting = Formatting.Indented;
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }).AddFluentValidation(x => x.RegisterValidatorsFromAssemblyContaining<WordValidator>())
                ;

            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new Info {Title = "My API", Version = "v1"}); });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseCors("MyPolicy");
            app.UseMvc();
       

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


        }

        public void ConfigureContainer(ContainerBuilder builder)
        {

            builder.RegisterModule(new AutoFacModule());
        }
    }

    public class BloggingContextFactory : IDesignTimeDbContextFactory<Context>
    {
        private const string ConnectionString =
            @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Memo;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public Context CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Context>();

            optionsBuilder.UseSqlServer(ConnectionString, builder =>
            {
                builder.MigrationsAssembly(typeof(Startup).GetTypeInfo().Assembly.GetName().Name);
                builder.EnableRetryOnFailure(5, TimeSpan.FromSeconds(10), null);
            });
            return new Context(optionsBuilder.Options);
        }
    }

    
}