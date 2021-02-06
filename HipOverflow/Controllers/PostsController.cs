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
    public class PostsController : Controller
    {
        Service1Client myService = new Service1Client();
        // GET: Posts
        public ActionResult Index(int id)
        {
            List<PostModel> model = new List<PostModel>();
            CategoryContract contract = new CategoryContract() { id = id };

            var service = myService.GetPosts(contract);
            foreach(var data in service)
            {
                PostModel obj = new PostModel();
                obj.id = data.id;
                obj.title = data.title;
                obj.body = data.body;
                obj.Category = data.Category;
                obj.Users = data.Users;
                obj.Replies = data.Replies;

                model.Add(obj);
            }    

            return View(model);
        }

        // GET: Posts/Details/5
        public ActionResult Details(int id)
        {
            PostModel obj = new PostModel{ };


            var serviceModel = myService.GetPost(id);

            if (serviceModel == null)
            {
                TempData["Error"] = "ასეთი ჩანაწერი არ არსებობს";
                return RedirectToAction("Index");
            }


            obj.id = serviceModel.id;
            obj.title = serviceModel.title;
            obj.Category = serviceModel.Category;
            obj.Users = serviceModel.Users;
            obj.body = serviceModel.body;
            obj.Replies = serviceModel.Replies;

            return View(obj);
        }

        [HttpPost]
        // GET: Posts/Details/5
        public ActionResult Details(PostModel postModel)
        {
            PostModel obj = new PostModel { };


            myService.AddReply(postModel.id, postModel.title, int.Parse(Session["id"].ToString()));

          

            var serviceModel = myService.GetPost(postModel.id);

            if (serviceModel == null)
            {
                TempData["Error"] = "ასეთი ჩანაწერი არ არსებობს";
                return RedirectToAction("Index");
            }

            obj.id = serviceModel.id;
            obj.title = serviceModel.title;
            obj.Category = serviceModel.Category;
            obj.Users = serviceModel.Users;
            obj.body = serviceModel.body;
            obj.Replies = serviceModel.Replies;

            return View(obj);
        }

        // GET: Posts/Create
        public ActionResult Create()
        {
            var categories = myService.GetCategories().Select(x => new CategoryModel
            {
                id = x.id,
                categoryName = x.categoryName
            }).ToList();
            ViewBag.Categories = new SelectList(categories, "id", "categoryName");

            return View(new PostModel { });
        }


        // POST: Posts/Create
        [HttpPost]
        public ActionResult Create(PostModel postModel)
        {
            try
            {
                //if (!ModelState.IsValid)
                //    throw new Exception("მოდელი არ არის ვალიდური");

                PostContract obj = new PostContract();
                CategoryContract categoryObj = new CategoryContract();

                obj.id = postModel.id;
                obj.title = postModel.title;
                //obj.Category = postModel.Category;
                obj.Users = postModel.Users;
                obj.body = postModel.body;
                obj.Replies = postModel.Replies;


                var serviceModel = myService.AddPost(obj, postModel.categoryId, int.Parse(Session["id"].ToString()));
                return RedirectToAction("MyPosts");
            }
            catch (Exception ex)
            {
                return View(postModel);
            }
        }


        public ActionResult MyPosts()
        {
            List<PostModel> model = new List<PostModel>();
            
            var service = myService.GetPostsByUserId(int.Parse(Session["id"].ToString()));
            foreach (var data in service)
            {
                PostModel obj = new PostModel();
                obj.id = data.id;
                obj.title = data.title;
                obj.body = data.body;
                obj.Category = data.Category;
                obj.Users = data.Users;
                obj.Replies = data.Replies;

                model.Add(obj);
            }

            return View("index", model);
        }

        // GET: Posts/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Posts/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Posts/Delete/5
        public ActionResult Delete(int id)
        {
            //if (Session["role"].ToString() == "3")
            //{
                var serviceModel1 = myService.GetPost(id);

                PostModel obj = new PostModel();
                obj.id = serviceModel1.id;
                obj.title = serviceModel1.title;
                obj.Category = serviceModel1.Category;
                obj.Users = serviceModel1.Users;
                obj.body = serviceModel1.body;
                obj.Replies = serviceModel1.Replies;

                var serviceModel2 = myService.RemovePost(int.Parse(Session["id"].ToString()), serviceModel1);
            //}
            return RedirectToRoute(new
            {
                controller = "Category",
                action = "Index"
            });
        }

        // POST: Posts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
