using ChatSummarAI.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatSummarAI.Sqlite.Configurations
{
    public class ChatMessageConfiguration : IEntityTypeConfiguration<ChatMessage>
    {
        public void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            builder.ToTable("ChatMessage");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId)
                .IsRequired();
            builder.Property(x => x.Username)
                .IsRequired();
            builder.Property(x => x.Text)
                .IsRequired();
            builder.Property(x => x.Date)
                .IsRequired();
        }
    }
}
