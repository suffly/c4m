using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class meetingtype
    {
        [Key]
        public int meetingtype_id { get; set; }
        public string? meetingtype_name { get; set; }
    }
}
