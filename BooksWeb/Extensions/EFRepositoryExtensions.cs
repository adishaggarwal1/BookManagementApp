using TeamB.BookManagement;
using TeamB.BookManagement.Repositories.EFRepository;
using TeamB.Utils;
using Microsoft.EntityFrameworkCore;

namespace BooksWeb.Extensions
{
    public static class EFRepositoryExtensions
    {
        public static IServiceCollection AddEFBmsRepository(this IServiceCollection services)
        {
            services.AddDbContext<BMSContext>((serviceProvider, contextBuilder) =>
            {
                var config = serviceProvider.GetRequiredService<IConfiguration>();
                var connectionString = config.GetConnectionString("EFContext");
                contextBuilder.UseSqlServer(connectionString);
            });

            services.AddTransient<IRepository<Author, string>, EFAuthorRepository>();
            services.AddTransient<IRepository<Book, string>, EFBookRepository>();
            services.AddTransient<IRepository<Review, int>, EFReviewRepository>();

            return services;
        }
    }
}
