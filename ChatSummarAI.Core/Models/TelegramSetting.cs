namespace ChatSummarAI.Core.Models
{
    public class TelegramSetting
    {
        public string BotToken { get; set; } = string.Empty;
        public string ChatId { get; set; } = string.Empty;
        public List<string> AllowedUser { get; set; } = [];
    }
}
