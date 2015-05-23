using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC5SampleApp.Domain;
using MVC5SampleApp.Models;

namespace MVC5SampleApp.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var currentUserEmail = User.Identity.Name;
            var userModels = new List<UserModel>();
            using (var context = ApplicationDbContext.Create())
            {
                var users = context.Users.ToList();

                userModels.AddRange(
                    users.Select(user => new UserModel()
                    {
                        Id = user.Id,
                        Email = user.Email,
                        AccountIsLocked = user.LockoutEnabled,
                        AccountIsTwoFactorEnabled = user.TwoFactorEnabled
                    }));
            }

            // Set the current logged in user
            userModels.First(x => x.Email == currentUserEmail).IsCurrentUser = true;

            return View(userModels.OrderBy(x => x.Email).ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return RedirectToAction("Index");
            }
            using (var context = ApplicationDbContext.Create())
            {
                var thisUser = context.Users.FirstOrDefault(r => r.Id.Equals(userId, StringComparison.CurrentCultureIgnoreCase));
                if (thisUser == null)
                {
                    return RedirectToAction("Index");
                }
                // Dont want to delete the current logged in user.
                if (thisUser.Email != User.Identity.Name)
                {
                    context.Users.Remove(thisUser);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("Index");
        }
	}
}