using ChatSummarAI.API.Endpoints;
using ChatSummarAI.Core.Abstractions;
using ChatSummarAI.Core.Services;

namespace ChatSummarAI.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSingleton<IAiAnalyzeService, AiAnalyzeService>();
            var app = builder.Build();

            app.MapPageEndpoints();
            app.MapSummarEndpoints();

            app.Run();
        }
    }
}
