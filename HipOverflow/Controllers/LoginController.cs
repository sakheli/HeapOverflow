using HeapOverflow.Models;
using HeapOverflow.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace HeapOverflow.Controllers
{
    public class LoginController : Controller
    {
        Service1Client myService = new Service1Client();
        // GET: Login
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


        // POST: Login/Create
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    throw new Exception("მოდელი არ არის ვალიდური");
                
                var serviceModel = myService.Login(model.Email, model.Password);
                Session.Add("email", serviceModel.email);
                Session.Add("id", serviceModel.id);
                Session.Add("role", serviceModel.roleId);

                return RedirectToRoute(new
                {
                    controller = "Home",
                    action = "Index"
                });
            }
            catch
            {
                return View(model);
            }
        }


        public ActionResult Logout()
        {
            Session.Remove("email");
            Session.Remove("id");
            Session.Remove("role");

            return RedirectToRoute(new
            {
                controller = "Login",
                action = "Index"
            });
        }


    }
}
