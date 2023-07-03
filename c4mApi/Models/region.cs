using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class region
    {
        [Key]
        public int region_id { get; set; }
        public string? region_name { get; set; }
    }
}
