using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamB.BookManagement
{
    public interface IReviewService
    {
        Task<List<Review>> GetAllReviews();
        Task<Review> GetReviewById(int id);
        Task<List<Review>> GetReviewsByBook(string bookId);
        Task<Review> AddReview(Review review);
        Task<Review> UpdateReview(Review review);
        Task DeleteReview(int reviewId);
        Task<List<Review>> SearchReviews(string term);
    }
}
