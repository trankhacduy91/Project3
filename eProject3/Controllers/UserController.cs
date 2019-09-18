using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace eProject3.Controllers
{
    public class UserController : Controller
    {
        // GET: Admin/User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create(User user)
        {
            var dao = new UserDAO();
            long id = dao.Insert(user);
            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    return RedirectToAction("Index", "Login");

                }
                else
                {
                    ModelState.AddModelError("", "Error!!!");
                }
            }
            return View("Index");
        }
        
    }
}