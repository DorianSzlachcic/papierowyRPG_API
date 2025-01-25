using papierowyRPG_API.Database;
using papierowyRPG_API.Services;

namespace papierowyRPG_API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<UserContext>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IGameService, GameService>();

            // Add services to the container.
            builder.Services.AddControllers();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string AllowAllOrigins = "AllowAllOrigins";

            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: AllowAllOrigins,
                    policy =>
                    {
                        policy.WithOrigins("*");
                    });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(AllowAllOrigins);

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}