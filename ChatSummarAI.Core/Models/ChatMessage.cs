namespace ChatSummarAI.Core.Models
{
    public class ChatMessage
    {
        public Guid Id { get; set; }
        public string UserId { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime Date { get; set; }
    }
}
