using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class counselortype
    {
        [Key]
        public int counselortype_id { get; set; }
        public string? counselortype_name { get; set; }
    }
}
