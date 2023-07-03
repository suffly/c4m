using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class ministry
    {
        [Key]
        public int ministry_id { get; set; }
        public string? ministry_name { get; set; }
        public string? ministry_head { get; set; }
        public string? ministry_invitation { get; set; }
    }
}
