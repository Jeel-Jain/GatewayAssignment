using SourceControlAssignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace SourceControlAssignment1.Controllers
{
    public class UserController : Controller
    {
        ProductEntities1 dbObj = new ProductEntities1();

      

        // GET: User
        public ActionResult User()
        {
            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Add(tbl_user model)
        {
            HttpResponseMessage response = GlobleVariables.WebApiClient.PostAsJsonAsync("User", model).Result;
            TempData["successMesg"] = "Registration  Successfully";
            return RedirectToAction("Login", "Login", new { area = "" });

        }



    }
}