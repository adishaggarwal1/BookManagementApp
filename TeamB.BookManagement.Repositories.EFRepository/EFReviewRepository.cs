using TeamB.Utils;

namespace TeamB.BookManagement.Repositories.EFRepository
{
    public class EFReviewRepository : IRepository<Review, int>
    {
        BMSContext context;
        public EFReviewRepository(BMSContext context)
        {
            this.context = context;
        }

        public async Task<Review> Add(Review entity)
        {
            context.Reviews.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Delete(int id)
        {
            var review = await GetById(id);
            context.Reviews.Remove(review);
            await context.SaveChangesAsync();
        }

        public async Task<List<Review>> GetAll()
        {
            await Task.CompletedTask;
            return context.Reviews.ToList();
        }

        public async Task<List<Review>> GetAll(Func<Review, bool> predicate)
        {
            await Task.CompletedTask;
           /* var q = from review in context.Reviews
                    where predicate(review)
                    select review;

            return q.ToList();*/
           return context.Reviews.Where(predicate).ToList();
        }

        public async Task<Review> GetById(int id)
        {
            await Task.CompletedTask;

            return context.Reviews.FirstOrDefault(r => r.Id == id);
        }

        public async Task<Review> Update(Review entity, Action<Review, Review> mergeOldNew)
        {
            var review = await GetById(entity.Id);
            if (review != null)
            {
                mergeOldNew(review, entity);
                await context.SaveChangesAsync();
            }

            return entity;
        }
    }
}
