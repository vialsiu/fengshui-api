using FengShui.Api.Auth;
using FengShui.Api.Data;
using FengShui.Api.Repositories;
using Microsoft.AspNetCore.Authentication;
using Scalar.AspNetCore;

namespace FengShui.Api;

/// <summary>
/// starts the fengshui api
/// </summary>
public class Program
{
    /// <summary>
    /// sets up the services and the request pipeline, then runs the api
    /// </summary>
    /// <param name="args">command line arguments</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //---controllers instead of minimal apis, one controller per resource
        builder.Services.AddControllers();
        //-----makes the openapi document so the endpoints can be tried out
        builder.Services.AddOpenApi();

        //------sqlite database, same setup as the movie api lab, falls back to a local file
        var connectionString = builder.Configuration.GetConnectionString("FengShui") ?? "Data Source=FengShui.db";
        builder.Services.AddSqlite<FengShuiContext>(connectionString);

        //---one repository per table, controllers ask for the interface and get the ef version
        //------scoped = a new one for every request, the same lifetime as the context they use
        //----ref https://learn.microsoft.com/en-us/dotnet/core/extensions/dependency-injection/service-lifetimes
        builder.Services.AddScoped<IFurnitureTypeRepository, EfFurnitureTypeRepository>();
        builder.Services.AddScoped<IRuleRepository, EfRuleRepository>();
        builder.Services.AddScoped<IRoomRepository, EfRoomRepository>();
        builder.Services.AddScoped<IClientRepository, EfClientRepository>();
        builder.Services.AddScoped<IRequestRepository, EfRequestRepository>();
        builder.Services.AddScoped<ILayoutRepository, EfLayoutRepository>();
        builder.Services.AddScoped<IPlayerRepository, EfPlayerRepository>();

        //--------api key login, the handler reads the X-Api-Key header on every request
        builder.Services.AddAuthentication(ApiKeyDefaults.SchemeName)
            .AddScheme<AuthenticationSchemeOptions, ApiKeyAuthenticationHandler>(ApiKeyDefaults.SchemeName, null);
        builder.Services.AddAuthorization();

        var app = builder.Build();

        //----only show the api docs while developing
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
            //------scalar page at /scalar/v1, set up the same way as the comments api lab
            app.MapScalarApiReference(options =>
            {
                options.Title = "fengshui API";
                options.Theme = ScalarTheme.BluePlanet;
                options.Layout = ScalarLayout.Modern;
                options.HideClientButton = true;
            });
        }

        app.UseHttpsRedirection();

        //---who is it first, then what are they allowed to do
        app.UseAuthentication();
        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}