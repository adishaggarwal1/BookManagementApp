using BooksWeb.Extensions;
using TeamB.BookManagement;
using TeamB.BookManagement.Repositories.EFRepository;

namespace BooksWeb
{
    public static class Startup
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            //services.AddAdoBMSRepository();
            //services.AddSingleton<IAuthorService, PersistentAuthorService>();
            //services.AddSingleton<IBookService, PersistentBookService>();

            services.AddEFBmsRepository();
            services.AddTransient<IAuthorService, PersistentAuthorService>();            
            services.AddTransient<IBookService, PersistentBookService>();
            services.AddTransient<IReviewService, PersistentReviewService>();
            services.AddTransient<IUserService, PersistentUserService>();
            services.AddSession();
            return services;
        }

        public static IApplicationBuilder ConfigureMiddlewares(this WebApplication app)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            else
            {
                app.UseOnUrl("/admin/createdb", async context =>
                {
                    var bmsContext = context.RequestServices.GetService<BMSContext>();
                    await bmsContext.Database.EnsureCreatedAsync();
                    context.Response.Redirect("/");
                });
            }

            app.UseOnUrl("/admin/seed", async context =>
            {
                var authorService = context.RequestServices.GetService<IAuthorService>();

                await authorService.AddAuthor(new Author()
                {
                    Id = "dinkar",
                    Name = "Ramdhari Singh Dinkar",
                    Biography = "The National Poet of India",
                    Photo = "https://pbs.twimg.com/profile_images/1269658848777785345/2bY35KV0_400x400.jpg",
                    //Tags = "poet, historian",
                    //BirthDate = new DateTime(1906, 1, 1),
                    //DeathDate = new DateTime(1976, 1, 1)
                });
                await authorService.AddAuthor(new Author()
                {
                    Id = "mahatma-gandhi",
                    Name = "Mahamta Gandhi",
                    Biography = "The Father of the Nation for India",
                    Photo = "https://pbs.twimg.com/media/FAqPzrrUYAM8pCu.jpg",
                    //BirthDate = new DateTime(1869, 10, 2),
                    //Tags = "freedom fighter, social reformer",
                    //DeathDate = new DateTime(1948, 1, 30)
                });
                await authorService.AddAuthor(new Author()
                {
                    Id = "jeffrey-archer",
                    Name = "Jeffrey Archer",
                    Biography = "One of the conemporary best-seleller british author, pariliamentarian, ex-convict",
                    Photo = "https://pbs.twimg.com/profile_images/3751745623/11bd5e198e1f0f7de40ffdf08f556293_400x400.jpeg",
                    //BirthDate = new DateTime(1946, 1, 1),
                    //Tags = "best-seller, english, british"

                });
                context.Response.Redirect("/author");
            });

            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            return app;
        }
    }
}
