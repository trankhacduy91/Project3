using Model.EF;
using Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class QuestionDAO
    {
        Project3DBContext db = null;
        public QuestionDAO()
        {
            db = new Project3DBContext();
        }

        public List<QuestionViewModel> ListAllQuestion()
        {
            var model = from a in db.Questions
                        join b in db.Users on a.UserID equals b.ID
                        select new QuestionViewModel()
                        {
                            ID = a.ID,
                            Title = a.Title,
                            Content = a.Content,
                            CreatedTime = a.CreatedTime,
                            Views = a.Views,
                            Likes = a.Likes,
                            UserID = a.UserID,
                            Anonymous = a.Anonymous,
                            Name = b.Name,
                            Images = b.Images

                        };
            return model.OrderByDescending(x => x.CreatedTime).ToList();
        }

        public QuestionViewModel getQuestionByID(int id)
        {

            //Object[] param = new SqlParameter[]
            //{
            //    new SqlParameter("@id", id)
            //};
            //var model = db.Database.SqlQuery<QuestionViewModel>("selectQuestionByID @id", param).SingleOrDefault();
            var model = from a in db.Questions
                        join b in db.Users on a.UserID equals b.ID
                        select new QuestionViewModel()
                        {
                            ID = a.ID,
                            Title = a.Title,
                            Content = a.Content,
                            CreatedTime = a.CreatedTime,
                            Views = a.Views,
                            Likes = a.Likes,
                            UserID = a.UserID,
                            Anonymous = a.Anonymous,
                            Name = b.Name,
                            Images = b.Images
                        };

            var model1 = db.Questions.SingleOrDefault(x => x.ID == id);
            model1.Views++;
            db.Entry(model1).State = EntityState.Modified;
            db.SaveChanges();
            return model.SingleOrDefault(x => x.ID == id);


            //var model = from a in db.Questions
            //            join b in db.Users on a.UserID equals b.ID
            //            select new QuestionViewModel()
            //            {
            //                ID = a.ID,
            //                Title = a.Title,
            //                Content = a.Content,
            //                CreatedTime = a.CreatedTime,
            //                Views = a.Views,
            //                Likes = a.Likes,
            //                UserID = a.UserID,
            //                Name = b.Name,
            //                Images = b.Images

            //            };

            //var model1 = model.SingleOrDefault(x => x.ID == id);
            //model1.Views++;
            //db.Entry(model1).State = EntityState.Modified;
            //db.SaveChanges();
            //return model1;
        }

        public List<QuestionViewModel> ListAnswer(int id )
        {
            var model = from a in db.Answers
                        join b in db.Users on a.UserID equals b.ID
                        join c in db.Questions on a.QuestionID equals c.ID
                        where (a.QuestionID == id)
                        select new QuestionViewModel()
                        {
                            AnswerID = a.ID,
                            AnswerContent = a.Content,
                            AnswerCreatedDate = a.CreatedTime,
                            UserAnswerID = a.UserID,
                            Name = b.Name,
                            Images = b.Images
                            
                        };
            return model.OrderByDescending(x => x.AnswerCreatedDate).ToList();
        }

        public int Insert(Question question)
        {
            db.Questions.Add(question);
            db.SaveChanges();
            return question.ID;
        }

        public int TotalQuestion()
        {
            var questions = db.Questions.Count();
            return questions;
        }

        
    }
}
