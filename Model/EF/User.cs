namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.IO;
    using System.Web;

    [Table("User")]
    public partial class User
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(250)]
        public string Password { get; set; }

        [StringLength(20)]
        public string Role { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int?  Age { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Hospital { get; set; }

        [StringLength(20)]
        public string Specialize { get; set; }

        public int?  Experience { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        public bool IsDoctor { get; set; }

        public int? CategoryID { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

    }
}
