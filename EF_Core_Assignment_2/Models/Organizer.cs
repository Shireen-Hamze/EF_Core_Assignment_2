using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace EF_Core_Assignment_2.Models
{
    [Table("EventOrganizers")]
    public class Organizer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(150)]
        public string CompanyName { get; set; }

        public bool IsVerified { get; set; }

        // Navigation Properties
        public OrganizerProfile OrganizerProfile { get; set; }

        public ICollection<Event> Events { get; set; }
    } 
}
