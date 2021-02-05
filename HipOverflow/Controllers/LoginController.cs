using HeapOverflow.Models;
using HeapOverflow.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace HipOverflow.Controllers
{
    public class LoginController : Controller
    {
        Service1Client myService = new Service1Client();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }


        // POST: Login/Create
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მოდელი არ არის ვალიდური");
                
                var serviceModel = myService.Login(model.Email, model.Password);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(model);
            }
        }

    }
}
