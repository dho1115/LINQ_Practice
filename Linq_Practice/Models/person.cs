using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linq_Practice.Models
{
    public class person
    {   
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public int age { get; set; }
        public string City { get; set; }
        public bool LovesToTravel { get; set; }
    }
}
