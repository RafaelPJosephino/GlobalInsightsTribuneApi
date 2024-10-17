using GlobalInsightsTribune.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GlobalInsightsTribune.Infra.Data.EntitiesConfiguration
{
    internal class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.UserId).IsRequired();
            builder.Property(x => x.NewsId).IsRequired();
            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.CommentDate).IsRequired().HasColumnType("datetime"); 


        }

    }
}
