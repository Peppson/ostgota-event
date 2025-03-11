namespace Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();
        builder.Services.AddOpenApi();

        // Jw todo add interfaces
        builder.Services.AddScoped<DataService>();
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


        // Ensure SQLite is seeded on firstboot todo move too Core/Data?
        var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
        using (var scope = scopeFactory.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<Database>();
            if (db.Database.EnsureCreated())
            {
                //SeedData.Initialize(db);
            }
        }

        app.Run();
    }
}
