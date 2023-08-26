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
        public ViewResult Add()
        {
            return View(new Review());
        }

        [HttpPost]
        public async Task<ActionResult> Add(Review review)
        {
            if (ModelState.IsValid)
            {
                await reviewService.AddReview(review);
                return RedirectToAction("Index");
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

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> Delete(int id)
        {
            await reviewService.DeleteReview(id);
            return RedirectToAction("Index");
        }
    }
}
