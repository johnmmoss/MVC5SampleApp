using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using MVC5SampleApp.Domain;
using MVC5SampleApp.Migrations;
using MVC5SampleApp.Models;

namespace MVC5SampleApp
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            Database.SetInitializer(
             new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());

            using (var context = new ApplicationDbContext())
            {
                // Hit the database to force migrations if required.
                var numeberOfUsers = context.Users.Count();
            }
        }
    }
}
