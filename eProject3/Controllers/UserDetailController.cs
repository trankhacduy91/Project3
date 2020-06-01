using Model.DAO;
using Model.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject3.Controllers
{
    public class UserDetailController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ViewDetail(int id)
        {
            var user = new UserDAO().getUserByID(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Update(User user)
        {
            
            
            if (ModelState.IsValid)
            {
                if (user.ImageFile != null)
                {
                    string fileName = System.IO.Path.GetFileName(user.ImageFile.FileName);
                    string filePath = @"~/Assets/client/images/" + fileName;

                    //Save the Image File in Folder.
                    user.ImageFile.SaveAs(Server.MapPath(filePath));
                    user.Experience = Convert.ToInt32(user.Experience);
                    user.Age = Convert.ToInt32(user.Age);
                    user.Images = fileName;
                    var dao = new UserDAO();
                    var result = dao.Update(user);

                    if (result)
                    {
                        return RedirectToAction("ViewDetail", "UserDetail");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Update user unsuccessfully!");
                    }
                }
                else
                {
                    user.Experience = Convert.ToInt32(user.Experience);
                    user.Age = Convert.ToInt32(user.Age);
                    var dao = new UserDAO();
                    var result = dao.Update(user);

                    if (result)
                    {
                        return RedirectToAction("ViewDetail", "UserDetail");

                    }
                    else
                    {
                        ModelState.AddModelError("", "Update user unsuccessfully!");
                    }
                }
                
            }
            return View("Update",user);
        }

        public ActionResult Update(int id)
        {
            var user = new UserDAO().getUserByID(id);
            return View(user);
        }

    }
}