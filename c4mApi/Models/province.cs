using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class province
    {
        [Key]
        public int province_id { get; set; }
        public string? province_name { get; set; }
        public int region_id { get; set; }
    }
}
