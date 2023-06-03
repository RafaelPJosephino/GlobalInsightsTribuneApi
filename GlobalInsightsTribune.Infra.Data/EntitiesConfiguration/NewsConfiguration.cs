using GlobalInsightsTribune.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalInsightsTribune.Infra.Data.EntitiesConfiguration
{
    internal class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Author).IsRequired().HasMaxLength(200);
            builder.Property(x => x.PublicationDate).IsRequired();
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);

        }
    }
}

