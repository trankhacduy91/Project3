using eProject3.Common;
using Model.DAO;
using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eProject3.Controllers
{
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            var session = Session[CommonConstants.USER_SESSION];

            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            return View();
        }

        [ChildActionOnly]
        public PartialViewResult DisplayQuestion(string searchString)
        {
            var model = new QuestionDAO().ListAllQuestion(searchString);
            ViewBag.countQuestion = model.Count();
            return PartialView(model);
        }

        public ActionResult QuestionDetail(int id)
        {
            var question = new QuestionDAO().getQuestionByID(id);
            return View(question);
        }

        

        [ChildActionOnly]
        public PartialViewResult Answer(int id)
        {
            var model = new QuestionDAO().ListAnswer(id);
            return PartialView(model);
        }

        [HttpPost]
        public ActionResult NewQuestion(Question question)
        {
            

            if (ModelState.IsValid)
            {
                var dao = new QuestionDAO();
                int id = dao.Insert(question);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Add new question unsuccessfully!. ");
                }
            }
            return RedirectToAction("Index", "Question");
        }

        [HttpPost]
        public ActionResult AddAnswer(AnswerVM obj)
        {
            var session = Session[CommonConstants.USER_SESSION];

            if (session == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else {
                int userId = Convert.ToInt32(((UserLogin)session).UserId);
                Project3DBContext db = new Project3DBContext();
                Answer answer = new Answer();
                answer.QuestionID = obj.QuestionID;
                answer.Content = obj.Content;
                answer.UserID = userId;
                answer.CreatedTime = DateTime.Now;
                db.Answers.Add(answer);
                db.SaveChanges();
                return RedirectToAction("QuestionDetail", new { id = obj.QuestionID });
            }
        }
        
    }
}