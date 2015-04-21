using System.Web.Mvc;
using System.Web.Routing;
using MVC5SampleApp.Models;

namespace MVC5SampleApp.Controllers
{
    public class FeedbackController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(FeedbackModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Complete", "Feedback", new { email=model.Email });
        }

        public ActionResult Complete(string email)
        {
            return View((object)email);
        }
	}
}