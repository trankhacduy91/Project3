using Model.EF;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace eProject3.Areas.Admin.Models
{
    public class UsersModel
    {
        public UsersModel(int idU, string usernameU, string passwordU, string roleU, string nameU,
            int? ageU, string emailU, string hospitalU, string specializeU, int? experienceU, string imagesU)
        {
            ID = idU;
            UserName = usernameU;
            Password = passwordU;
            Role = roleU;
            Name = nameU;
            Age = ageU;
            Email = emailU;
            Hospital = hospitalU;
            Specialize = specializeU;
            Experience = experienceU;
            Images = imagesU;
        }
        public UsersModel()
        {
        }

        public int ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your UserName.")]
        public string UserName { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Please enter your Password.")]
        public string Password { get; set; }

        [StringLength(20)]
        [Required(ErrorMessage = "Please enter your Role.")]
        public string Role { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Please enter your Name.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Age.")]
        public int? Age { get; set; }

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
    }
}