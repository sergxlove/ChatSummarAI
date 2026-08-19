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
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.SendFileAsync("wwwroot/Pages/LoginPage.html");
                }
                catch { }
            });
            return app;
        }
    }
}
