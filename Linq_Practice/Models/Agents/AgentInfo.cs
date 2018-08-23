using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Linq_Practice.Models.Agents
{
    public class AgentInfo
    {   
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string ImagePath { get; set; }
    }
}
