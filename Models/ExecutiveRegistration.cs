using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCartMVC.Models
{
    public partial class ExecutiveRegistration
    {
        public ExecutiveRegistration()
        {
            AddBookings = new HashSet<AddBooking>();
        }

        public int ExecutiveId { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed")]
        public string ExecutiveName { get; set; } = null!;
        public int? ExecutiveAge { get; set; }
        public long PhoneNumber { get; set; }

     
        public string Password { get; set; } = null!;

        public virtual ICollection<AddBooking> AddBookings { get; set; }
    }
}
