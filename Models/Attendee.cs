using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace _272Ass3.Models
{
    public class Attendee : User
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public Attendee()
        {
            Role = "attendee";
        }
    }
}

