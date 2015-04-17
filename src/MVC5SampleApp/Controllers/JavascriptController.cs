using System.Collections.Generic;
using System.Web.Mvc;

namespace MVC5SampleApp.Controllers
{
    public class JavascriptController : Controller
    {
        //
        // GET: /Javascript/
        public ActionResult Index()
        {
            return View();
        }

        // You need to use the JsonRequestBahaviour swtich to avoid Json HiJacking http://haacked.com/archive/2009/06/25/json-hijacking.aspx/
        public JsonResult JsonSample1()
        {
            var items = new List<MyJsonItem>()
                {
                    new MyJsonItem(1, "one", "This is number1"),
                    new MyJsonItem(2, "two", "This is number2"),
                    new MyJsonItem(3, "three", "This is number3")
                };
            var jsonResult = new JsonResult();
            jsonResult.Data = items;
            jsonResult.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return jsonResult;
        }

        public JsonResult JsonSample2()
        {
             var items = new List<MyJsonItem>()
                {
                    new MyJsonItem(1, "one", "This is number1"),
                    new MyJsonItem(2, "two", "This is number2"),
                    new MyJsonItem(3, "three", "This is number3")
                };

             return Json(items, JsonRequestBehavior.AllowGet);
        }

        public JavaScriptResult Sample1()
        {
            return JavaScript("<script>alert(1)</script>");
        }
	}

    public class MyJsonItem
    {
        public int Id;
        public string Name;
        public string Description;

        public MyJsonItem(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }
}