using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linq_Practice.Models.Agents
{
    public class bid
    {
        [Key]
        public int id { get; set; }
        public DateTime? DatePosted { get; set; }
        public AgentInfo AgentInfo { get; set; }
        public string email { get; set; }
        public double phone { get; set; }
        public int BidAmount { get; set; }
    }
}
