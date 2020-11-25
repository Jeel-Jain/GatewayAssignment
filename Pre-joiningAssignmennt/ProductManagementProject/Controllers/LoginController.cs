using ProductManagementProject.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementProject.Controllers
{
    public class LoginController : Controller
    {
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
           

            var searchData = dbObj2.tbl_user.Where(x => x.Email == model.Email).SingleOrDefault();
            if(searchData!=null)
            {
                Session["Username"] = searchData.Name;
                return View("Dashboard", searchData);
               
            }
            else
            {

                return View("Login");

            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}