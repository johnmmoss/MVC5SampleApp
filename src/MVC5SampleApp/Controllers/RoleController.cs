﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5SampleApp.Domain;
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

                roleModels.AddRange(
                    roles.Select(role => new RoleModel()
                    {
                        Id = role.Id, Name = role.Name
                    }));
            }

            return View(roleModels.OrderBy(x => x.Name).ToList());
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            if (string.IsNullOrEmpty(collection["roleName"]))
            {
                return RedirectToAction("Index");
            }
            try
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = collection["roleName"];
                
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

        public ActionResult Delete(string roleName)
        {
            using (var context = ApplicationDbContext.Create())
            {
                var thisRole = context.Roles.FirstOrDefault(r => r.Name.Equals(roleName, StringComparison.CurrentCultureIgnoreCase));
                context.Roles.Remove(thisRole);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
	}
}