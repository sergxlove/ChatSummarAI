using ChatSummarAI.API.Endpoints;
using ChatSummarAI.Core.Abstractions;
using ChatSummarAI.Core.Services;
using ChatSummarAI.Sqlite;
using ChatSummarAI.Sqlite.Abstractions;
using ChatSummarAI.Sqlite.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ChatSummarAI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<ChatSummarDbContext>(options =>
                options.UseSqlite("Data Source=D:\\projects\\projects\\ChatSummarAI\\ChatSummarAI.API\\data.db"));
            builder.Services.AddSingleton<IAiAnalyzeService, AiAnalyzeService>();
            builder.Services.AddScoped<IJwtProviderService, JwtProviderService>();
            builder.Services.AddScoped<IChatMessageRepository, ChatMessageRepository>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    IConfigurationSection? jwtSettings = builder.Configuration
                        .GetSection("JwtSettings");
                    options.TokenValidationParameters = new()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtSettings["Issuer"],
                        ValidateAudience = true,
                        ValidAudience = jwtSettings["Audience"],
                        ValidateLifetime = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                            .GetBytes(jwtSettings["SecretKey"]!)),
                        ValidateIssuerSigningKey = true
                    };
                    options.Events = new JwtBearerEvents()
                    {
                        OnMessageReceived = context =>
                        {
                            context.Token = context.Request.Cookies["jwt"];
                            return Task.CompletedTask;
                        }
                    };
                });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("OnlyForAdmin", policy =>
                {
                    policy.RequireRole("admin");
                });
                options.AddPolicy("OnlyForActor", policy =>
                {
                    policy.RequireClaim("actor");
                });
                options.AddPolicy("OnlyForAuthUser", policy =>
                {
                    policy.RequireRole("user", "admin", "actor");
                });
            });

            var app = builder.Build();
            app.UseAuthentication();
            app.UseAuthorization();
            app.MapPageEndpoints();
            app.MapSummarEndpoints();

            app.Run();
        }
    }
}
