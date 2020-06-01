using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ViewModel
{
    public class QuestionViewModel
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public DateTime CreatedTime { get; set; }

        public int? Views { get; set; }

        public int? Likes { get; set; }

        public int? UserID { get; set; }

        public bool? Anonymous { get; set; }

        public string Name { get; set; }

        public string Images { get; set; }
        [Required(ErrorMessage = "Please input answer content.")]
        public string AnswerContent { get; set; }

        public DateTime AnswerCreatedDate{get;set;}

        public int? UserAnswerID { get; set; }

        public int AnswerID { get; set; }



    }
}
