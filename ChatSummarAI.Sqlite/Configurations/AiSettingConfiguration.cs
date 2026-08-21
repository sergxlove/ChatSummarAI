using ChatSummarAI.Sqlite.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChatSummarAI.Sqlite.Configurations
{
    public class AiSettingConfiguration : IEntityTypeConfiguration<AiSettingEntity>
    {
        public void Configure(EntityTypeBuilder<AiSettingEntity> builder)
        {
            builder.ToTable("AiSettings");
            builder.HasKey(a => a.Id);
            builder.Property(a => a.ModelId)
                .IsRequired();
            builder.Property(a => a.Provider)
                .IsRequired();
            builder.Property(a => a.ApiKey)
                .IsRequired();
            builder.Property(a => a.Endpoint)
                .IsRequired();
        }
    }
}
