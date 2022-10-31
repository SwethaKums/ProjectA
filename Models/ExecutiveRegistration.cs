using System;
using System.Collections.Generic;

namespace MyCart.Models
{
    public partial class ExecutiveRegistration
    {
       
        public int ExecutiveId { get; set; }
        public string ExecutiveName { get; set; } = null!;
        public int? ExecutiveAge { get; set; }
        public long PhoneNumber { get; set; }
        public string Password { get; set; } = null!;

     
    }
}
