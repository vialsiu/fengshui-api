using FengShui.Api.Data;
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

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}