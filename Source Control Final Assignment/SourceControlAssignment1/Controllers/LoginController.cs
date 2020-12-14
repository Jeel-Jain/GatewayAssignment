using NLog;
using SourceControlAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SourceControlAssignment1.Controllers
{
    public class LoginController : Controller
    {
        private static Logger logger = LogManager.GetLogger("myAppLoggerRule");
        ProductEntities1 dbObj2 = new ProductEntities1();
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Dashboard(tbl_user obj)
        {
            return View(obj);
        }
        public ActionResult IsValid(tbl_user model)
        {
            try
            {
                logger.Info("Validating the User in Login Controller");

                var searchData = dbObj2.tbl_user.Where(x => x.Email == model.Email && x.Password==model.Password).SingleOrDefault();
                if (searchData != null)
                {
                    logger.Info("Log in successfull");
                    Session["Username"] = searchData.Name;
                    return View("Dashboard", searchData);

                }
                else
                {
                    logger.Info("Invalid Username or Password");

                    return View("Login");

                }

            }
            catch(Exception e)
            {
                logger.Error("Exception !  : " + e.Message);
                return Content("Exception :" + e.Message);

            }
          
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    
}
}