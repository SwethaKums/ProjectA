using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyCartMVC.Models
{
    public partial class AddBooking
    {
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string TimeOfPickup { get; set; } = null!;
        public string Weight { get; set; } = null!;
        public int? Price { get; set; }
        public int? ExecutiveId { get; set; }

        public virtual CustomerRegistration? Customer { get; set; }
        public virtual ExecutiveRegistration? Executive { get; set; }
    }
}
