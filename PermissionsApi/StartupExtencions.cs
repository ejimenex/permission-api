using PermissionApi.Application;
using PermissionApi.Persistence;

namespace PermissionsApi
{
    public static class StartupExtencions
    {
        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Clean Arquitecture"
                });
            });

        }
        public static WebApplication ConfigureService(this WebApplicationBuilder builder)
        {
            AddSwagger(builder.Services);
            builder.Services.AddMvc(options =>
            {
                options.Filters.Add(typeof(GlobalExceptionFilters));
            });
            builder.Services.AddApplicationServices();
            builder.Services.AddPersistenceServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddCors(o => o.AddPolicy("CorsPolicy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
            return builder.Build();

        }
        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.MapControllers();
            return app;
        }
    }
}

