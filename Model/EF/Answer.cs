namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Answer")]
    public partial class Answer
    {
        public int ID { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        public int? UserID { get; set; }

        public int? QuestionID { get; set; }

        public DateTime CreatedTime { get; set; }
    }
}
