using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MVC5SampleApp.Controllers
{
    public class HttpController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        //
        // HttpStatusCodeResult
        //
        public HttpStatusCodeResult Unavailable()
        {
            var status = HttpStatusCode.ServiceUnavailable;

            var statusCode = new HttpStatusCodeResult(status);

            return statusCode;
        }

        public HttpStatusCodeResult Found()
        {
            var status = HttpStatusCode.Found;

            var statusCode = new HttpStatusCodeResult(status);
            
            return statusCode;
        }

        //
        // NotFoundResult
        // 
        public HttpNotFoundResult NotFound()
        {
            var statusCode = new HttpNotFoundResult();
            
            return statusCode;
        }

        //
        // HttpStatusUnauthorized
        //
        public HttpUnauthorizedResult Unauthorized()
        {
            var statusCode = new HttpUnauthorizedResult();
            
            return statusCode;
        }
	}
}