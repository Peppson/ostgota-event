namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<DataService>(); // Jw: Todo add interface
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

        // Ensure SQLite DB is created and seeded on firstboot, bool for debugging
        bool resetDatabaseToDefault = false;
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            if (resetDatabaseToDefault)
                db.ResetDatabase();
            else
                db.InitDatabase();
        }

        app.Run();
    }
}
