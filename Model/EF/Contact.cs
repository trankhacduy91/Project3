namespace Model.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Contact")]
    public partial class Contact
    {
        public int ID { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage ="Please input Name.")]
        [Range(3,24)]
        public string Name { get; set; }

        [StringLength(150)]
        [Required(ErrorMessage = "Please input Email.")]
        [DataType(DataType.EmailAddress)]
        [Range(3, 50)]
        public string Email { get; set; }

        [StringLength(50)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Please input Phone.")]
        public string Phone { get; set; }

        [StringLength(250)]
        [Required(ErrorMessage = "Please input Message.")]
        [Range(10, 250)]
        public string Message { get; set; }


    }
}
