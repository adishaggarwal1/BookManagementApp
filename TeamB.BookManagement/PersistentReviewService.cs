using TeamB.Utils;

namespace TeamB.BookManagement
{
    public class PersistentReviewService : IReviewService
    {
        IRepository<Review, int> repository;

        //constructor based DI
        public PersistentReviewService(IRepository<Review, int> repository)
        {
            this.repository = repository;
        }

        public async Task<Review> AddReview(Review review)
        {
            //perform some validation if needed
            if (review == null)
                throw new InvalidDataException("Review can't be null");            

            return await repository.Add(review);
        }

        public async Task DeleteReview(int reviewId)
        {
            await repository.Delete(reviewId);
        }

        public async Task<List<Review>> GetAllReviews()
        {
            return await repository.GetAll();
        }

        public async Task<Review> GetReviewById(int id)
        {
            return await repository.GetById(id);
        }

        public async Task<List<Review>> GetReviewsByBook(string bookId)
        {
            return await repository.GetAll(r => r.Book_Id == bookId);
        }

        public async Task<List<Review>> SearchReviews(string term)
        {
            term = term.ToLower();

            return await repository.GetAll(r => r.Title.ToLower().Contains(term) || r.Details.ToLower().Contains(term));
        }

        public async Task<Review> UpdateReview(Review review)
        {
            return await repository.Update(review, (old, newDetails) =>
            {
                old.Title = newDetails.Title;
                old.Details = newDetails.Details;
                old.Rating = newDetails.Rating;
            });
        }
    }
}
