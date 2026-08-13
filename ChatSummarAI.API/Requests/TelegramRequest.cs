namespace ChatSummarAI.API.Requests
{
    public class TelegramRequest
    {
        public string BotToken { get; set; } = string.Empty;
        public string ChatId { get; set; } = string.Empty;
        public string AdminId { get; set; } = string.Empty;
    }
}
