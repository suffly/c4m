using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace c4mApi.Models
{
    public class counselor
    {
        [Key]
        public int counselor_id { get; set; }
        public int counselor_cid { get; set; }
        public int userprofile_id { get; set; }
        public string? counselor_title { get; set; }
        public string? counselor_name { get; set; }
        public string? counselor_surname { get; set; }
        public int counselor_set { get; set; }
        public int counselortype_id { get; set; }
        public int partylist_id { get; set; }
        public int counselor_status { get; set; }
    }
}
