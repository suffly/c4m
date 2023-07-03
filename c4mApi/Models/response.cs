using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class response
    {
        [Key]
        public int response_id { get; set; }
        public int consulationdetail_id { get; set; }
        public int meeting_id { get; set; }
        public string? response_topic { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        public DateTime create_date { get; set; }
        public int create_by { get; set; }
    }
}
