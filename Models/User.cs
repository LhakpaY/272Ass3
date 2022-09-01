using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace _272Ass3.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        
        [Required(ErrorMessage = "Please enter your User Name")]
        [Display(Name = "User Name")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        
        [Display(Name = "Role")]
        public string Role { get; set; }
        public Boolean Deleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastEdit { get; set; }

    }
}

