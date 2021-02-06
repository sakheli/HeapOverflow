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
    public class RegisterController : Controller
    {
        ServiceReference1.Service1Client myService = new ServiceReference1.Service1Client();
        // GET: Register
        public ActionResult Index()
        {
            if (Session["email"] != null && Session["id"] != null && Session["role"] != null)
            {
                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            return View();
        }

        

        // POST: Register/Create
        [HttpPost]
        public ActionResult Index(RegisterModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მოდელი არ არის ვალიდური");

                UserContract obj = new UserContract();

                obj.username = model.Name;
                obj.email = model.Email;
                obj.password  = model.Password;

                var serviceModel = myService.Register(obj);
                if (serviceModel) {
                    return RedirectToRoute(new
                    {
                        controller = "Login",
                        action = "Index"
                    });
                }
                //return RedirectToAction("Index");
                throw new Exception("მოდელი არ არის ვალიდური");
            }
            catch
            {
                return View(model);
            }
        }

    }
}
