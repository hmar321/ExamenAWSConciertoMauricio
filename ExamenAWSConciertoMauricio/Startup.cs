using ExamenAWSConciertoMauricio.Data;
using ExamenAWSConciertoMauricio.Helpers;
using ExamenAWSConciertoMauricio.Models;
using ExamenAWSConciertoMauricio.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;

namespace ExamenAWSConciertoMauricio;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container
    public async void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddCors(options =>
        {
            options.AddPolicy("AllowOrigin", x => x.AllowAnyOrigin());
        });
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api Segundo Examen de AWS",
                Version = "v1"
            });
        });

        string jsonSecrets = HelperSecretManager.GetSecretAsync().GetAwaiter().GetResult();
        KeysModel keysModel = JsonConvert.DeserializeObject<KeysModel>(jsonSecrets);
        services.AddSingleton<KeysModel>(keysModel);
        string connectionString = keysModel.MysqlAWS;
        services.AddDbContext<ConciertosContext>(options =>
        {
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        });
        services.AddTransient<RepositoryConciertos>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseSwagger();
        app.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint(
                url: "swagger/v1/swagger.json", "ExamenAWSConciertoMauricio");
            options.RoutePrefix = "";
        });
        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseCors(options => options.AllowAnyOrigin());

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
            endpoints.MapGet("/", async context =>
            {
                await context.Response.WriteAsync("Welcome to running ASP.NET Core on AWS Lambda");
            });
        });
    }
}