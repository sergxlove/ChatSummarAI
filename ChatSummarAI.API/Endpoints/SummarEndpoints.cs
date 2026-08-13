using ChatSummarAI.API.Requests;
using System.Text.Json;

namespace ChatSummarAI.API.Endpoints
{
    public static class SummarEndpoints
    {
        public static IEndpointRouteBuilder MapSummarEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("/api/setting/tg", (TelegramRequest request) =>
            {
                try
                {
                    string filePath = "D:\\documents\\telegramSettings.json";
                    if (File.Exists(filePath))
                        return Results.Ok();
                    var json = JsonSerializer.Serialize(request, 
                        new JsonSerializerOptions { WriteIndented = true });
                    File.WriteAllText(filePath, json);
                    return Results.Ok();
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
