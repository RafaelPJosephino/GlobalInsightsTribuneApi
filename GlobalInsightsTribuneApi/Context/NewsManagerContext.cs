using GlobalInsightsTribuneApi.Entitys;
using Microsoft.EntityFrameworkCore;

namespace GlobalInsightsTribuneApi.Context
{
    public partial class NewsManagerContext : DbContext
    {
        public NewsManagerContext() 
        {
        }

        public NewsManagerContext(DbContextOptions<NewsManagerContext> options): base(options)
        {
        }
        public virtual DbSet<Comments> Comments { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("public");
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<News>(Entity =>
            {
                Entity.ToTable("news_table"); 
                Entity.Property(e => e.Id).UseIdentityAlwaysColumn(); ;
                Entity.Property(e => e.Title).IsUnicode(false);
                Entity.Property(e => e.Description).IsUnicode(false);
                Entity.Property(e => e.Contents).IsUnicode(false);
                Entity.Property(e => e.Author).IsUnicode(false);
                Entity.Property(e => e.Source).IsUnicode(false);
                Entity.Property(e => e.date_publication).IsUnicode(false);
                Entity.Property(e => e.Category).IsUnicode(false);

            });
            

            modelBuilder.Entity<Users>(Entity =>
            {
                Entity.ToTable("users_table");
                Entity.Property(e => e.Id).UseIdentityAlwaysColumn(); ;
                Entity.Property(Entity => Entity.Name).IsUnicode(false);
                Entity.Property(Entity => Entity.Email).IsUnicode(false);
                Entity.Property(Entity => Entity.Password).IsUnicode(false);
            });

            modelBuilder.Entity<Comments>(Entity =>
            {
                Entity.ToTable("comments_table");
                Entity.Property(e => e.Id).UseIdentityAlwaysColumn(); ;
                Entity.Property(Entity => Entity.Text).IsUnicode(false);
                Entity.Property(Entity => Entity.date_publication).IsUnicode(false);

                Entity.HasOne(d => d.Fk_Users)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.Users_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comments_table_users_id_fkey");

                Entity.HasOne(d => d.Fk_News)
                .WithMany(p => p.Comments)
                .HasForeignKey(d => d.News_id)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("comments_table_news_id_fkey");

            });

        }

    }
}
