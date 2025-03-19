namespace Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // log level for EF Core >= Warning
        builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IEventService, EventService>();
        builder.Services.AddScoped<ITicketService, TicketService>();
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddScoped<IDatabase, Database>();
        builder.Services.AddSingleton<Validator>();
        builder.Services.AddScoped<DatabaseInitializer>();
        builder.Services.AddSqlite<Database>("Data Source=../Core/Data/EventDB.db");
        builder.Services.AddSwaggerGen();

        // Add cors for Blazor wasm
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowBlazor", policy =>
            {
                policy.WithOrigins(builder.Configuration["blazorUrl"]!)
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
            });
        }

        app.UseCors("AllowBlazor");
        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();

        // Enforce HTTPS only
        if (app.Environment.IsProduction())
            app.UseHsts();

        // Ensure SQLite DB is created and seeded on firstboot
        bool resetDatabaseToDefault = true; // config file?
        using (var scope = app.Services.CreateScope())
        {
            var db = scope.ServiceProvider.GetRequiredService<DatabaseInitializer>();
            if (resetDatabaseToDefault)
                await db.ResetDatabase();
            else
                await db.InitDatabase();
        }

        var apiUrl = builder.Configuration["apiUrl"];
        Console.WriteLine($"\n{apiUrl}/swagger\n");

        app.Run(apiUrl);
    }
}
