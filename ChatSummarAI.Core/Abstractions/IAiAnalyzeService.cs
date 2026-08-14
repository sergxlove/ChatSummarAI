namespace ChatSummarAI.Core.Abstractions
{
    public interface IAiAnalyzeService
    {
        List<string> GetAvailableModels();
        string GetCurrentModel();
        Task<string> SendMessageAsync(string model, string message, CancellationToken token);
    }
}