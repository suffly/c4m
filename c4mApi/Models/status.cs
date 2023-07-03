using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class status
    {
        [Key]
        public int status_id { get; set; }
        public string? status_name { get; set; }
    }
}
