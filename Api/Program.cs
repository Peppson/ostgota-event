using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<IDataService, DataService>();
        builder.Services.AddScoped<DatabaseInitializer>();
        builder.Services.AddSqlite<Database>("Data Source=../Core/Data/EventDB.db");

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        // Enforce HTTPS only
        if (app.Environment.IsProduction())
        {
            app.UseHsts();
        }

        // Ensure SQLite DB is created and seeded on firstboot, bool for debugging
        bool resetDatabaseToDefault = true;
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            if (resetDatabaseToDefault)
                await db.ResetDatabase();
            else
                await db.InitDatabase();
        }

        app.Run();
    }
}
