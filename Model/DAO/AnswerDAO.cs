using Model.EF;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.DAO
{
    public class AnswerDAO
    {
        Project3DBContext db = null;

        public AnswerDAO()
        {
            db = new Project3DBContext();
        }

        public List<Answer> ViewAnswer(int id)
        {
            return db.Answers.Where(x => x.QuestionID == id).OrderBy(x => x.CreatedTime).ToList();
        }

        
    }
}
