using ChatSummarAI.Core.Models;
using ChatSummarAI.Sqlite.Configurations;
using ChatSummarAI.Sqlite.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatSummarAI.Sqlite
{
    public class ChatSummarDbContext : DbContext
    {
        public ChatSummarDbContext(DbContextOptions<ChatSummarDbContext> options) 
            : base(options)
        { }

        public DbSet<ChatMessage> ChatMessageTable { get; set; }
        public DbSet<AiSettingEntity> AiSettingTable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChatMessageConfiguration());
            modelBuilder.ApplyConfiguration(new AiSettingConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
