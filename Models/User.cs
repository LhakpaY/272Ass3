using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _272Ass3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Boolean Deleted { get; set; }
        [DataType(DataType.Date)]
        public DateTime Birthday { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEdit { get; set; }

        public User()
        {
        }
    }
}

