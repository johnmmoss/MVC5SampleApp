using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5SampleApp.Models;

namespace MVC5SampleApp.Controllers
{
    public class RoleController : Controller
    {
        //
        // GET: /Role/
        public ActionResult Index()
        {
            var roleModels = new List<RoleModel>();
            using (var context = ApplicationDbContext.Create())
            {
                var roles = context.Roles.ToList();

                foreach (var role in roles)
                {
                    roleModels.Add(
                        new RoleModel()
                            {
                                Id = role.Id,
                                Name = role.Name
                            });
                }
            }

            return View(roleModels);
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (string.IsNullOrEmpty(collection["RoleName"]))
            {
                return RedirectToAction("Index");
            }
            try
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = collection["RoleName"];
                
                using (var context = ApplicationDbContext.Create())
                {

                    context.Roles.Add(role);

                    context.SaveChanges();
                    ViewBag.ResultMessage = "Role created successfully !";
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }
	}
}