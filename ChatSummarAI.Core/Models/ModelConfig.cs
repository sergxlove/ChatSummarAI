namespace ChatSummarAI.Core.Models
{
    public class ModelConfig
    {
        public string ModelId { get; set; } = string.Empty;
        public Uri? Endpoint { get; set; }
    }
}
