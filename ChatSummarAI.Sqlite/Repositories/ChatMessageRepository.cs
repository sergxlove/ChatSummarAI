using ChatSummarAI.Core.Models;
using ChatSummarAI.Sqlite.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace ChatSummarAI.Sqlite.Repositories
{
    public class ChatMessageRepository : IChatMessageRepository
    {
        private readonly ChatSummarDbContext _context;
        public ChatMessageRepository(ChatSummarDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> AddAsync(ChatMessage message)
        {
            await _context.ChatMessageTable.AddAsync(message);
            await _context.SaveChangesAsync();
            return message.Id;
        }

        public async Task<int> AddRangeAsync(IEnumerable<ChatMessage> messages)
        {
            await _context.ChatMessageTable.AddRangeAsync(messages);
            await _context.SaveChangesAsync();
            return messages.Count();
        }

        public async Task<IEnumerable<ChatMessage>> GetAllAsync()
        {
            return await _context.ChatMessageTable
                .OrderBy(a => a.Date)
                .ToListAsync();
        }

        public async Task<IEnumerable<ChatMessage>> GetByUserIdAsync(string userId)
        {
            return await _context.ChatMessageTable
                .Where(m => m.UserId == userId)
                .OrderBy(m => m.Date)
                .ToListAsync();
        }

        public async Task DeleteAllAsync()
        {
            _context.ChatMessageTable.RemoveRange(_context.ChatMessageTable);
            await _context.SaveChangesAsync();
        }
    }
}
