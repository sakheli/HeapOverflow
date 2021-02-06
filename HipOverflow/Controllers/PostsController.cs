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

        // GET: Posts/Create
        public ActionResult Create()
        {
            return View(new PostModel { });
        }

        // POST: Posts/Create
        [HttpPost]
        public ActionResult Create(PostModel postModel)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მოდელი არ არის ვალიდური");

                PostContract obj = new PostContract();
                CategoryContract categoryObj = new CategoryContract();

                obj.id = postModel.id;
                obj.title = postModel.title;
                obj.Category = postModel.Category;
                obj.Users = postModel.Users;
                obj.body = postModel.body;
                obj.Replies = postModel.Replies;


                var serviceModel = myService.AddPost(obj, categoryObj, postModel.id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(postModel);
            }
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
            return View();
        }

        // POST: Posts/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
