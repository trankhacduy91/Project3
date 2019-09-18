namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Blog")]
    public partial class Blog
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        [StringLength(250)]
        public string Content { get; set; }

        [StringLength(250)]
        public string Image { get; set; }

        public int? UserID { get; set; }
    }
}
