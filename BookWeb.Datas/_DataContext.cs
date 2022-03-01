namespace BookWeb.Datas
{
    using Microsoft.EntityFrameworkCore;
    using BookWeb.Datas.Infrastructure;

    public class DataContext : DbContext
    {
        public DataContext(string connectionString) : base(new DbContextOptionsBuilder().UseMySQL(connectionString).Options)
        {
        }

        public DbSet<Models.BookModel> Authors { get; set; }
        public DbSet<Models.BookPublishModel> Categories { get; set; }
        public DbSet<Models.PublishModel> Comments { get; set; }
        public DbSet<Models.MediaModel> Contents { get; set; }
        public DbSet<Models.MemberModel> ContentCategories { get; set; }
        public DbSet<Models.WriterModel> ContentTags { get; set; }
       

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Models.BookModel>(entity => entity.ToTable("y_book"));
            builder.Entity<Models.PublishModel>(entity => entity.ToTable("y_publish"));
            builder.Entity<Models.BookPublishModel>(entity => entity.ToTable("y_publish_book"));
            builder.Entity<Models.WriterModel>(entity => entity.ToTable("y_writer"));
            builder.Entity<Models.MediaModel>(entity => entity.ToTable("y_media"));
            builder.Entity<Models.MemberModel>(entity => entity.ToTable("y_members"));
          

            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    if (property.ClrType == typeof(bool))
                    {
                        property.SetValueConverter(new BoolToIntConverter());
                    }
                }
            }
        }
    }
}
