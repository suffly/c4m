using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class meeting
    {
        [Key]
        public int meeting_id { get; set; }
        public DateTime meeting_date { get; set; }
        public int meetingtype_id { get; set; }
        public int meetingterm_id { get; set; }
        public int meeting_set { get; set; }
        public int meeting_year { get; set; }
        public int meeting_time { get; set; }
        public int count_consulation { get; set; }
        public int count_consulationtotal { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        public DateTime create_date { get; set; }
        public int create_by { get; set; }
        public DateTime? update_date { get; set; }
        public int? update_by { get; set; }
    }
}
