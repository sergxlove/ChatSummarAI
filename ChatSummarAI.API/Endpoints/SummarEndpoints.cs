using ChatSummarAI.API.Requests;
using ChatSummarAI.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace ChatSummarAI.API.Endpoints
{
    public static class SummarEndpoints
    {
        public static IEndpointRouteBuilder MapSummarEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/setting/tg", async (TelegramRequest request, 
                CancellationToken token) =>
            {
                try
                {
                    string filePath = "D:\\documents\\telegramSettings.json";
                    if (File.Exists(filePath))
                        return Results.Ok();
                    var json = JsonSerializer.Serialize(request, 
                        new JsonSerializerOptions { WriteIndented = true });
                    await File.WriteAllTextAsync(filePath, json, token);
                    return Results.Ok();
                }
                catch
                {
                    return Results.InternalServerError();
                }
            });

            app.MapPost("/api/setting/ai", async (AiRequest request,
                CancellationToken token) =>
            {

            });

            app.MapGet("/api/ai/models", (HttpContext context, 
                [FromServices] IAiAnalyzeService aiAnalyzeService) =>
            {
                try
                {
                    return Results.Ok(aiAnalyzeService.GetAvailableModels());
                }
                catch
                {
                    return Results.InternalServerError();
                }
            });

            app.MapGet("/api/ai/current", (HttpContext context,
                [FromServices] IAiAnalyzeService aiAnalyzeService) =>
            {
                try
                {
                    return Results.Ok(aiAnalyzeService.GetCurrentModel());
                }
                catch
                {
                    return Results.InternalServerError();
                }
            });

            return app;
        }
    }
}
