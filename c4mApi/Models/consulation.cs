using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class consulation
    {
        [Key]
        public int consulation_id { get; set; }
        public int meeting_id { get; set; }
        public int counselor_id { get; set; }
        public int partylist_id { get; set; }
        public int counselordivision_id { get; set; }
        public int count_consulationdetail { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        public DateTime create_date { get; set; }
        public int create_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? update_by { get; set; }
    }
}
