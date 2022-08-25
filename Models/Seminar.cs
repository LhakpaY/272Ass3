using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _272Ass3.Models
{
    public class Seminar
    {
        [Key]
        public int Id { get; set; }
        [Display(Name="Title")]
        public string Name { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime RegistrationStart { get; set; }
        public DateTime RegistrationEnd { get; set; }
        public Organiser CreatedUser { get; set; }
        [Key]
        [ForeignKey("User")]
        [Required]
        public int UserID { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<Attendee> Attendees { get; set; }
        public Seminar()
        {
        }
    }
}

