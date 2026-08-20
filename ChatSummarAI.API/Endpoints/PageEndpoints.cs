namespace ChatSummarAI.API.Endpoints
{
    public static class PageEndpoints
    {
        public static IEndpointRouteBuilder MapPageEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/", async (HttpContext context) =>
            {
                
                try
                {
                    string filePath = Path.Combine(Directory.GetCurrentDirectory(), "telegramSettings.txt");
                    context.Response.ContentType = "text/html; charset=utf-8";
                    if (File.Exists(filePath))
                    {

                    }
                    else
                    {

                    }
                    await context.Response.SendFileAsync("wwwroot/Pages/LoginPage.html");
                }
                catch { }
            });
            return app;
        }
    }
}
