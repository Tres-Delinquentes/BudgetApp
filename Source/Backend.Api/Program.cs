namespace Backend.Api;

public class Program
{
    public static void Main(string[] args)
    {

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddHealthChecks();
        builder.Services.AddTransient<Helpers.PDFGenerator>();
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("MyCorsPolicy", builder =>
            {
                builder.WithOrigins("http://localhost:5173/")
                .AllowAnyHeader()
                .AllowAnyMethod();
            });

            // Todo, fix new policy  ? 
            options.AddPolicy(
                name: "AllowAllOrigins",
                policy =>
                {
                    policy.AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin();
                });
        });
        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseCors("AllowAllOrigins");

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapHealthChecks("api/healthcheck");

        app.MapControllers();

        app.Run();

    }
}