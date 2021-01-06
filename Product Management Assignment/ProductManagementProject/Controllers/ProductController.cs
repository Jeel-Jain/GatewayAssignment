
using ProductManagementProject.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace ProductManagementProject.Controllers
{
    public class ProductController : Controller
    {
        IEnumerable<tbl_product> productlist;
        ProductEntities1 dbObj2 = new ProductEntities1(); 

        //Fetch Product Details Using Api 
        public ActionResult ProductList()
        {
          
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;

            //var res = dbObj2.tbl_product.ToList();
            productlist = response.Content.ReadAsAsync<IEnumerable<tbl_product>>().Result;


            return View(productlist);
        }

        //Delete Product By Id
        public ActionResult DeleteProduct(int id)
        {
            //var res = dbObj2.tbl_product.Where(x => x.Id == id).First();
            //dbObj2.tbl_product.Remove(res);
            //dbObj2.SaveChanges();

            //var list = dbObj2.tbl_product.ToList();

            HttpResponseMessage delresponse = GlobalVariables.WebApiClient.DeleteAsync("Product/"+id.ToString()).Result;
            
            HttpResponseMessage response = GlobalVariables.WebApiClient.GetAsync("Product").Result;
            productlist = response.Content.ReadAsAsync<IEnumerable<tbl_product>>().Result;
            TempData["successMesg"] = "Deleted Successfully";
            return View("ProductList", productlist);
           
        }
      
        //Insert Product Data
        [HttpPost]
        public ActionResult AddProduct(tbl_product model)
        {
            
            if(ModelState.IsValid)
            {

              
                tbl_product obj = new tbl_product();
                obj.Id = model.Id;
                obj.Name = model.Name;
                obj.Category = model.Category;

                
                obj.Price = model.Price;

                String fileName = Path.GetFileNameWithoutExtension(model.ImageFile.FileName);
                String fileExtension = Path.GetExtension(model.ImageFile.FileName);
                fileName = fileName + DateTime.Now.ToString("yymmssfff") + fileExtension;
                model.smallImage = "~/Images/" + fileName;
                model.longImage = "~/Images/" + fileName;

                fileName = Path.Combine(Server.MapPath("~/Images/"),fileName);
                model.ImageFile.SaveAs(fileName);
                obj.smallImage = model.smallImage;
                obj.longImage = model.longImage;
                obj.shortDescription = model.shortDescription;
                obj.longDescription = model.longDescription;
                obj.Quantity = model.Quantity;

               

                if(model.Id==0)
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PostAsJsonAsync("Product", obj).Result;
                    TempData["successMesg"] = "Saved Successfully";
                  
                }
                else
                {
                    HttpResponseMessage response = GlobalVariables.WebApiClient.PutAsJsonAsync("Product/"+model.Id, obj).Result;
                    TempData["successMesg"] = "Updated Successfully";

                }
              

            }
            HttpResponseMessage responses = GlobalVariables.WebApiClient.GetAsync("Product").Result;         
            productlist = responses.Content.ReadAsAsync<IEnumerable<tbl_product>>().Result;
            return View("ProductList",productlist);

           

          
        }

        //Form for Updating Product Details
        public ActionResult ProductPage(tbl_product obj)

        {
            if(obj!=null)
            {
                return View(obj);
            }
            else
            {
                return View();
            }
           
        }

      

    }
}