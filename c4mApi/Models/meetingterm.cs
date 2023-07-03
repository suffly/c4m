using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class meetingterm
    {
        [Key]
        public int meetingterm_id { get; set; }
        public string meetingterm_name { get; set; }
    }
}
