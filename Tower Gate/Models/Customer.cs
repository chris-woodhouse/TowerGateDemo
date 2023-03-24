using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tower_Gate.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [Range(0, 110)]
        public int Age { get; set; }
        [RegularExpression("^([a-zA-Z0-9 .&'-]+)$", ErrorMessage = "Please use numbers and letters")]
        public string PostCode { get; set; }
        public double Height { get; set; }

    }
}
