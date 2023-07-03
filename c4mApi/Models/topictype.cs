using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class topictype
    {
        [Key]
        public int topictype_id { get; set; }
        public string? topictype_name { get; set; }
    }
}
