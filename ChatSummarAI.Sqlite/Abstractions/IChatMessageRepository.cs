using ChatSummarAI.Core.Models;

namespace ChatSummarAI.Sqlite.Abstractions
{
    public interface IChatMessageRepository
    {
        Task<Guid> AddAsync(ChatMessage message);
        Task<int> AddRangeAsync(IEnumerable<ChatMessage> messages);
        Task DeleteAllAsync();
        Task<IEnumerable<ChatMessage>> GetAllAsync();
        Task<IEnumerable<ChatMessage>> GetByUserIdAsync(string userId);
    }
}