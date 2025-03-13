namespace Api;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddOpenApi();
        builder.Services.AddScoped<IUserService, UserService>();
        builder.Services.AddScoped<IEventService, EventService>();
        builder.Services.AddScoped<ITicketService, TicketService>();
        builder.Services.AddScoped<DatabaseInitializer>();
        builder.Services.AddSqlite<Database>("Data Source=../Core/Data/EventDB.db"); // jw: todo singelton?
        builder.Services.AddScoped<IAuthService, AuthService>();
        builder.Services.AddSwaggerGen();

        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowBlazor", policy =>
            {
                policy.WithOrigins("https://localhost:7059") // Blazor app URL
                      .AllowAnyMethod()
                      .AllowAnyHeader();
            });
        });

        

        var app = builder.Build();
        app.UseCors("AllowBlazor");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DefaultModelsExpandDepth(-1);
            });
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
        bool resetDatabaseToDefault = false;
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
