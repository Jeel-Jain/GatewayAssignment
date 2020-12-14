using NLog;
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

       
        private static Logger logger = LogManager.GetCurrentClassLogger();

        // GET: User
        public ActionResult User()
        {
            logger.Info("Inside User Controller");
            return View();
        }

        [HttpPost]
        [HandleError]
        public ActionResult Add(tbl_user model)
        {
            try
            {
                logger.Info("Adding Data");
                HttpResponseMessage response = GlobleVariables.WebApiClient.PostAsJsonAsync("User", model).Result;

                TempData["successMesg"] = "Registration  Successfully";
                logger.Info("Registration  Successfully");
                return RedirectToAction("Login", "Login", new { area = "" });

            }
            catch(Exception e)
            {
               
                logger.Error("Error:"+e.Message);
                throw e;
                return Content("Something Went Wrong");
            }
           

        }



    }
}