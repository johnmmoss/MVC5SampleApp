using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5SampleApp.Controllers
{
    public class TypeaheadController : Controller
    {
        //
        // GET: /Typeahead/
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult States(string q)
        {
            var states = new[]
                {
                    "Alabama", 
                    "Alaska", 
                    "Arizona", 
                    "Arkansas", 
                    "California",
                    "Colorado",
                    "Connecticut",
                    "Delaware",
                    "Florida",
                    "Georgia",
                    "Hawaii",
                    "Idaho",
                    "Illinois",
                    "Indiana",
                    "Iowa",
                    "Kansas",
                    "Kentucky",
                    "Louisiana",
                    "Maine",
                    "Maryland",
                    "Massachusetts",
                    "Michigan",
                    "Minnesota",
                    "Mississippi",
                    "Missouri",
                    "Montana",
                    "Nebraska",
                    "Nevada",
                    "New Hampshire",
                    "New Jersey",
                    "New Mexico",
                    "New York",
                    "North Carolina",
                    "North Dakota",
                    "Ohio",
                    "Oklahoma",
                    "Oregon",
                    "Pennsylvania",
                    "Rhode Island",
                    "South Carolina",
                    "South Dakota",
                    "Tennessee",
                    "Texas",
                    "Utah",
                    "Vermont",
                    "Virginia",
                    "Washington",
                    "West Virginia",
                    "Wisconsin",
                    "Wyoming"
                };

            if (!string.IsNullOrEmpty(q))
            {
                states = states.Where(
                    x => x.ToLower().StartsWith(q.ToLower())).ToArray();
            }
            return Json(states, JsonRequestBehavior.AllowGet);

        }
    }
}