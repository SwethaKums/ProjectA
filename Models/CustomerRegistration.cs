using System;
using System.Collections.Generic;

namespace MyCart.Models
{
    public partial class CustomerRegistration
    {
       

        public int CustomerId { get; set; }
        public string CustomerName { get; set; } = null!;
        public int? CustomerAge { get; set; }
        public string Address { get; set; } = null!;
        public string Password { get; set; } = null!;

       
    }
}
