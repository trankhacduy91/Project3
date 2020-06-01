using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Models
{
    public class EditUserModel
    {

        public int ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your Name.")]
        public string Name { get; set; }

        [StringLength(255)]
        [Required(ErrorMessage = "Please enter your Email.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Please enter Hospital.")]
        public string Hospital { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Please enter Specialize.")]
        public string Specialize { get; set; }

        public int? Experience { get; set; }

        [StringLength(250)]
        public string Images { get; set; }

        public bool IsDoctor { get; set; }

        //public int? CategoryID { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}