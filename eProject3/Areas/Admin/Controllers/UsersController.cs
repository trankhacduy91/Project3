using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eProject3.Areas.Admin.Models;
using Model.EF;
using PagedList;

namespace eProject3.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private Project3DBContext db = new Project3DBContext();

        // GET: Admin/Users
        [Authorize(Roles = "ADMIN")]
        public ActionResult Index(int? page)
        {
            // 1. Tham số int? dùng để thể hiện null và kiểu int
            // page có thể có giá trị là null và kiểu int.

            // 2. Nếu page = null thì đặt lại là 1.
            if (page == null)
                page = 1;

            // 4. Tạo kích thước trang (pageSize) hay là số Link hiển thị trên 1 trang
            int pageSize = 5;

            // 3. Tạo truy vấn, lưu ý phải sắp xếp theo trường nào đó, ví dụ OrderBy
            // theo LinkID mới có thể phân trang.
            List<UsersModel> listuserM = new List<UsersModel>();
            var list = (from q in db.Users
                        select q).OrderBy(x => x.ID);
            foreach (var item in list)

            {

                UsersModel objUservm = new UsersModel(); // ViewModel

                objUservm.ID = item.ID;
                objUservm.UserName = item.UserName;

                objUservm.Password = item.Password;

                objUservm.Role = item.Role;

                objUservm.Name = item.Name;

                objUservm.Age = item.Age;

                objUservm.Role = item.Role;

                objUservm.Name = item.Name;

                objUservm.Email = item.Email;

                objUservm.Hospital = item.Hospital;

                objUservm.Specialize = item.Specialize;

                objUservm.Experience = item.Experience;
                objUservm.Images = item.Images;
                listuserM.Add(objUservm);

            }
            // 4.1 Toán tử ?? trong C# mô tả nếu page khác null thì lấy giá trị page, còn
            // nếu page = null thì lấy giá trị 1 cho biến pageNumber.
            int pageNumber = (page ?? 1);

            // 5. Trả về các Link được phân trang theo kích thước và số trang.
            return View(listuserM.ToPagedList(pageNumber, pageSize));
        }

        // GET: Admin/Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Admin/Users/Create
        public ActionResult Create()
        {
            UsersModel model = new UsersModel();
            return View(model);
        }

        // POST: Admin/Users/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(HttpPostedFileBase imageFile, UsersModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (imageFile != null)
                    {
                        string fileName = System.IO.Path.GetFileName(imageFile.FileName);
                        string filePath = @"~/Assets/client/images/" + fileName;

                        //Save the Image File in Folder.
                        imageFile.SaveAs(Server.MapPath(filePath));
                        User user = new User();

                        user.UserName = model.UserName;
                        user.Password = model.Password;
                        user.Role = model.Role;
                        user.Name = model.Name;
                        user.Age = model.Age;
                        user.Email = model.Email;
                        user.Hospital = model.Hospital;
                        user.Specialize = model.Specialize;
                        user.Experience = model.Experience;
                        user.Images = fileName;
                        db.Users.Add(user);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else 
                    {
                        ModelState.AddModelError("", "Pick a picture, Please!");
                        return View(model); ;
                    }
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Debug.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Debug.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }

            }

            return View(model);
        }


        // GET: Admin/Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            UsersModel model = new UsersModel(user.ID, user.UserName, user.Password, user.Role, user.Name, user.Age, user.Email,user.Hospital, user.Specialize, user.Experience, user.Images);
            
            if (user == null)
            {
                return HttpNotFound();
            }

            return View(model);

        }

        // POST: Admin/Users/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(HttpPostedFileBase imageFile ,UsersModel model)
        {
            if (ModelState.IsValid)
            {
                if (imageFile !=null) 
                {
                string fileName = System.IO.Path.GetFileName(imageFile.FileName);
                string filePath = @"~/Assets/client/images/" + fileName;

                //Save the Image File in Folder.
                imageFile.SaveAs(Server.MapPath(filePath));

                User user = db.Users.Where(x => x.ID == model.ID)
                                    .SingleOrDefault();
                
                user.UserName = model.UserName;
                user.Password = model.Password;
                user.Role = model.Role;
                user.Name = model.Name;
                user.Age = model.Age;
                user.Email = model.Email;
                user.Hospital = model.Hospital;
                user.Specialize = model.Specialize;
                user.Experience = model.Experience;
                user.Images = fileName;
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                }
                else 
                {
                    User user = db.Users.Where(x => x.ID == model.ID)
                                    .SingleOrDefault();

                    user.UserName = model.UserName;
                    user.Password = model.Password;
                    user.Role = model.Role;
                    user.Name = model.Name;
                    user.Age = model.Age;
                    user.Email = model.Email;
                    user.Hospital = model.Hospital;
                    user.Specialize = model.Specialize;
                    user.Experience = model.Experience;
                    
                    db.Entry(user).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        // GET: Admin/Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Admin/Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
