namespace ChatSummarAI.Sqlite.Models
{
    public class AiSettingEntity
    {
        public Guid Id { get; set; }
        public string Provider { get; set; } = string.Empty;
        public string ApiKey { get; set; } = string.Empty;
        public string ModelId { get; set; } = string.Empty;
        public string Endpoint { get; set; } = string.Empty;
    }
}
