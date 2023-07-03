using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class consulationdetail
    {
        [Key]
        public int consulationdetail_id { get; set; }
        public int consulation_id { get; set; }
        public int meeting_id { get; set; }
        public int topictype_id { get; set; }
        public int objective_id { get; set; }
        public int ministry_id { get; set; }
        public string? consulationdetail_topic { get; set; }
        public string? consulationdetail_detail { get; set; }
        public int province_id { get; set; }
        public int consulation_attachment_flag { get; set; }
        public int status_id { get; set; }
        //[Required]
        //[DataType(DataType.Date)]
        public DateTime create_date { get; set; }
        public int create_by { get; set; }
        public DateTime update_date { get; set; }
        public int update_by { get; set; }
        public DateTime send_date { get; set; }
        public int send_by { get; set; }
        public DateTime receive_date { get; set; }
        public int receive_by { get; set; }
    }
}
