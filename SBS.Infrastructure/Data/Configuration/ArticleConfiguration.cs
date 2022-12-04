using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SBS.Infrastructure.Data.Models;

namespace SBS.Infrastructure.Data.Configuration
{
    /// <summary>
    /// Data for seeding Articles
    /// </summary>
    public class ArticleConfiguration : IEntityTypeConfiguration<Article>
    {
        /// <summary>
        /// Configure (seed) Articles
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.HasData(CreateArticles());
        }

        private List<Article> CreateArticles()
        {
            List<Article> articles = new List<Article>();

            var article = new Article()
            {
                Id = new Guid("f8227782-0e7f-4eac-bc87-d0b9ab145250"),
                Name = "Keyboard",
                Model = "KC-200",
                DeliveryNumber = "182681",
                Title = "USB keyboard",
                Description = "Black keyboard",
                UnitId = new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6"),
                IsActive = true,
            };
            articles.Add(article);

            article = new Article()
            {
                Id = new Guid("6f5d0558-9c9c-4082-84f2-be8bbce62532"),
                Name = "Mouse",
                Model = "DSY-MO140",
                DeliveryNumber = "DSY-MO140",
                Title = "USB mouse",
                Description = "Mouse Disney Hanna Montana",
                UnitId = new Guid("a96f16ba-b522-4dd9-9ca6-7425fd7044f6"),
                IsActive = true,
            };
            articles.Add(article);

            article = new Article()
            {
                Id = new Guid("2d1c64fc-6628-4ddb-bcd5-164134f35934"),
                Name = "Cable",
                Model = "RJ-45",
                DeliveryNumber = "RJ-45 - 21.99.1331",
                Title = "Cable RJ-45",
                Description = "Cable RJ-45 to RJ-45",
                UnitId = new Guid("20b0aaca-9283-4486-be89-ed67e515c2e2"),
                IsActive = true,
            };
            articles.Add(article);

            return articles;
        }
    }
}
