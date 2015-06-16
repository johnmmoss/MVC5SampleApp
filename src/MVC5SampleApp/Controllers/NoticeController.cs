using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using MVC5SampleApp.Domain;

namespace MVC5SampleApp.Controllers
{
    public class NoticeController : Controller
    {
        private ApplicationDbContext _context;

        public NoticeController()
        {
            _context = new ApplicationDbContext();
        }

        public async Task<ActionResult> Index()
        {
            return View(await _context.Notices.ToListAsync());
        }

        //
        // GET: /Notice/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Notice/Create
        [HttpPost]
        public ActionResult Create(Notice notice)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    notice.CreatedDate = DateTime.Now;
                    _context.Notices.Add(notice);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                // TODO: Add insert logic here

                return Create(notice);
            }
            catch
            {
                return View();
            }
        }
    }
}
