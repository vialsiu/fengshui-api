namespace FengShui.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        //---controllers instead of minimal apis, one controller per resource
        builder.Services.AddControllers();
        //-----makes the openapi document so the endpoints can be tried out
        builder.Services.AddOpenApi();

        var app = builder.Build();

        //----only show the api docs while developing
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}