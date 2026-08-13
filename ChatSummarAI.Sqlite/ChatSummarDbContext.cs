using ChatSummarAI.Core.Models;
using ChatSummarAI.Sqlite.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ChatSummarAI.Sqlite
{
    public class ChatSummarDbContext : DbContext
    {
        public ChatSummarDbContext(DbContextOptions<ChatSummarDbContext> options) 
            : base(options)
        { }

        public DbSet<ChatMessage> ChatMessageTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
