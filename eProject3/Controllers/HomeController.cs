using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject3.Controllers
{
    public class HomeController : Controller
    {
        Project3DBContext db = new Project3DBContext();
        public ActionResult Index()
        {
            ViewBag.TotalUser = new UserDAO().TotalUser();
            ViewBag.TotalPost = new QuestionDAO().TotalQuestion();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

       
        public ActionResult Doctor(string searchDoctor)
        {

            var model = new ContactDAO().SearchDoctor(searchDoctor);
            return View(model.ToList());
            

        }

        public ActionResult SendContactSuccess()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SendContact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                var id = new ContactDAO().SendContact(contact);
                if (id > 0)
                {
                    return View("SendContactSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "Send Contact Unsuccessfully !");
                }
            }
            return View("Contact");

        }
    }
}