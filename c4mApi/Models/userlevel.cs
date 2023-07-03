using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class userlevel
    {
        [Key]
        public int userlevel_id { get; set; }
        public string? userlevel_name { get; set; }
        public string? userlevel_desc { get; set; }
    }
}
