using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linq_Practice.Models
{
    public class location
    {
        [Key]
        public int id { get; set; }
        public string city { get; set; }

        public ICollection<hotel> Hotels { get; set; }
        public DateTime? DateCreated { get; set; }

        public location()
        {
            this.Hotels = new HashSet<hotel>();
        }
    }
}
