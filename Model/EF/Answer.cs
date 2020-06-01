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
        [Required(ErrorMessage ="Please input Content.")]
        public string Content { get; set; }
        [Required(ErrorMessage = "Please input UserID.")]
        public int? UserID { get; set; }
        [Required(ErrorMessage = "Please input QuestionID.")]
        public int? QuestionID { get; set; }
        [Required(ErrorMessage = "Please input CreatedTime.")]
        public DateTime CreatedTime { get; set; }
    }
}
