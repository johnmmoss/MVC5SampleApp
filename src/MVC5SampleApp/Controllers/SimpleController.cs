using System.Web.Mvc;

namespace MVC5SampleApp.Controllers
{
    public class SimpleController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public EmptyResult Empty()
        {
            // _emailSender.Send("subject", "Doing something async");

            return new EmptyResult();
        }

        public ContentResult Content()
        {
            var content = new ContentResult();
            content.Content = "<html><body bgcolor=\"red\"><p>This is my HTML content</body></html>";
            content.ContentType = "text/html";
            return content;

        }

        public ContentResult ContentXml()
        {
            var content = new ContentResult();
            content.Content = "<books><book>one</book><book>two</book></books>";
            content.ContentType = "text/xml";
            return content;
        }

        public HttpUnauthorizedResult Unauthorized()
        {
            var httpUnauthorizedResult = new HttpUnauthorizedResult();

            return httpUnauthorizedResult;
        }
    }
}