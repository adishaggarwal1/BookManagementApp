using Microsoft.AspNetCore.Mvc;
using TeamB.BookManagement;

namespace BooksWeb.Controllers
{
    public class ReviewController : Controller
    {
        IReviewService reviewService;

        public ReviewController(IReviewService reviews)
        {
            this.reviewService = reviews;
        }

        public async Task<ViewResult> Index()
        {
            var reviews = await reviewService.GetAllReviews();

            return View(reviews);
        }

        public async Task<ViewResult> Details(int id)
        {
            var review = await reviewService.GetReviewById(id);

            return View(review);
        }

        [HttpGet]
        public ViewResult Add(string bookId, string reviewerEmail)
        {
            var review = new Review()
            {
                BookId = bookId,
                Reviewer_Email = HttpContext.Session.GetString("logedin_user")
            };
            //ViewBag.BookId = bookId;
            return View(review);
        }

        [HttpPost]
        public async Task<ActionResult> Add(Review review)
        {
            if(ModelState.ErrorCount==1 && ModelState["Book"].Errors.Count == 1)
            {
                await reviewService.AddReview(review);
                return RedirectToAction("BookDetails", "Book", new { Id = review.BookId } );
            }
            return View(review);
        }

        [HttpGet]
        public async Task<ViewResult> Edit(int id)
        {
            var review = await reviewService.GetReviewById(id);
            return View(review);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Review review)
        {
            await reviewService.UpdateReview(review);

            return RedirectToAction("BookDetails", "Book", new { Id = review.BookId });
        }

        public async Task<ActionResult> Delete(int id, string bookId)
        {
            await reviewService.DeleteReview(id);
            return RedirectToAction("BookDetails", "Book", new { Id = bookId });
        }
    }
}
