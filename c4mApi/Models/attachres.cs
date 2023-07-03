using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class attachres
    {
        [Key]
        public int attachres_id { get; set; }
        public int response_id { get; set; }
        public string? attachres_name { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        public DateTime upload_date { get; set; }
        public int upload_by { get; set; }
    }
}
