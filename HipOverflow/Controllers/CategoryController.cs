using HeapOverflow.Models;
using HeapOverflow.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCF.DataContract;

namespace HeapOverflow.Controllers
{
    [Auth]
    public class CategoryController : Controller
    {
        Service1Client myService = new Service1Client();
        // GET: Category
        public ActionResult Index()
        {
            List<CategoryModel> model = new List<CategoryModel>();

            var serviceModel = myService.GetCategories();

            foreach (var item in serviceModel)
            {
                CategoryModel obj = new CategoryModel();
                obj.id = item.id;
                obj.categoryName = item.categoryName;

                model.Add(obj);

            }
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryModel model)
        {
            try
            {
                if (Session["role"].ToString() == "3")
                {
                    if (!ModelState.IsValid)
                        throw new Exception("მოდელი არ არის ვალიდური");
               
                    CategoryContract obj = new CategoryContract();
                    obj.categoryName = model.categoryName;

                    var serviceModel = myService.AddCategory(int.Parse(Session["id"].ToString()), obj);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if(Session["role"].ToString() == "3") { 
                    var serviceModel = myService.RemoveCategory(int.Parse(Session["id"].ToString()), id);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

      
    }
}
