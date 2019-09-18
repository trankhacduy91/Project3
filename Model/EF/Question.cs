namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Question")]
    public partial class Question
    {
        public Question()
        {
            CreatedTime = DateTime.Now;
        }
        public int ID { get; set; }

        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public DateTime CreatedTime { get; set; }

        public int? Views { get; set; }

        public int? Likes { get; set; }

        public int? UserID { get; set; }    

        public bool Anonymous { get; set; }
    }
}
