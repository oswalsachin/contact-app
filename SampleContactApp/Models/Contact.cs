using System;
using System.ComponentModel.DataAnnotations;

namespace SampleContactApp.Models
{
    public class Contact
    {
        public int ID { get; set; }

        [Display(Name = "First Name")]
        [DataType(DataType.Text)]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [DataType(DataType.Text)]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress)]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
        [Required]
        public string PhoneNumber { get; set; }

        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
    }
}