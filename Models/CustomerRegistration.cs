using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCartMVC.Models
{
    public partial class CustomerRegistration
    {
        public CustomerRegistration()
        {
            AddBookings = new HashSet<AddBooking>();
        }

        public int CustomerId { get; set; }
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Only Alphabets allowed")]

        public string CustomerName { get; set; } = null!;
        
        public int? CustomerAge { get; set; }
        public string Address { get; set; } = null!;
       
        public string Password { get; set; } = null!;

        public virtual ICollection<AddBooking> AddBookings { get; set; }
    }
}
