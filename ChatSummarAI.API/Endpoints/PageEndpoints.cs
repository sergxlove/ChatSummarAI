using ChatSummarAI.Core.Abstractions;
using ChatSummarAI.Core.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatSummarAI.API.Endpoints
{
    public static class PageEndpoints
    {
        public static IEndpointRouteBuilder MapPageEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (HttpContext context, 
                [FromServices] IJwtProviderService jwtService,
                [FromServices] IConfiguration configuration) =>
            {
                try
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "telegramSettings.txt");
                    string fileSendPath;
                    string role;
                    context.Response.ContentType = "text/html; charset=utf-8";
                    if (File.Exists(filePath))
                    {
                        fileSendPath = "wwwroot/Pages/aiSetting.html";
                        role = "afterAi";
                    }
                    else
                    {
                        fileSendPath = "wwwroot/Pages/index.html";
                        role = "main";
                    }
                    IConfigurationSection? jwtSettings = configuration.GetSection("JwtSettings");
                    List<Claim> claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.Role, role)
                    };
                    var jwttoken = jwtService.GenerateToken(new JwtRequest()
                    {
                        Audience = jwtSettings["Audience"]!,
                        Issuer = jwtSettings["Issuer"]!,
                        Claims = claims,
                        SecretKey = jwtSettings["SecretKey"]!,
                        Expires = DateTime.UtcNow.AddMinutes(Convert.ToDouble(jwtSettings["Lifetime"]!))
                    });
                    context.Response.Cookies.Append("jwt", jwttoken!);
                    await context.Response.SendFileAsync(fileSendPath);
                }
                catch (Exception ex) 
                {
                    context.Response.StatusCode = 500;
                    await context.Response.WriteAsync($"Ошибка: {ex.Message}");
                }
            });

            return app;
        }
    }
}
