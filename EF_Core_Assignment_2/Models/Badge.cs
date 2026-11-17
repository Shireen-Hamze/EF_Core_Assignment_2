using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_Core_Assignment_2.Models
{
    public enum BadgeTier
    {
        Standard,
        VIP
    }
    public class Badge
    {

        public int Id { get; set; }

        public int BadgeNumber { get; set; }

        public DateTime IssuedDate { get; set; }

        public BadgeTier Tier { get; set; }

        // Foreign Key
        public int AttendeeId { get; set; }

        // Navigation Property
        public Attendee Attendee { get; set; }
    }
    
}
