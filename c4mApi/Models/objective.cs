using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class objective
    {
        [Key]
        public int objective_id { get; set; }
        public string? objective_name { get; set; }
    }
}
