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
    public class UserController : Controller
    {
        Service1Client myService = new Service1Client();
        // GET: User
        public ActionResult Index()
        {
            List<UserModel> model = new List<UserModel>();

            var serviceModel = myService.GetUsers();

            foreach (var item in serviceModel)
            {
                UserModel obj = new UserModel();
                obj.id = item.id;
                obj.username = item.username;
                obj.email = item.email;
                obj.role = new RoleModel { roleName = item.Roles.roleName,id = item.Roles.id };

                model.Add(obj);

            }

            return View(model);
        }



        // GET: User/Create
        public ActionResult Create(int id)
        {
            try
            {
                if (Session["role"].ToString() == "3")
                {
                    if (!ModelState.IsValid)
                        throw new Exception("მოდელი არ არის ვალიდური");

                    myService.AddMod(int.Parse(Session["id"].ToString()), id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            try
            {
                if (Session["role"].ToString() == "3")
                {
                    if (!ModelState.IsValid)
                        throw new Exception("მოდელი არ არის ვალიდური");

                    myService.AddMod(int.Parse(Session["id"].ToString()), model.id);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

       

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                if (Session["role"].ToString() == "3")
                {
                    var serviceModel = myService.RemoveMod(int.Parse(Session["id"].ToString()), id);
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
