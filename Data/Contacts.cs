using System;
using System.ComponentModel.DataAnnotations;

namespace ContactManager.Data
{
	public class Contact
	{
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [MaxLength(250)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        [MaxLength(15)]
        public string PhoneNumber { get; set; }

        public DateTime BirthDate { get; set; }
    }
}

